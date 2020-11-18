using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Employee.Normal;
using JBHRIS.Api.Dto.Employee.View;
using JBHRIS.Api.Service.Employee.Normal;
using JBHRIS.Api.Service.Employee.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_Api_Demo.Controllers
{
    /// <summary>
    /// 人事控制器
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeInfoService _employeeService;
        private IEmployeeListService _employeeListService;
        private IEmployeeViewService _employeeViewService;
        private IEmployeeRoleService _employeeRoleService;
        private ILogger _logger;

        //private IDeptViewService _deptViewService;
        //private IJobViewService _jobViewService;
        //private IOtherCodeViewService _otherCodeViewService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="employeeService">員工基本服務</param>
        /// <param name="employeeListService">員工清單服務</param>
        /// <param name="employeeViewService">員工檢視表服務</param>
        ///// <param name="deptViewService">部門檢視表服務</param>
        ///// <param name="jobViewService">職稱檢視表服務</param>
        public EmployeeController(IEmployeeInfoService employeeService
            , IEmployeeListService employeeListService
            , IEmployeeViewService employeeViewService,
           IEmployeeRoleService employeeRoleService,
           ILogger logger
            //, IDeptViewService deptViewService
            //, IJobViewService jobViewService
            //,IOtherCodeViewService otherCodeViewService
            )
        {
            _employeeService = employeeService;
            _employeeListService = employeeListService;
            _employeeViewService = employeeViewService;
            _employeeRoleService = employeeRoleService;
            _logger = logger;
            //_deptViewService = deptViewService;
            //_jobViewService = jobViewService;
            //_otherCodeViewService = otherCodeViewService;
        }
      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
        [HttpPost]
        [Route("GetPeopleByDept")]
        public ApiResult<List<string>> GetPeopleByDept(GetPeopleByDeptEntry getPeopleByDeptEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleByDept");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                var employeeList = _employeeRoleService.GetAllowEmloyeeList(User);
                apiResult.Result = _employeeListService.GetPeopleByDept(employeeList, getPeopleByDeptEntry.deptList, getPeopleByDeptEntry.checkDate);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得員工基本資料
        /// </summary>
        /// <param name="employeeList">工號清單</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetEmployeeInfo")]
        public ApiResult<List<EmployeeInfoDto>> GetEmployeeInfo(List<string> employeeList)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEmployeeInfo");
            ApiResult<List<EmployeeInfoDto>> apiResult = new ApiResult<List<EmployeeInfoDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetEmployeeInfo(employeeList);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得員工基本資料(前端)
        /// </summary>
        /// <remarks>
        /// ["A0003","A0017","A1423"]
        /// </remarks>
        /// <param name="employeeList">工號清單</param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetEmployeeInfoView")]
        public ApiResult<List<EmployeeInfoViewDto>> GetEmployeeInfoView(List<string> employeeList)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEmployeeInfoView");
            ApiResult<List<EmployeeInfoViewDto>> apiResult = new ApiResult<List<EmployeeInfoViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetEmployeeInfoView(employeeList);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得員工檢視表
        /// </summary>
        /// <param name="employeeList"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetEmployeeView")]
        public ApiResult<List<EmployeeViewDto>> GetEmployeeView(List<string> employeeList)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetEmployeeView");
            ApiResult<List<EmployeeViewDto>> apiResult = new ApiResult<List<EmployeeViewDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeViewService.GetEmployeeView(employeeList);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得生日名單
        /// </summary>
        /// <param name="employeeBirthdayEntry"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPeopleBirthday")]
        public ApiResult<List<string>> GetPeopleBirthday(EmployeeBirthdayEntry employeeBirthdayEntry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleBirthday");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeListService.GetPeopleByBirthday(employeeBirthdayEntry.employeeList, employeeBirthdayEntry.months);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 更新員工密碼
        /// </summary>
        /// <param name="password_Entry"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateEmployeePassword")]
        public ApiResult<bool> UpdateEmployeePassword(Password_Entry password_Entry)
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetPeopleBirthday");
            ApiResult<bool> apiResult = new ApiResult<bool>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.UpdateEmployeePassword(password_Entry.OldPWD, password_Entry.NewPWD);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 更新員工基本資料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateEmployeeInfo")]
        public ApiResult<bool> UpdateEmployeeInfo(UpdateEmployeeInfoViewDto empInfo)
        {
            _logger.Info("開始呼叫EmployeeInfoService.UpdateEmployeeInfo");
            ApiResult<bool> apiResult = new ApiResult<bool>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.UpdateEmployeeInfo(empInfo);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得親屬關係
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRelcodeView")]
        public ApiResult<List<RelcodeDto>> GetRelcodeView()
        {
            _logger.Info("開始呼叫EmployeeInfoService.GetRelcodeView");
            ApiResult<List<RelcodeDto>> apiResult = new ApiResult<List<RelcodeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _employeeService.GetRelcodeView();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        ///// <summary>
        ///// 取得編制部門
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("GetDept")]
        //public List<DeptDto> GetDept()
        //{
        //    return _deptViewService.GetDeptView();
        //}/// <summary>
        // /// 取得簽核部門
        // /// </summary>
        // /// <returns></returns>
        //[HttpPost]
        //[Route("GetDepta")]
        //public List<DeptDto> GetDepta()
        //{
        //    return _deptViewService.GetDeptaView();
        //}
        ///// <summary>
        ///// 取得成本部門
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("GetDepts")]
        //public List<DeptDto> GetDepts()
        //{
        //    return _deptViewService.GetDeptsView();
        //}
        ///// <summary>
        ///// 取得職稱
        ///// </summary>
        ///// <returns></returns>
        //[Authorize]
        //[HttpPost]
        //[Route("GetJob")]
        //public List<JobDto> GetJob()
        //{
        //    return _jobViewService.GetJob();
        //}
        ///// <summary>
        ///// 取得職級
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("GetJobs")]
        //public List<JobDto> GetJobs()
        //{
        //    return _jobViewService.GetJobs();
        //}
        ///// <summary>
        ///// 取得職等
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("GetJobl")]
        //public List<JobDto> GetJobl()
        //{
        //    return _jobViewService.GetJobl();
        //}
        ///// <summary>
        ///// 取得職系
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("GetJobo")]
        //public List<JobDto> GetJobo()
        //{
        //    return _jobViewService.GetJobo();
        //}
    }
    /// <summary>
    /// 取得部門名單-查詢條件
    /// </summary>
    public class EmployeeInfo_GetPeopleByDept_Entry
    {
        /// <summary>
        /// 部門清單
        /// </summary>
        public List<string> deptList { get; set; }
        /// <summary>
        /// 檢核日期
        /// </summary>
        public string CheckDate { get; set; }
    }
    public class Password_Entry
    {
        public string OldPWD { get; set; }
        public string NewPWD { get; set; }
    }
}