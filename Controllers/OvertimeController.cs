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
        public List<OvertimeDto> GetOvertime(List<string> employeeList,  DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        public List<OvertimeDto> GetOvertimeManage()
        {
            throw new NotImplementedException();
        }
        public List<string> GetPeopleOvertime(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        public List<OvertimeTypeDto> GetOvertimeType()
        {
            throw new NotImplementedException();
        }
        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            throw new NotImplementedException();
        }
    }
}