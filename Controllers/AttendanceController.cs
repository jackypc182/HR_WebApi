using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers
{
    /// <summary>
    /// 考勤服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        /// <summary>
        /// 取得考勤資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetAttendance")]
        [HttpPost]
        public List<AttendanceDto> GetAttendance(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
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
        public List<RoteChangeDto> GetRoteChange(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得異常名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleAbnormal")]
        [HttpPost]
        public void GetPeopleAbnormal(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得工作名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleWork")]
        [HttpPost]
        public void GetPeopleWork(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得假別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetHcode")]
        [HttpPost]
        public List<HcodeDto> GetHcode()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得班別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetRote")]
        [HttpPost]
        public List<RoteDto> GetRote()
        {
            throw new NotImplementedException();
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