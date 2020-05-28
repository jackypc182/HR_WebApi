using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers
{
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
        [Route("GetOvertimeManage")]
        [HttpPost]
        public List<OvertimeDto> GetOvertimeManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetPeopleOvertime")]
        [HttpPost]
        public List<string> GetPeopleOvertime(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        [Route("GetOvertimeType")]
        [HttpPost]
        public List<OvertimeTypeDto> GetOvertimeType()
        {
            throw new NotImplementedException();
        }
        [Route("GetOvertimeReason")]
        [HttpPost]
        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            throw new NotImplementedException();
        }
    }
}