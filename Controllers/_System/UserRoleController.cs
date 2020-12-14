using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Service._System.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

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
        private ILogger _logger;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysUserRoleViewService">角色資料</param>
        public UserRoleController(ISysUserRoleViewService sysUserRoleViewService,
           ILogger logger
            )
        {
            _sysUserRoleViewService = sysUserRoleViewService;
            _logger = logger;
        }

        /// <summary>
        /// 取得使用者角色資料
        /// </summary>
        /// <param name="nobr">員工號</param>
        /// <returns>使用者角色資料</returns>
        [Route("GetUserRole")]
        [HttpPost]
        [Authorize(Roles = "UserRole/GetUserRole,Admin")]
        public ApiResult<List<SysUserRoleDto>> GetUserRole(List<string> nobr)
        {
            _logger.Info("開始呼叫SysUserRoleViewService.GetUserRoleView");
            ApiResult<List<SysUserRoleDto>> apiResult = new ApiResult<List<SysUserRoleDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysUserRoleViewService.GetUserRoleView(nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 新增使用者角色資料
        /// </summary>
        [Route("InsertUserRole")]
        [HttpPost]
        [Authorize(Roles = "UserRole/InsertUserRole,Admin")]
        public ApiResult<string> InsertUserRole(SysUserRoleEntry sysUserRoleEntry)
        {
            _logger.Info("開始呼叫SysUserRoleViewService.InsertUserRole");
            return _sysUserRoleViewService.InsertUserRoleView(sysUserRoleEntry);
        }

        /// <summary>
        /// 刪除使用者角色資料
        /// </summary>
        /// <param name="id">Autokey</param>
        [Route("DeleteUserRole")]
        [HttpDelete]
        [Authorize(Roles = "UserRole/DeleteUserRole,Admin")]
        public ApiResult<string> DeleteUserRoleView(SysUserRoleEntry sysUserRoleEntry)
        {
            _logger.Info("開始呼叫SysUserRoleViewService.DeleteUserRoleView");
            return _sysUserRoleViewService.DeleteUserRoleView(sysUserRoleEntry);
        }
    }
}
