using MyWeather.Models;
using System.Net.Http;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace MyWeather.Services
{
    public enum Units
    {
        Imperial,
        Metric
    }

    public class WeatherService
    {
        const string APIKey = "b6fab57a77c3e8b460a4bd78df6539e2";
        const string WeatherCoordinatesUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units={2}&appid={3}";
        const string WeatherCityUri = "http://api.openweathermap.org/data/2.5/weather?q={0}&units={1}&appid={2}";
        const string ForecaseUri = "http://api.openweathermap.org/data/2.5/forecast?id={0}&units={1}&appid={2}";

        public async Task<WeatherRoot> GetWeather(double latitude, double longitude, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherCoordinatesUri, latitude, longitude, units.ToString().ToLower(), APIKey);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherRoot>(json);
            }

        }

        public async Task<WeatherRoot> GetWeather(string city, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherCityUri, city, units.ToString().ToLower(), APIKey);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherRoot>(json);
            }

        }

        public async Task<WeatherForecastRoot> GetForecast(int id, Units units = Units.Imperial)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(ForecaseUri, id, units.ToString().ToLower(), APIKey);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<WeatherForecastRoot>(json);
            }

        }
    }
}
