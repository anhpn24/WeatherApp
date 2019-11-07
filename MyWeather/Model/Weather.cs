using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyWeather.Models
{
    public class Coord
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; } = 0;

        [JsonProperty("lat")]
        public double Latitude { get; set; } = 0;
    }

    public class Sys
    {

        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("main")]
        public string Main { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; } = 0;
        [JsonProperty("pressure")]
        public double Pressure { get; set; } = 0;

        [JsonProperty("humidity")]
        public double Humidity { get; set; } = 0;
        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; } = 0;

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; } = 0;
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; } = 0;

        [JsonProperty("deg")]
        public double WindDirectionDegrees { get; set; } = 0;

    }

    public class Clouds
    {

        [JsonProperty("all")]
        public int CloudinessPercent { get; set; } = 0;
    }

    public class WeatherRoot
    {
        [JsonProperty("coord")]
        public Coord Coordinates { get; set; } = new Coord();

        [JsonProperty("sys")]
        public Sys System { get; set; } = new Sys();

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; } = new List<Weather>();

        [JsonProperty("main")]
        public Main MainWeather { get; set; } = new Main();

        [JsonProperty("wind")]
        public Wind Wind { get; set; } = new Wind();

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; } = new Clouds();

        [JsonProperty("id")]
        public int CityId { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("dt_txt")]
        public string Date { get; set; } = string.Empty;

        [JsonIgnore]
        public string DisplayDate => DateTime.Parse(Date).ToLocalTime().ToString("g");
        [JsonIgnore]
        public string DisplayTemp => $"Temp: {MainWeather?.Temperature ?? 0}° {Weather?[0]?.Main ?? string.Empty}";
        [JsonIgnore]
        public string DisplayIcon => $"http://openweathermap.org/img/w/{Weather?[0]?.Icon}.png";
    }

    public class WeatherForecastRoot
    {
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("cod")]
        public string Vod { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public List<WeatherRoot> Items { get; set; }

    }

    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("population")]
        public int Population { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
    }

    #region Model Standard
    public class WeatherRoot2
    {
        [JsonProperty("coord")]
        public Coord Coordinates { get; set; } = new Coord();

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; } = new List<Weather>();

        [JsonProperty("base")]
        public string Base { get; set; } = string.Empty;

        [JsonProperty("main")]
        public Main MainWeather { get; set; } = new Main();

        [JsonProperty("visibility")]
        public int Visibility { get; set; } = 0;

        [JsonProperty("wind")]
        public Wind Wind { get; set; } = new Wind();

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; } = new Clouds();

        [JsonProperty("dt")]
        public string Date { get; set; } = string.Empty;

        [JsonProperty("sys")]
        public Sys2 System { get; set; } = new Sys2();

        [JsonProperty("timezone")]
        public int TimeZone { get; set; } = 0;

        [JsonProperty("id")]
        public int CityId { get; set; } = 0;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("cod")]
        public int Cod { get; set; } = 0;
    }

    public class Sys2
    {
        [JsonProperty("type")]
        public int Type { get; set; } = 0;

        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;

        [JsonProperty("sunrise")]
        public string SunRise { get; set; } = string.Empty;

        [JsonProperty("sunset")]
        public string SunSet { get; set; } = string.Empty;
    }
    #endregion
}
