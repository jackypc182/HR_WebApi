using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers
{
    /// <summary>
    /// 加班服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeController : ControllerBase
    {
        /// <summary>
        /// 取得加班資料
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        [Route("GetOvertime")]
        [HttpPost]
        public List<OvertimeDto> GetOvertime(List<string> employeeList,  DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 加班名單
        /// </summary>
        /// <param name="employeeList"></param>
        /// <param name="DateBegin"></param>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        [Route("GetPeopleOvertime")]
        [HttpPost]
        public List<string> GetPeopleOvertime(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得加班類型?目前沒有
        /// </summary>
        /// <returns></returns>
        [Route("GetOvertimeType")]
        [HttpPost]
        public List<OvertimeTypeDto> GetOvertimeType()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 取得加班原因
        /// </summary>
        /// <returns></returns>
        [Route("GetOvertimeReason")]
        [HttpPost]
        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            throw new NotImplementedException();
        }
    }
}