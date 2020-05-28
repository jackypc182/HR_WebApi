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
    public class CardController : ControllerBase
    {
        [Route("GetCard")]
        [HttpPost]
        public List<CardDto> GetCard(List<string> employeeList,DateTime DateBegin,DateTime DateEnd)
        {
            throw new NotImplementedException();
        }
        [Route("GetCardManage")]
        [HttpPost]
        public List<CardDto> GetCardManage()
        {
            throw new NotImplementedException();
        }
        [Route("GetCardReason")]
        [HttpPost]
        public List<CardReasonDto> GetCardReason()
        {
            throw new NotImplementedException();
        }
    }
}