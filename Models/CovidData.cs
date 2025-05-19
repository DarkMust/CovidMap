using System.Text.Json.Serialization;

namespace CovidMap.Models
{
    public class GlobalStats
    {
        [JsonPropertyName("cases")]
        public long Cases { get; set; }

        [JsonPropertyName("todayCases")]
        public long TodayCases { get; set; }

        [JsonPropertyName("deaths")]
        public long Deaths { get; set; }

        [JsonPropertyName("recovered")]
        public long Recovered { get; set; }
    }

    public class CountryStats : GlobalStats
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("countryInfo")]
        public CountryInfo CountryInfo { get; set; } = new CountryInfo();
    }

    public class CountryInfo
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("long")]
        public double Longitude { get; set; }

        [JsonPropertyName("iso2")]
        public string? Iso2 { get; set; }
    }

    public class NewsItem
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }

    public class NewsResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("articles")]
        public List<NewsItem> Articles { get; set; } = new List<NewsItem>();
    }
} 