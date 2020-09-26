using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 請假服務
    /// </summary>
    /// <description>
    /// 請假服務的輔助說明
    /// </description>
    /// <remarks>測試123</remarks>    
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private IAbsenceService _absenceService;
        private ILogger _logger;
        /// <summary>
        /// 請假控制器
        /// </summary>
        /// <param name="absenceService">請假服務</param>
        /// <param name="logger"></param>
        public AbsenceController(IAbsenceService absenceService,ILogger logger)
        {
            _absenceService = absenceService;
            _logger = logger;
        }
        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns>產生的結果</returns>
        /// <remarks>請假服務的輔助說明</remarks>  
        [Route("GetAbsenceTaken")]
        [HttpPost]
        public List<AbsenceTakenDto> GetAbsenceTaken([FromBody]AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsenceTaken");
            return _absenceService.GetAbsenceTaken(absenceEntryDto);
        }
        /// <summary>
        /// 取得銷假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsenceCancel")]
        [HttpPost]
        public List<AbsenceCancelDto> GetAbsenceCancel([FromBody]AbsenceEntry absenceEntryDto)
        {
            return _absenceService.GetAbsenceCancel(absenceEntryDto);
        }
        /// <summary>
        /// 取得剩餘時數
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsBalance")]
        [HttpPost]
        public List<AbsenceBalanceDto> GetAbsBalance([FromBody]AbsenceEntry absenceEntryDto)
        {
            return _absenceService.GetAbsBalance(absenceEntryDto);
        }
        /// <summary>
        /// 請假名單
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetPeopleAbs")]
        [HttpPost]
        public List<string> GetPeopleAbs([FromBody]AbsenceEntry absenceEntryDto)
        {
            return _absenceService.GetPeopleAbs(absenceEntryDto);
        }
        /// <summary>
        /// 取得假別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetHcode")]
        [HttpPost]
        public List<HcodeDto> GetHcode()
        {
            return _absenceService.GetHcode();
        }
    }
}