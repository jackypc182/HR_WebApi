using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_WebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HR_WebApi.Controllers
{
    /// <summary>
    /// 這個為測試用API主要為針對AOP或是相關擴充功能驗證的API Service
    /// </summary>
    [ApiController]
    [DefaultAuthorize(Roles = "administrator,manager,test")]
    [Route("[controller]")]
    public class AuthorizeTestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AuthorizeTestController> _logger;

        public AuthorizeTestController(ILogger<AuthorizeTestController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 測試驗證角色為為test禁止呼叫
        /// </summary>
        /// <returns></returns>
        /// <responses Code="401">驗證失敗</responses>
        [HttpGet]
        [Route(nameof(withAuthorize))]
        public IEnumerable<WeatherForecast> withAuthorize()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(withoutAuthorize))]
        public IEnumerable<WeatherForecast> withoutAuthorize()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}