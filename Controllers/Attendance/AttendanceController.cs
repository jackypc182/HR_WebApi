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
using NLog;

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
        private ILogger _logger;

        public AttendanceController(IAttendanceService attendanceService, ILogger logger)
        {
            _attendanceService = attendanceService;
            _logger = logger;
        }
        /// <summary>
        /// 取得考勤資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetAttendance")]
        [HttpPost]
        public ApiResult<List<AttendanceDto>> GetAttendance(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetAttendance");
            ApiResult<List<AttendanceDto>> apiResult = new ApiResult<List<AttendanceDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetAttendance(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得行事曆資料(包含請假、加班、刷卡、班別資訊、異常資料)
        /// </summary>
        /// <remarks>
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
        public ApiResult<List<RoteChangeDto>> GetRoteChange(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetRoteChange");
            ApiResult<List<RoteChangeDto>> apiResult = new ApiResult<List<RoteChangeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetRoteChange(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得異常名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleAbnormal")]
        [HttpPost]
        public ApiResult<List<string>> GetPeopleAbnormal(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetPeopleAbnormal");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetPeopleAbnormal(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得工作名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleWork")]
        [HttpPost]
        public ApiResult<List<string>> GetPeopleWork(AttendanceRoteEntry attendanceEntry)
        {
            _logger.Info("開始呼叫AttendanceService.GetPeopleWork");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetPeopleWork(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        
        /// <summary>
        /// 取得班別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetRote")]
        [HttpPost]
        public ApiResult<List<RoteDto>> GetRote()
        {
            _logger.Info("開始呼叫AttendanceService.GetRote");
            ApiResult<List<RoteDto>> apiResult = new ApiResult<List<RoteDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _attendanceService.GetRote();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
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