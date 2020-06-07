using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers
{
    /// <summary>
    /// 刷卡服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardService _cardService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardService"></param>
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }
        /// <summary>
        /// 取得刷卡資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetCard")]
        [HttpPost]
        public List<CardDto> GetCard([FromBody]AttendanceEntry attendanceEntry)
        {
            return _cardService.GetCard(attendanceEntry);
        }
        /// <summary>
        /// 取得忘刷原因
        /// </summary>
        /// <returns></returns>
        [Route("GetCardReason")]
        [HttpPost]
        public List<CardReasonDto> GetCardReason()
        {
            return _cardService.GetCardReason();
        }
    }
}