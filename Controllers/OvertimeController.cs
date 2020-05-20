using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OvertimeController : ControllerBase
    {
        public List<OvertimeDto> GetOvertime(List<string> employeeList,  DateTime DateBegin, DateTime DateEnd)
        {
            return new List<OvertimeDto>();
        }
        public List<OvertimeDto> GetOvertimeManage()
        {
            return new List<OvertimeDto>();
        }
        public List<string> GetPeopleOvertime(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            return new List<string>();
        }
        public List<OvertimeTypeDto> GetOvertimeType()
        {
            return new List<OvertimeTypeDto>();
        }
        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            return new List<OvertimeReasonDto>();
        }
    }
}