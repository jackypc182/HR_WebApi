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

namespace JBHRIS.Api.Attendance
{
    /// <summary>
    /// 調班服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoteChangeController : ControllerBase
    {
        private IRoteChangeService _roteChangeService;
        private ILogger _logger;

        /// <summary>
        /// 調班控制器
        /// </summary>
        /// <param name="roteChangeService">調班服務</param>
        public RoteChangeController (IRoteChangeService roteChangeService, ILogger logger)
        {
            _roteChangeService = roteChangeService;
            _logger = logger;
        }

        /// <summary>
        /// 取得刷卡資料
        /// </summary>
        /// <param name="attendacneEntry"></param>
        /// <returns></returns>
        [Route("GetRoteChange")]
        [HttpPost]
        public ApiResult<List<RoteChangeDto>> GetRoteChange(AttendanceEntry attendacneEntry)
        {
            _logger.Info("開始呼叫RoteChangeService.GetRoteChange");
            ApiResult<List<RoteChangeDto>> apiResult = new ApiResult<List<RoteChangeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _roteChangeService.GetRoteChange(attendacneEntry);
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
