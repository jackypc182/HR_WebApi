using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

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
        private ILogger _logger;
        /// <summary>
        /// 加班控制器
        /// </summary>
        /// <param name="overtimeService">加班服務</param>
        /// <param name="logger"></param>
        public OvertimeController(IOvertimeService overtimeService,Logger logger)
        {
            _overtimeService = overtimeService ;
            _logger = logger;
        }
        /// <summary>
        /// 取得加班資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [Route("GetOvertime")]
        [HttpPost]
        public ApiResult<List<OvertimeDto>> GetOvertime(AttendanceEntry attendanceEntry)
        {
            _logger.Info("開始呼叫OvertimeService.GetOvertime");
            ApiResult<List<OvertimeDto>> apiResult = new ApiResult<List<OvertimeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _overtimeService.GetOvertime(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 加班名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetPeopleOvertime")]
        [HttpPost]
        public ApiResult<List<string>> GetPeopleOvertime(AttendanceEntry attendanceEntry)
        {
            _logger.Info("開始呼叫OvertimeService.GetPeopleOvertime");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _overtimeService.GetPeopleOvertime(attendanceEntry);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得加班類型?目前沒有
        /// </summary>
        /// <returns></returns>
        [Route("GetOvertimeType")]
        [HttpPost]
        public ApiResult<List<OvertimeTypeDto>> GetOvertimeType()
        {
            _logger.Info("開始呼叫OvertimeService.GetOvertimeType");
            ApiResult<List<OvertimeTypeDto>> apiResult = new ApiResult<List<OvertimeTypeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _overtimeService.GetOvertimeType();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得加班原因
        /// </summary>
        /// <returns></returns>
        [Route("GetOvertimeReason")]
        [HttpPost]
        public ApiResult<List<OvertimeReasonDto>> GetOvertimeReason()
        {
            _logger.Info("開始呼叫OvertimeService.GetOvertimeReason");
            ApiResult<List<OvertimeReasonDto>> apiResult = new ApiResult<List<OvertimeReasonDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _overtimeService.GetOvertimeReason();
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