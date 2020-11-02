using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <remarks>
        /// update
        /// Sample request:
        ///{
        ///  "employeeList": [
        ///    "A1357","A0793"
        ///  ],
        ///  "attendTypeList": [
        ///    "AttendType_Attend","AttendType_Card","AttendType_Abs","AttendType_Ot","AttendType_Abnormal"
        ///  ],
        ///  "dateBegin": "2020-09-05",
        ///  "dateEnd": "2020-09-09"
        ///}
        /// </remarks>
        [Route("GetCalendar")]
        [HttpPost]
        public ApiResult<List<CalendarDto>> GetCalendar(AttendanceCalendarEntry attendanceCalendarEntry)   
        {
            return _attendanceService.GetCalendar(attendanceCalendarEntry);
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
        /// 出勤種類
        /// </summary>
        [Route("GetAttendType")]
        [HttpGet]
        public ApiResult<List<AttendanceTypeDto>> GetAttendType()
        {
            List<AttendanceTypeDto> attendanceTypes = new List<AttendanceTypeDto>() 
            {
                new AttendanceTypeDto(){Code = "AttendType_Attend", Name = "出勤",Sort = 1,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Card", Name = "刷卡",Sort = 2,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Abs", Name = "請假",Sort = 3,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Ot", Name = "加班",Sort = 4,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Abnormal", Name = "異常",Sort = 5,Display = true},
            };
            ApiResult<List<AttendanceTypeDto>> attendanceTypeResultDto = new ApiResult<List<AttendanceTypeDto>>();
            attendanceTypeResultDto.Result = attendanceTypes;
            attendanceTypeResultDto.State = true;

            return attendanceTypeResultDto;
        }

        /// <summary>
        /// 出勤明細表
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///{
        ///  "employeeList": [
        ///    "A1357","A0793"
        ///  ],
        ///  "attendTypeList": [],
        ///  "dateBegin": "2020-09-05",
        ///  "dateEnd": "2020-09-09"
        ///}
        /// </remarks>
        [Route("GetAttendDetail")]
        [HttpPost]
        public ApiResult<List<AttendanceDetailDto>> GetAttendDetail(AttendanceDetailEntry attendanceDetailEntry)
        {
            return _attendanceService.GetAttendDetail(attendanceDetailEntry);
        }
    }
}