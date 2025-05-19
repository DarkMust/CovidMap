using Microsoft.AspNetCore.Mvc;
using CovidMap.Services;

namespace CovidMap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CovidController : ControllerBase
    {
        private readonly ICovidService _covidService;

        public CovidController(ICovidService covidService)
        {
            _covidService = covidService;
        }

        [HttpGet("global")]
        public async Task<IActionResult> GetGlobalStats()
        {
            var stats = await _covidService.GetGlobalStatsAsync();
            return Ok(stats);
        }

        [HttpGet("country/{countryCode}")]
        public async Task<IActionResult> GetCountryStats(string countryCode)
        {
            var stats = await _covidService.GetCountryStatsAsync(countryCode);
            return Ok(stats);
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _covidService.GetAllCountriesStatsAsync();
            return Ok(countries);
        }

        [HttpGet("news")]
        public async Task<IActionResult> GetNews()
        {
            var news = await _covidService.GetNewsAsync();
            return Ok(news);
        }
    }
} 