using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 刷卡服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardService _cardService;
        private ILogger _logger;
        /// <summary>
        /// 刷卡控制器
        /// </summary>
        /// <param name="cardService">刷卡服務</param>
        /// <param name="logger"></param>
        public CardController(ICardService cardService ,ILogger logger)
        {
            _cardService = cardService;
            _logger = logger;
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
            _logger.Info("開始呼叫CardService.GetCard");
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
            _logger.Info("開始呼叫CardService.GetCardReason");
            return _cardService.GetCardReason();
        }
    }
}