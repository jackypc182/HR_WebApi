using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Card/GetCard,Admin")]
        public ApiResult<List<CardDto>> GetCard(AttendanceEntry attendanceEntry)
        {
            _logger.Info("開始呼叫CardService.GetCard");
            ApiResult<List<CardDto>> apiResult = new ApiResult<List<CardDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _cardService.GetCard(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得忘刷原因
        /// </summary>
        /// <returns></returns>
        [Route("GetCardReason")]
        [HttpPost]
        [Authorize(Roles = "Card/GetCardReason,Admin")]
        public ApiResult<List<CardReasonDto>> GetCardReason()
        {
            _logger.Info("開始呼叫CardService.GetCardReason");
            ApiResult<List<CardReasonDto>> apiResult = new ApiResult<List<CardReasonDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _cardService.GetCardReason();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
    }
}