using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 加班服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeController : ControllerBase
    {
        private IOvertimeService _overtimeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="overtimeService"></param>
        public OvertimeController(IOvertimeService overtimeService)
        {
            _overtimeService = overtimeService ;
        }
        /// <summary>
        /// 取得加班資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetOvertime")]
        [HttpPost]
        public List<OvertimeDto> GetOvertime([FromBody]AttendanceEntry attendanceEntry)
        {
            return _overtimeService.GetOvertime(attendanceEntry);
        }
        /// <summary>
        /// 加班名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetPeopleOvertime")]
        [HttpPost]
        public List<string> GetPeopleOvertime([FromBody]AttendanceEntry attendanceEntry)
        {
            return _overtimeService.GetPeopleOvertime(attendanceEntry);
        }
        /// <summary>
        /// 取得加班類型?目前沒有
        /// </summary>
        /// <returns></returns>
        [Route("GetOvertimeType")]
        [HttpPost]
        public List<OvertimeTypeDto> GetOvertimeType()
        {
            return _overtimeService.GetOvertimeType();
        }
        /// <summary>
        /// 取得加班原因
        /// </summary>
        /// <returns></returns>
        [Route("GetOvertimeReason")]
        [HttpPost]
        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            return _overtimeService.GetOvertimeReason();
        }
    }
}