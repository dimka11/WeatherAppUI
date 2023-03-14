﻿using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using StravaApp.Model;
using System.Text;
using StravaApp;


var run = new Run();
await run.StartAuthProcess();
await run.GetAthleteInfo();
var activity = await run.GetLastActivity();
var exportActivityData = run.ExtractActivityData(activity);
File.WriteAllText("./last_activity_data.json", JsonSerializer.Serialize(exportActivityData));

string weatherText = new WeatherProvider().GetWeather(exportActivityData);

if (!string.IsNullOrWhiteSpace(weatherText))
{
    await run.LastActivityEdit(activity, weatherText);
    Console.WriteLine("done");
}

else
{
    Console.WriteLine("Failed to get the weather");
}

namespace StravaApp
{

    public class Run
    {
        private Token? _token;
        private readonly HttpClient _httpClient = new();

        public Run()
        {
            _httpClient.BaseAddress = new Uri("https://www.strava.com");
        }

        public async Task StartAuthProcess()
        {
            var auth = new StravaAuth();

            if (File.Exists("./token.json"))
            {
                _token = JsonSerializer.Deserialize<Token>(File.ReadAllText("./token.json"));
            }

            else
            {
                string? code;
                if (auth.CheckCode())
                {
                    code = auth.GetCodeFromStore();
                }
                else
                {
                    code = auth.GetCode();
                }

                Console.WriteLine(code);

                _token = await auth.TokenExchange();
            }

            if (_token != null && _token.expires_at < new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds())
            {
                this._token = await auth.TokenRefresh(_token.refresh_token);
            }
            else
            {
                this._token = _token;
            }

            var bearer = this._token?.access_token;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearer);
        }

        public async Task GetAthleteInfo()
        {
            var result = await _httpClient.GetAsync("api/v3/athlete");
            var resultContent = await result.Content.ReadAsStringAsync();
            Console.WriteLine(resultContent);
        }

        public async Task<SummaryActivity> GetLastActivity()
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["page"] = 1.ToString();
            query["per_page"] = 1.ToString();

