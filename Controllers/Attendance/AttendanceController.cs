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
    /// 考勤服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        /// <summary>
        /// 取得考勤資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetAttendance")]
        [HttpPost]
        public List<AttendanceDto> GetAttendance([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetAttendance(attendanceEntry);
        }
        /// <summary>
        /// 取得行事曆資料(包含請假、加班、刷卡、班別資訊、異常資料)
        /// </summary>
        [Route("GetCalendar")]
        [HttpPost]
        public void GetCalendar()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得調班資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetRoteChange")]
        [HttpPost]
        public List<RoteChangeDto> GetRoteChange([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetRoteChange(attendanceEntry);
        }
        /// <summary>
        /// 取得異常名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleAbnormal")]
        [HttpPost]
        public List<string> GetPeopleAbnormal([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetPeopleAbnormal(attendanceEntry);
        }
        /// <summary>
        /// 取得工作名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleWork")]
        [HttpPost]
        public List<string> GetPeopleWork([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetPeopleWork(attendanceEntry);
        }
        
        /// <summary>
        /// 取得班別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetRote")]
        [HttpPost]
        public List<RoteDto> GetRote()
        {
            return _attendanceService.GetRote();
        }
        /// <summary>
        /// 取得行事曆
        /// </summary>
        [Route("GetAttendCalendar")]
        [HttpPost]
        public void GetAttendCalendar()
        {
            throw new NotImplementedException();
        }
    }
}