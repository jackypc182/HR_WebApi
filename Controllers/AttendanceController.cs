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
        public List<AttendanceDto> GetAttendance(List<string> employeeList,DateTime DateBegin,DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        public List<AttendanceDto> GetAttendDept(List<string> roteList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        public List<AttendanceDto> GetAttendManage()
        {
            throw new NotImplementedException();
        }
        public void GetCalendar()
        {
            throw new NotImplementedException();
        }
        public void GetCalendarDept()
        {
            throw new NotImplementedException();
        }
        public void GetCalendarManage()
        {
            throw new NotImplementedException();
        }
        public List<RoteChangeDto> GetRoteChange(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        public List<RoteChangeDto> GetRotechangeManage()
        {
            throw new NotImplementedException();
        }
        public void GetPeopleAbnormal()
        {
            throw new NotImplementedException();
        }
        public void GetPeopleWork(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            throw new NotImplementedException();
        }

        public List<HcodeDto> GetHcode()
        {
            throw new NotImplementedException();
        }
        public List<RoteDto> GetRote()
        {
            throw new NotImplementedException();
        }
        public void GetAttendCalendar()
        {
            throw new NotImplementedException();
        }
    }
}