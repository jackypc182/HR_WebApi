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

namespace HR_WebApi.Controllers
{
    /// <summary>
    /// 請假服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private IAbsenceService _absenceService;

        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }
        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsenceTaken")]
        [HttpPost]
        public List<AbsenceTakenDto> GetAbsenceTaken([FromBody]AbsenceEntryDto absenceEntryDto)
        {
            return _absenceService.GetAbsenceTaken(absenceEntryDto);
        }
        /// <summary>
        /// 取得銷假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsenceCancel")]
        [HttpPost]
        public List<AbsenceCancelDto> GetAbsenceCancel([FromBody]AbsenceEntryDto absenceEntryDto)
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
        public List<AbsenceBalanceDto> GetAbsBalance([FromBody]AbsenceEntryDto absenceEntryDto)
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
        public List<string> GetPeopleAbs([FromBody]AbsenceEntryDto absenceEntryDto)
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