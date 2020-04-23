using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Salary.Payroll;
using JBHRIS.Api.Service.Salary.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HR_Api_Demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private ISalaryCalculationService _salaryCalculationService;

        public SalaryController(ISalaryCalculationService salaryCalculationService)
        {
            _salaryCalculationService = salaryCalculationService;
        }
        [HttpGet]
        public SalaryCalculationResult Calculate()
        {
            var result = _salaryCalculationService.Calculate(new JBHRIS.Api.Dto.Salary.Payroll.SalaryCalculationEntry { ModuleTypes=new List<string> {"Test" } });
            return result;
        }
    }
}