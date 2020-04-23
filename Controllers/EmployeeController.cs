using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Service.Employee.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api_Demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeInfoService _employeeService;
        private IEmployeeListService _employeeListService;

        public EmployeeController(IEmployeeInfoService employeeService,IEmployeeListService employeeListService)
        {
            _employeeService = employeeService;
            _employeeListService = employeeListService;
        }
        [HttpPost]
        [Route("GetEmployeeInfo")]
        public List<EmployeeInfoDto> GetEmployeeInfo(List<string> employeeList)
        {
            return _employeeService.GetEmployeeInfo(employeeList);
        }
        [HttpPost]
        [Route("GetEmployeeInfoByDept")]
        public List<EmployeeInfoDto> GetEmployeeInfoByDept([FromBody]EmployeeInfo_GetPeopleByDept_Entry employeeInfo_GetPeopleByDept_Entry)
        {
            return _employeeService.GetEmployeeInfoByDept(employeeInfo_GetPeopleByDept_Entry.deptList, Convert.ToDateTime(employeeInfo_GetPeopleByDept_Entry.CheckDate));
        }
        [HttpPost]
        [Route("GetPeopleByDept")]
        public List<string> GetPeopleByDept([FromBody]EmployeeInfo_GetPeopleByDept_Entry employeeInfo_GetPeopleByDept_Entry)
        {
            return _employeeListService.GetPeopleByDept(employeeInfo_GetPeopleByDept_Entry.deptList, Convert.ToDateTime(employeeInfo_GetPeopleByDept_Entry.CheckDate));
        }
    }
    public class EmployeeInfo_GetPeopleByDept_Entry
    {
        public List<string> deptList { get; set; }
        public string CheckDate { get; set; }
    }
}