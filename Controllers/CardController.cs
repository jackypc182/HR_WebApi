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
    /// 刷卡服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        /// <summary>
        /// 取得刷卡資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetCard")]
        [HttpPost]
        public List<CardDto> GetCard(AttendanceEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得忘刷原因
        /// </summary>
        /// <returns></returns>
        [Route("GetCardReason")]
        [HttpPost]
        public List<CardReasonDto> GetCardReason()
        {
            throw new NotImplementedException();
        }
    }
}