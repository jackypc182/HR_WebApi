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
    public class AttendanceController : ControllerBase
    {
        public List<AttendanceDto> GetAttendance(List<string> employeeList,DateTime DateBegin,DateTime DateEnd)
        {
            return new List<AttendanceDto>();
        }
        public List<AttendanceDto> GetAttendDept(List<string> roteList, DateTime DateBegin, DateTime DateEnd)
        {
            return new List<AttendanceDto>();
        }
        public List<AttendanceDto> GetAttendManage()
        {
            return new List<AttendanceDto>();
        }
        public void GetCalendar()
        {

        }
        public void GetCalendarDept()
        {

        }
        public void GetCalendarManage()
        {

        }
        public List<RoteChangeDto> GetRoteChange(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            return new List<RoteChangeDto>();
        }
        public List<RoteChangeDto> GetRotechangeManage()
        {
            return new List<RoteChangeDto>();
        }
        public void GetPeopleAbnormal()
        {

        }
        public void GetPeopleWork(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {

        }

        public List<HcodeDto> GetHcode()
        {
            return new List<HcodeDto>();
        }
        public List<RoteDto> GetRote()
        {
            return new List<RoteDto>();
        }
        public void GetAttendCalendar()
        {

        }
    }
}