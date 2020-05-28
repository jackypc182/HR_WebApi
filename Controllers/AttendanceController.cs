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
    public class AttendanceController : ControllerBase
    {
        [Route("GetAttendance")]
        [HttpPost]
        public List<AttendanceDto> GetAttendance(List<string> employeeList,DateTime DateBegin,DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        [Route("GetAttendDept")]
        [HttpPost]
        public List<AttendanceDto> GetAttendDept(List<string> roteList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        [Route("GetAttendManage")]
        [HttpPost]
        public List<AttendanceDto> GetAttendManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetCalendar")]
        [HttpPost]
        public void GetCalendar()
        {
            throw new NotImplementedException();
        }
        [Route("GetCalendarDept")]
        [HttpPost]
        public void GetCalendarDept()
        {
            throw new NotImplementedException();
        }
        [Route("GetCalendarManage")]
        [HttpPost]
        public void GetCalendarManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetRoteChange")]
        [HttpPost]
        public List<RoteChangeDto> GetRoteChange(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        [Route("GetRotechangeManage")]
        [HttpPost]
        public List<RoteChangeDto> GetRotechangeManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetPeopleAbnormal")]
        [HttpPost]
        public void GetPeopleAbnormal()
        {
            throw new NotImplementedException();
        }
        [Route("GetPeopleWork")]
        [HttpPost]
        public void GetPeopleWork(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }

        [Route("GetHcode")]
        [HttpPost]
        public List<HcodeDto> GetHcode()
        {
            throw new NotImplementedException();
        }
        [Route("GetRote")]
        [HttpPost]
        public List<RoteDto> GetRote()
        {
            throw new NotImplementedException();
        }
        [Route("GetAttendCalendar")]
        [HttpPost]
        public void GetAttendCalendar()
        {
            throw new NotImplementedException();
        }
    }
}