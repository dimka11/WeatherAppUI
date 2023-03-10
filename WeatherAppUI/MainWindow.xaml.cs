using System;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;


namespace WeatherAppUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetDateTime()
        {
            DateTime localDate = DateTime.Now;
            return localDate.ToString("yyy-MM-dd HH:mm:ss");
        }

        private async Task<Tuple<double, double>> GetCoordinatesFromLocationName(string country, string city)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.openweathermap.org/");

            try
            {
                string? apiKey = ConfigurationManager.AppSettings.Get("api_key");
                var response = await httpClient.GetAsync($"geo/1.0/direct?q={city},{country}&limit=1&appid={apiKey}");
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsonArray = JsonNode.Parse(jsonString)!.AsArray();
                var lat = jsonArray[0]["lat"].GetValue<double>();
                var lon = jsonArray[0]["lon"].GetValue<double>();

                return new Tuple<double, double>(lat, lon);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return new Tuple<double, double>(55.0, 73.37);
            }
        }

        private Tuple<string, string> GetWeather()
        {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "python";
            startInfo.Arguments = $"{ScriptName.Text} --date \"{DateTextBox.Text} {TimeTextBox.Text}\" --lat {LatTextBox.Text} --lon {LonTextBox.Text}";
            startInfo.WorkingDirectory = ScriptDirPath.Text;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();

            var standardOutput = new StringBuilder();
            var standardError = new StringBuilder();
            while (!process.HasExited)
            {
                standardOutput.Append(process.StandardOutput.ReadToEnd());
                standardError.Append(process.StandardError.ReadToEnd());
            }

            standardOutput.Append(process.StandardOutput.ReadToEnd());
            standardError.Append(process.StandardOutput.ReadToEnd());
            return new Tuple<string, string>(standardOutput.ToString(), standardError.ToString());
        }


        private void SetWeatherTextToUi(string weatherText, string error)
        {
            WeatherOutputTextBlock.Text = weatherText;
            string errorContent = error;

            if (WeatherOutputTextBlock.Text.Length > 0)
            {
                CopyToClipBoardButton.IsEnabled = true;
            }

            if (errorContent.Length > 0)
            {
                MessageBox.Show(errorContent, "Произошла ошибка");
            }
        }

        private void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            var weatherText = GetWeather();
            SetWeatherTextToUi(weatherText.Item1, weatherText.Item2);
        }

        private void CopyToClipBoardButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(WeatherOutputTextBlock.Text);
        }

        private void SetCurrentDateToUi()
        {
            string currentDateTime = GetDateTime();
            DateTextBox.Text = currentDateTime.Split(' ')[0];
            TimeTextBox.Text = currentDateTime.Split(' ')[1];
            CopyToClipBoardButton.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetCurrentDateToUi();
        }

        private async void LocNameTextBox_OnKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            e.Handled = true;

            var coordinates =  await GetCoordinatesFromLocationName(LocNameCountryTextBox.Text, LocNameCityTextBox.Text);
            LatTextBox.Text = coordinates.Item1.ToString("0.##", CultureInfo.InvariantCulture);
            LonTextBox.Text = coordinates.Item2.ToString("0.##", CultureInfo.InvariantCulture);
        }

        private void TimeTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            var weatherText = GetWeather();
            SetWeatherTextToUi(weatherText.Item1, weatherText.Item2);
        }
    }
}
