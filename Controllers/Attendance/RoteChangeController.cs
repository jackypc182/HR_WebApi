using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// 調班控制器
        /// </summary>
        /// <param name="roteChangeService">調班服務</param>
        public RoteChangeController (IRoteChangeService roteChangeService)
        {
            _roteChangeService = roteChangeService;
        }

        /// <summary>
        /// 取得刷卡資料
        /// </summary>
        /// <param name="attendacneEntry"></param>
        /// <returns></returns>
        [Route("GetRoteChange")]
        [HttpPost]
        public List<RoteChangeDto> GetRoteChange(AttendanceEntry attendacneEntry)
        {
            return _roteChangeService.GetRoteChange(attendacneEntry);
        }
    }
}
