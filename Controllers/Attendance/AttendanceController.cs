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
        public List<AttendanceCalendarDto> GetCalendar(AttendanceCalendarEntry attendanceCalendarEntry)   
        {
            List<AttendanceCalendarDto> attendanceCalendarDtos = new List<AttendanceCalendarDto>();
            List<CalendarDto> AttendData = new List<CalendarDto>();
            AttendData.Add(new CalendarDto()
            {
                
                CalendarDate = Convert.ToDateTime(attendanceCalendarEntry.DateBegin),
                CalendarType = "請假",
                Color = "0289ff",
                BeginTime = Convert.ToDateTime(attendanceCalendarEntry.DateBegin),
                EndTime = Convert.ToDateTime(attendanceCalendarEntry.DateBegin),
                EmployeeId = attendanceCalendarEntry.EmployeeList[0],
                Remark = null
            });
            attendanceCalendarDtos.Add(new AttendanceCalendarDto()
            {
                EmployeeId = attendanceCalendarEntry.EmployeeList[0],
                AttendData = AttendData,
                CalendarDate = Convert.ToDateTime(attendanceCalendarEntry.DateBegin),
                State = true
            });
            return attendanceCalendarDtos;
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


        /// <summary>
        /// 出勤明細表
        /// </summary>
        [Route("GetAttendDetail")]
        [HttpPost]
        public List<AttendanceDetailDto> GetAttendDetail(AttendanceDetailEntry attendanceDetailEntry)
        {
            List<AttendanceDetailDto> attendanceDetailDtos = new List<AttendanceDetailDto>();
            List<CalendarDto> AttendData = new List<CalendarDto>();
            AttendData.Add(new CalendarDto()
            {
                CalendarDate = Convert.ToDateTime(attendanceDetailEntry.DateBegin),
                CalendarType = "請假",
                Color = "0289ff",
                BeginTime = Convert.ToDateTime(attendanceDetailEntry.DateBegin),
                EndTime = Convert.ToDateTime(attendanceDetailEntry.DateBegin),
                EmployeeId = attendanceDetailEntry.EmployeeList[0],
                Remark = null
            });
            attendanceDetailDtos.Add(new AttendanceDetailDto()
            {
                EmployeeId = attendanceDetailEntry.EmployeeList[0],
                EmployeeName = "",
                AttendDate = attendanceDetailEntry.DateBegin,
                RoteCode = "0800A",
                RoteName = "常日班",
                RoteDateTimeB = DateTime.Now,
                RoteDateTimeE = Convert.ToDateTime(DateTime.Now.AddHours(8).ToString()),
                CardDateTimeB = DateTime.Now,
                CardDateTimeE = Convert.ToDateTime(DateTime.Now.AddHours(8).ToString()),
                AttendData = AttendData,
                State = true
            });
            return attendanceDetailDtos;
        }
    }
}