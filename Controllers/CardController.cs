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
    public class CardController : ControllerBase
    {
        public List<CardDto> GetCard(List<string> employeeList,DateTime DateBegin,DateTime DateEnd)
        {
            return new List<CardDto>();
        }
        public List<CardDto> GetCardManage()
        {
            return new List<CardDto>();
        }
        public List<CardReasonDto> GetCardReason()
        {
            return new List<CardReasonDto>();
        }
    }
}