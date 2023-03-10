using System;
using System.Text;
using System.Windows;


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

        private void GetWeatherButton_Click(object sender, RoutedEventArgs e)
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

            WeatherOutputTextBlock.Text = standardOutput.ToString();
            string ErrorContent = standardError.ToString();

            if (WeatherOutputTextBlock.Text.Length > 0) {
                CopyToClipBoardButton.IsEnabled = true;
            }

            if (ErrorContent.Length > 0)
            {
                MessageBox.Show(ErrorContent, "Произошла ошибка");
            }
        }

        private void CopyToClipBoardButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(WeatherOutputTextBlock.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string CurrentDateTime = GetDateTime();
            DateTextBox.Text = CurrentDateTime.Split(' ')[0];
            TimeTextBox.Text = CurrentDateTime.Split(' ')[1];
            CopyToClipBoardButton.IsEnabled = false;
        }
    }
}
