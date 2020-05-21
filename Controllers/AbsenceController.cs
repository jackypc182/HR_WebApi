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
        public List<AbsenceTakenDto> GetAbsenceTaken(List<string> employeeList)
        {
            throw new NotImplementedException();
        }
        public List<AbsenceTakenDto> GetAbsenceTakenDept()
        {
            throw new NotImplementedException();
        }
        public List<AbsenceTakenDto> GetAbsenceTakenManage()
        {
            throw new NotImplementedException();
        }
        public List<AbsenceCancelDto> GetAbsenceCancel()
        {
            throw new NotImplementedException();
        }
        public List<AbsenceCancelDto> GetAbscManage()
        {
            throw new NotImplementedException();
        }
        public List<AbsenceBalanceDto> GetAbsBalance()
        {
            throw new NotImplementedException();
        }
        public List<AbsenceBalanceDto> GetAbsBalanceManage()
        {
            throw new NotImplementedException();
        }
        public List<string> GetPeopleAbs()
        {
            throw new NotImplementedException();
        }
    }
}