using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HR_WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
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
        //[Route("swagger.json")]
        //[HttpGet]
        //public string GetSwaggerJson()
        //{
        //    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //    string commentsFileName = "os-compute-2.json";
        //    string commentsFile = Path.Combine(baseDirectory, commentsFileName);
        //    return System.IO.File.ReadAllText(commentsFile);
        //}
    }
}