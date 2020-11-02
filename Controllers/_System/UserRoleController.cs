using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Service._System.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers._System
{
    /// <summary>
    /// 權限控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private ISysUserRoleViewService _sysUserRoleViewService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysUserRoleViewService">角色資料</param>
        public UserRoleController(ISysUserRoleViewService sysUserRoleViewService
            )
        {
            _sysUserRoleViewService = sysUserRoleViewService;
        }

        /// <summary>
        /// 取得使用者角色資料
        /// </summary>
        /// <param name="nobr">員工號</param>
        /// <returns>使用者角色資料</returns>
        [Route("GetUserRole")]
        [HttpGet]
        public ApiResult<List<SysUserRoleDto>> GetUserRole(string nobr)
        {
            return _sysUserRoleViewService.GetUserRoleView(nobr);
        }

        /// <summary>
        /// 新增使用者角色資料
        /// </summary>
        [Route("InsertUserRole")]
        [HttpPost]
        public ApiResult<List<SysUserRoleDto>> InsertUserRole(SysUserRoleDto sysUserRoleDto)
        {
            return _sysUserRoleViewService.InsertUserRoleView(sysUserRoleDto);
        }

        /// <summary>
        /// 刪除使用者角色資料
        /// </summary>
        /// <param name="id">Autokey</param>
        [Route("DeleteUserRole")]
        [HttpDelete]
        public ApiResult<List<SysUserRoleDto>> DeleteUserRoleView(int id)
        {
            return _sysUserRoleViewService.DeleteUserRoleView(id);
        }
    }
}
