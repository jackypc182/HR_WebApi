using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
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
        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsenceTaken")]
        [HttpPost]
        public List<AbsenceTakenDto> GetAbsenceTaken(AbsenceEntryDto absenceEntryDto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得銷假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsenceCancel")]
        [HttpPost]
        public List<AbsenceCancelDto> GetAbsenceCancel(AbsenceEntryDto absenceEntryDto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得剩餘時數
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsBalance")]
        [HttpPost]
        public List<AbsenceBalanceDto> GetAbsBalance(AbsenceEntryDto absenceEntryDto)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 請假名單
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetPeopleAbs")]
        [HttpPost]
        public List<string> GetPeopleAbs(AbsenceEntryDto absenceEntryDto)
        {
            throw new NotImplementedException();
        }
    }
}