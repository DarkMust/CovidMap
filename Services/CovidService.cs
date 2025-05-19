using System.Text.Json;
using CovidMap.Models;
using RestSharp;
using System.Text.Json.Serialization;

namespace CovidMap.Services
{
    public interface ICovidService
    {
        Task<GlobalStats?> GetGlobalStatsAsync();
        Task<CountryStats?> GetCountryStatsAsync(string countryCode);
        Task<List<CountryStats>?> GetAllCountriesStatsAsync();
        Task<List<NewsItem>> GetNewsAsync();
    }

    public class CovidService : ICovidService
    {
        private readonly RestClient _client;
        private readonly IConfiguration _configuration;
        private readonly string _newsApiKey;
        private List<NewsItem>? _cachedNews;
        private DateTime _lastNewsFetchTime;

        public CovidService(IConfiguration configuration)
        {
            _configuration = configuration;
            _newsApiKey = _configuration["NewsApiKey"] ?? string.Empty;
            _client = new RestClient();
            _cachedNews = null;
            _lastNewsFetchTime = DateTime.MinValue;
        }

        public async Task<GlobalStats?> GetGlobalStatsAsync()
        {
            var request = new RestRequest("https://disease.sh/v3/covid-19/all");
            var response = await _client.ExecuteAsync(request);
            if (string.IsNullOrEmpty(response.Content))
                return null;
            return JsonSerializer.Deserialize<GlobalStats>(response.Content);
        }

        public async Task<CountryStats?> GetCountryStatsAsync(string countryCode)
        {
            var request = new RestRequest($"https://disease.sh/v3/covid-19/countries/{countryCode}");
            var response = await _client.ExecuteAsync(request);
            if (string.IsNullOrEmpty(response.Content))
                return null;
            return JsonSerializer.Deserialize<CountryStats>(response.Content);
        }

        public async Task<List<CountryStats>?> GetAllCountriesStatsAsync()
        {
            var request = new RestRequest("https://disease.sh/v3/covid-19/countries");
            var response = await _client.ExecuteAsync(request);
            if (string.IsNullOrEmpty(response.Content))
                return null;
            return JsonSerializer.Deserialize<List<CountryStats>>(response.Content);
        }

        public async Task<List<NewsItem>> GetNewsAsync()
        {
            // Check if cached data is still valid (within the last 24 hours)
            if (_cachedNews != null && (DateTime.Now - _lastNewsFetchTime).TotalHours < 24)
            {
                return _cachedNews;
            }

            // If cache is invalid or doesn't exist, fetch new data
            var request = new RestRequest("https://newsapi.org/v2/everything");
            request.AddParameter("q", "(covid-19 OR coronavirus) AND (cases OR vaccine OR pandemic)");
            request.AddParameter("language", "en");
            request.AddParameter("sortBy", "publishedAt");
            request.AddParameter("pageSize", "8"); // Requesting 8 articles
            request.AddParameter("apiKey", _newsApiKey);

            var response = await _client.ExecuteAsync(request);
            if (string.IsNullOrEmpty(response.Content))
            {
                _cachedNews = new List<NewsItem>(); // Cache empty list if no content
                _lastNewsFetchTime = DateTime.Now;
                return _cachedNews;
            }

            var newsResponse = JsonSerializer.Deserialize<NewsResponse>(response.Content);
            
            // Update cache and timestamp if successful
            _cachedNews = newsResponse?.Articles ?? new List<NewsItem>();
            _lastNewsFetchTime = DateTime.Now;
            
            return _cachedNews;
        }
    }
} 