using System.Globalization;
using System.Text;

namespace StravaApp
{
    internal class WeatherProvider
    {
        public WeatherProvider() {}
        public string GetWeather(ActivityExportData activity)
        {

            string scriptName = "main.py";
            string dirPath = "B:\\Code\\PycharmProjects\\WeatherScript";
            string dateTime = activity.StarDateLocal.ToString("yyy-MM-dd HH:mm:ss");
            string lat = activity.StartLat.ToString(CultureInfo.InvariantCulture);
            string lon = activity.StartLon.ToString(CultureInfo.InvariantCulture);

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            startInfo.UseShellExecute = false;
            startInfo.FileName = "python";
            startInfo.Arguments = $"{scriptName} --date \"{dateTime}\" --lat {lat} --lon {lon}";
            startInfo.WorkingDirectory = dirPath;
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

            return standardOutput.ToString();
        }
    }
}
