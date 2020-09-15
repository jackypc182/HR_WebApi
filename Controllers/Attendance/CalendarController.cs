using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 行事曆
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        /// <summary>
        /// 取得行事曆資料
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="dateBegin"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public List<CalendarDto> GetCalendars([FromBody] List<string> employeeList,DateTime dateBegin,DateTime dateEnd)
        {
            return new List<CalendarDto>();
        }
    }
}
