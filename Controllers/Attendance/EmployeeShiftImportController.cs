using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 員工匯入班表
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeShiftImportController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<EmployeeShiftImportDto> GetEmployeeShifts()
        {
            return new List<EmployeeShiftImportDto>();
        }

    }
}