            var result = await _httpClient.GetAsync($"api/v3/athlete/activities?{query.ToString()}");
            string resultContent = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());

            var activities = JsonSerializer.Deserialize<List<SummaryActivity>>(resultContent, options);
            return activities[0];
        }

        public ActivityExportData ExtractActivityData(SummaryActivity activity)
        {
            return new ActivityExportData()
            {
                Id = activity.Id,
                Name = activity.Name,
                StarDateLocal = activity.StartDateLocal,
                ElapsedTime = activity.ElapsedTime,
                StartLat = (float)activity.StartLatlng[0],
                StartLon = (float)activity.StartLatlng[1],
                EndLat = (float)activity.EndLatlng[0],
                EndLon = (float)activity.EndLatlng[1],
            };
        }

        public async Task LastActivityEdit(SummaryActivity activity, string comment)
        {
            var jsonString = JsonSerializer.Serialize(new UpdatableActivity()
            {
                Description = comment,
                Name = activity.Name,
                Commute = activity.Commute,
                HideFromHome = activity.HideFromHome,
                Trainer = activity.Trainer,
            });

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync($"api/v3/activities/{activity.Id}", content);
            string resultContent = await result.Content.ReadAsStringAsync();

        }

        public DetailedActivity GetDetailedActivity(int activity_id)
        {
            return new DetailedActivity();
        }

        public async void CreateActivityManual()
        {

        }

        public async void UploadActivity()
        {

        }
    }

    public class ActivityExportData
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public float StartLat { get; set; }
        public float StartLon { get; set; }
        public float EndLat { get; set; }
        public float EndLon { get; set; }
        public DateTime StarDateLocal { get; set; }
        public int ElapsedTime { get; set; }

        public ActivityExportData() { }
    }


    public class AppSettings
    {
        public string Code { get; set; } = null!;
    }

    public class AppSettingsJson
    {
        public AppSettings AppSettings { get; set; }
    }

    class AuthData
    {
        public AuthData() { }

        public string ClientId = Environment.GetEnvironmentVariable("STRAVA_CLIENT_ID") ?? throw new InvalidOperationException();
        public string ClientSecret = Environment.GetEnvironmentVariable("STRAVA_CLIENT_SECRET") ?? throw new InvalidOperationException();
        public string Code = "";
        public string GrantType = "authorization_code";
        public string RedirectUri = "http://localhost:8080";
        public string Scope = "activity:read_all,activity:write";

    }

    public class Token
    {
        public string token_type { get; set; }
        public int expires_at { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
        // public string athlete { get; set; }
        public Token() { }

    }

    class StravaAuth
    {
        private readonly AuthData _authData;
        private Token? _token;
        public static IConfiguration Config { get; private set; }
        public StravaAuth()
        {
            _authData = new AuthData();

            var fullPath = Path.GetFullPath("./appsettings.json");

            if (!File.Exists("./appsettings.json"))
            {
                File.WriteAllText(fullPath, "{\r\n  \"AppSettings\": {\r\n    \"code\": \"\"\r\n  }\r\n}\r\n");
            }

            Config = new ConfigurationBuilder()
                .AddJsonFile(fullPath)
                .Build();
        }

        public bool CheckCode()
        {
            string? code = Config.GetSection("AppSettings:code").Value;
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }
            return true;
        }

        public string? GetCodeFromStore()
        {
            _authData.Code = Config.GetSection("AppSettings:code").Value;
            return _authData.Code;
        }
        public string? GetCode()
        {
            // HttpClient httpClient = new HttpClient();
            // httpClient.BaseAddress = new Uri("https://www.strava.com");
            // httpClient.GetAsync(
            //     $"oauth/authorize?client_id={_authData.ClientID}&redirect_uri={_authData.RedirectUri}&response_type=code&scope={_authData.Scope}");

            var uri = new Uri(
                $"https://www.strava.com/oauth/authorize?client_id={_authData.ClientId}&redirect_uri={_authData.RedirectUri}&response_type=code&scope={_authData.Scope}");

            var psi = new ProcessStartInfo
            {
                FileName = uri.ToString(),
                UseShellExecute = true
            };
            Process.Start(psi);

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            var query = request.Url.Query;
            var parsedString = HttpUtility.HtmlDecode(query);
            var code = HttpUtility.ParseQueryString(parsedString)["code"];
            var state = HttpUtility.ParseQueryString(parsedString)["state"]; // ""
            var scope = HttpUtility.ParseQueryString(parsedString)["scope"]; // read,activity:write,activity:read_all

            listener.Stop();

            _authData.Code = code;

            var json_string = File.ReadAllText("../../../appsettings.json");
            var des_obj = JsonSerializer.Deserialize<AppSettingsJson>(json_string);

            des_obj.AppSettings.Code = code;
            var new_json_string = JsonSerializer.Serialize(des_obj);

            File.WriteAllText("../../../appsettings.json", new_json_string);

            return code;
        }

        public async Task<Token> TokenExchange()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.strava.com");
            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("client_id", _authData.ClientId),
            new KeyValuePair<string, string>("client_secret", _authData.ClientSecret),
            new KeyValuePair<string, string>("code", _authData.Code),
            new KeyValuePair<string, string>("grant_type", _authData.GrantType),

        });
            var result = await httpClient.PostAsync("api/v3/oauth/token", content);
            string resultContent = await result.Content.ReadAsStringAsync();

            JsonNode json_node = JsonNode.Parse(resultContent)!.AsObject();
            JsonNode athlete = json_node["athlete"].AsObject();
            Console.WriteLine(athlete.ToJsonString());
            // Console.WriteLine(json_node["athlete"].GetValue<string>());

            Token token = JsonSerializer.Deserialize<Token>(resultContent);

            WriteTokenToDisk(token);

            return token;
        }

        private static void WriteTokenToDisk(Token? token)
        {
            var tokenJsonString = JsonSerializer.Serialize(token);
            File.WriteAllText("./token.json", tokenJsonString);
        }

        public async Task<Token?> TokenRefresh(string refreshToken)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.strava.com");
            var content = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("client_id", _authData.ClientId),
            new KeyValuePair<string, string>("client_secret", _authData.ClientSecret),
            new KeyValuePair<string, string>("refresh_token", refreshToken),
            new KeyValuePair<string, string>("grant_type", "refresh_token"),

        });
            var result = await httpClient.PostAsync("api/v3/oauth/token", content);
            var resultContent = await result.Content.ReadAsStringAsync();

            var token = JsonSerializer.Deserialize<Token>(resultContent);
            WriteTokenToDisk(token);
            return token;
        }
    }


}

