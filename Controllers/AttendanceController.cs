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
        public List<AttendDto> GetAttend(List<string> employeeList,DateTime checkDate)
        {

        }
        public void GetAttendDept()
        {

        }
        public void GetAttendManage()
        {

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
        public void GetRotechg()
        {

        }
        public void GetRotechgManage()
        {

        }
        public void GetPeopleAbnormal()
        {

        }
        public void GetPeopleWork()
        {

        }

        public void GetHcode()
        {

        }
        public void GetRote()
        {

        }
        public void GetAttendCalendar()
        {

        }
    }
}