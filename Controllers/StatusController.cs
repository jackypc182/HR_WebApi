using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HR_WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IConfiguration _configuration;

        public StatusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public string ServiceStatus()
        {
            return "服務執行中.....";
        }
    }
}