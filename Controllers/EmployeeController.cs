using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Service.Employee.Normal;
using JBHRIS.Api.Service.Employee.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Api_Demo.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeInfoService _employeeService;
        private IEmployeeListService _employeeListService;
        private IEmployeeViewService _employeeViewService;
        private IDeptViewService _deptViewService;
        private IJobViewService _jobViewService;

        public EmployeeController(IEmployeeInfoService employeeService
            , IEmployeeListService employeeListService
            , IEmployeeViewService employeeViewService
            , IDeptViewService deptViewService
            , IJobViewService jobViewService)
        {
            _employeeService = employeeService;
            _employeeListService = employeeListService;
            _employeeViewService = employeeViewService;
            _deptViewService = deptViewService;
            _jobViewService = jobViewService;
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
        [Route("GetEmployeeInfoByDeptWithMask")]
        public List<EmployeeInfoByDeptWithMaskDto> GetEmployeeInfoByDeptWithMask([FromBody]EmployeeInfo_GetPeopleByDept_Entry employeeInfo_GetPeopleByDept_Entry)
        {
            return _employeeService.GetEmployeeInfoByDeptWithMask(employeeInfo_GetPeopleByDept_Entry.deptList, Convert.ToDateTime(employeeInfo_GetPeopleByDept_Entry.CheckDate));
        }
        [HttpPost]
        [Route("GetPeopleByDept")]
        public List<string> GetPeopleByDept([FromBody]EmployeeInfo_GetPeopleByDept_Entry employeeInfo_GetPeopleByDept_Entry)
        {
            return _employeeListService.GetPeopleByDept(employeeInfo_GetPeopleByDept_Entry.deptList, Convert.ToDateTime(employeeInfo_GetPeopleByDept_Entry.CheckDate));
        }
        [HttpPost]
        [Route("GetEmployeeView")]
        public List<EmployeeViewDto> GetEmployeeView(List<string> employeeList)
        {
            return _employeeViewService.GetEmployeeView(employeeList);
        }
        [HttpPost]
        [Route("GetEmployeeByDeptView")]
        public List<EmployeeViewDto> GetEmployeeByDeptView(List<string> DeptList, DateTime CheckDate)
        {
            return _employeeViewService.GetEmployeeByDeptView(DeptList, CheckDate);
        }
        [HttpPost]
        [Route("GetEmployeeByManageView")]
        public List<EmployeeViewDto> GetEmployeeByManageView(List<string> DeptList, DateTime CheckDate, bool IncludeDown)
        {
            return _employeeViewService.GetEmployeeByManageView(DeptList, CheckDate, IncludeDown);
        }
        [HttpPost]
        [Route("UpdateEmployeePassword")]
        public bool UpdateEmployeePassword([FromBody]Password_Entry password_Entry)
        {
            return _employeeService.UpdateEmployeePassword(password_Entry.OldPWD, password_Entry.NewPWD);
        }
        [HttpPost]
        [Route("GetDept")]
        public List<DeptDto> GetDept()
        {
            return _deptViewService.GetDeptView();
        }
        [HttpPost]
        [Route("GetDepta")]
        public List<DeptDto> GetDepta()
        {
            return _deptViewService.GetDeptaView();
        }
        [HttpPost]
        [Route("GetDepts")]
        public List<DeptDto> GetDeptas()
        {
            return _deptViewService.GetDeptsView();
        }
        [HttpPost]
        [Route("GetJob")]
        public List<JobDto> GetJob()
        {
            return _jobViewService.GetJob();
        }
        [HttpPost]
        [Route("GetJobs")]
        public List<JobDto> GetJobs()
        {
            return _jobViewService.GetJobs();
        }
        [HttpPost]
        [Route("GetJobl")]
        public List<JobDto> GetJobl()
        {
            return _jobViewService.GetJobl();
        }
        [HttpPost]
        [Route("GetJobo")]
        public List<JobDto> GetJobo()
        {
            return _jobViewService.GetJobo();
        }
    }
    public class EmployeeInfo_GetPeopleByDept_Entry
    {
        public List<string> deptList { get; set; }
        public string CheckDate { get; set; }
    }
    public class Password_Entry
    {
        public string OldPWD { get; set; }
        public string NewPWD { get; set; }
    }
}