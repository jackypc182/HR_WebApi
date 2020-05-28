using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        [Route("GetAbsenceTaken")]
        [HttpPost]
        public List<AbsenceTakenDto> GetAbsenceTaken(List<string> employeeList)
        {
            throw new NotImplementedException();
        }
        [Route("GetAbsenceTakenDept")]
        [HttpPost]
        public List<AbsenceTakenDto> GetAbsenceTakenDept()
        {
            throw new NotImplementedException();
        }
        [Route("GetAbsenceTakenManage")]
        [HttpPost]
        public List<AbsenceTakenDto> GetAbsenceTakenManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetAbsenceCancel")]
        [HttpPost]
        public List<AbsenceCancelDto> GetAbsenceCancel()
        {
            throw new NotImplementedException();
        }
        [Route("GetAbscManage")]
        [HttpPost]
        public List<AbsenceCancelDto> GetAbscManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetAbsBalance")]
        [HttpPost]
        public List<AbsenceBalanceDto> GetAbsBalance()
        {
            throw new NotImplementedException();
        }
        [Route("GetAbsBalanceManage")]
        [HttpPost]
        public List<AbsenceBalanceDto> GetAbsBalanceManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetPeopleAbs")]
        [HttpPost]
        public List<string> GetPeopleAbs()
        {
            throw new NotImplementedException();
        }
    }
}