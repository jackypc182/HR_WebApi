using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers
{
    /// <summary>
    /// 錯誤控制器
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private ILogger _logger;

        /// <summary>
        /// 錯誤處理
        /// </summary>
        /// <param name="logger"></param>
        public ErrorController(NLog.ILogger logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 開發版錯誤處理
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <returns></returns>
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }
        /// <summary>
        /// 正式版錯誤處理
        /// </summary>
        /// <returns></returns>
        [Route("/error")]
        public IActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            //if (webHostEnvironment.EnvironmentName != "Development")
            //{
            //    throw new InvalidOperationException(
            //        "This shouldn't be invoked in non-development environments.");
            //}

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.Error(context.Error);
            return Problem();
        }
    }

}