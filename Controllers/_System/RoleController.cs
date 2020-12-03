using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Service._System.View;
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
    public class RoleController : ControllerBase
    {
        private ISysRoleViewService _sysRoleViewService;
        private ILogger _logger;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysRoleViewService">角色資料</param>
        public RoleController(ISysRoleViewService sysRoleViewService,
            ILogger logger
            )
        {
            _logger = logger;
            _sysRoleViewService = sysRoleViewService;
        }

        /// <summary>
        /// 取得角色資料
        /// </summary>
        /// <returns>角色清單</returns>
        [Route("GetRole")]
        [HttpGet]
        public ApiResult<List<SysRoleDto>> GetRole()
        {
            _logger.Info("開始呼叫SysRoleViewService.GetRole");
            ApiResult<List<SysRoleDto>> apiResult = new ApiResult<List<SysRoleDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysRoleViewService.GetRoleView();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 新增角色資料
        /// </summary>
        /// <remarks>
        ///     {
        ///        "code": "test",
        ///        "name": "測試角色",
        ///        "isAdminRole": true,
        ///        "isVisible": true
        ///     }
        ///
        /// </remarks>
        [Route("InsertRole")]
        [HttpPost]
        public ApiResult<List<SysRoleDto>> InsertRole(SysRoleDto sysRoleDto)
        {
            _logger.Info("開始呼叫SysRoleViewService.InsertRole");
            return _sysRoleViewService.InsertRoleView(sysRoleDto);
        }

        /// <summary>
        /// 修改角色資料
        /// </summary>
        /// <param name="sysRoleDto">角色key</param>
        [Route("UpdateRole")]
        [HttpPut]
        public ApiResult<List<SysRoleDto>> UpdateRole(SysRoleDto sysRoleDto)
        {
            _logger.Info("開始呼叫SysRoleViewService.UpdateRole");
            return _sysRoleViewService.UpdateRoleView(sysRoleDto);
        }

        /// <summary>
        /// 刪除角色資料
        /// </summary>
        /// <param name="Code">角色key</param>
        [Route("DeleteRole")]
        [HttpDelete]
        public ApiResult<List<SysRoleDto>> DeleteRole(string Code)
        {
            _logger.Info("開始呼叫SysRoleViewService.DeleteRole");
            return _sysRoleViewService.DeleteRoleView(Code);
        }
    }
}
