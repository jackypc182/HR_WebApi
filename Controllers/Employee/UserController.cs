using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Employee
{
    /// <summary>
    /// 使用者控制器
    /// </summary>
    [Authorize]
    [Route("api/Employee/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            string EmpId = User.Claims.FirstOrDefault(p=>p.Type.Contains("name")).Value;
            return EmpId;
        }
        /// <summary>
        /// 更新使用者資料
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public string Update()
        {
            return "";
        }
    }
}
