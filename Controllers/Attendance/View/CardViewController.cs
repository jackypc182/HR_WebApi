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
        ICardViewService _cardViewService;

        public  CardViewController(ICardViewService cardViewService) 
        {
            _cardViewService = cardViewService;
        }

        /// <summary>
        /// 刷卡查詢
        /// </summary>
        /// <remarks>
        /// { "employeeList": [ "A1357","A0793" ],"dateBegin": "2020-09-05", "dateEnd": "2020-09-05","isForget":true }
        /// </remarks>
        [HttpPost("CardSearchView")]
        public ApiResult<List<CardSearchViewDto>> GetCardSearchView(CardSearchViewEntry cardSearchViewEntry)
        {
            return _cardViewService.GetCardSearchView(cardSearchViewEntry);
        }
    }
}
