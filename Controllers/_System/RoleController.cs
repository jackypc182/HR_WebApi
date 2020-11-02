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
    public class RoleController : ControllerBase
    {
        private ISysRoleViewService _sysRoleViewService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysRoleViewService">角色資料</param>
        public RoleController(ISysRoleViewService sysRoleViewService
            )
        {
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
            return _sysRoleViewService.GetRoleView();
        }

        /// <summary>
        /// 新增角色資料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
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
            return _sysRoleViewService.DeleteRoleView(Code);
        }
    }
}
