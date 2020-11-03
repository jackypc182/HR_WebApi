using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Attendance.View
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/View/[controller]")]
    [ApiController]
    public class CardViewController
    {
        public  CardViewController(){}

        [HttpPost("CardSearchView")]
        public ApiResult<List<CardSearchViewDto>> GetCardSearchView(CardSearchViewEntry cardSearchViewEntry)
        {
            return new ApiResult<List<CardSearchViewDto>>();
        }
    }
}
