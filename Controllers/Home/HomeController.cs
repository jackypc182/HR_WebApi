using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Home
{
    /// <summary>
    /// 首頁
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 取得首頁資訊卡
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public ApiResult<List<HomeInfoCardDto>> GetHomeInfoCard()
        {
            return null;
        }
    }
}
