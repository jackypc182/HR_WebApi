using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dal._System.View;
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
    public class RolePageController : ControllerBase
    {
        private ISysRolePageService _sysRolePageService;
        private ILogger _logger;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysRolePageService">角色頁面權限</param>
        public RolePageController(ISysRolePageService sysRolePageService,
           ILogger logger
            )
        {
            _sysRolePageService = sysRolePageService;
            _logger = logger;
        }

        /// <summary>
        /// 新增角色頁面權限資料
        /// </summary>
        [Route("InsertRolePage")]
        [HttpPost]
        [Authorize(Roles = "RolePage/InsertRolePage,Admin")]
        public ApiResult<string> InsertRolePage(SysRolePageEntry sysRolePageEntry)
        {
            _logger.Info("開始呼叫SysRolePageService.InsertRolePageView");
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            return _sysRolePageService.InsertRolePageView(sysRolePageEntry, KeyMan);
        }

        /// <summary>
        /// 刪除角色頁面權限資料
        /// </summary>
        [Route("DeleteRolePage")]
        [HttpDelete]
        [Authorize(Roles = "RolePage/DeleteRolePage,Admin")]
        public ApiResult<string> DeleteRolePage(SysRolePageEntry sysRolePageEntry)
        {
            _logger.Info("開始呼叫SysRolePageService.DeleteRolePageView");
            return _sysRolePageService.DeleteRolePageView(sysRolePageEntry);
        }

        /// <summary>
        /// 取得所有角色擁有的頁面權限
        /// </summary>
        [Route("GetRoleToPageView")]
        [HttpGet]
        [Authorize(Roles = "RolePage/GetRoleToPageView,Admin")]
        public ApiResult<List<SysRoleToPageDto>> GetRoleToPageView()
        {
            _logger.Info("開始呼叫SysRolePageService.GetRoleToPageView");
            ApiResult<List<SysRoleToPageDto>> apiResult = new ApiResult<List<SysRoleToPageDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysRolePageService.GetRoleToPageView();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得所有頁面包含角色
        /// </summary>
        [Route("GetPageToRoleView")]
        [HttpGet]
        [Authorize(Roles = "RolePage/GetPageToRoleView,Admin")]
        public ApiResult<List<SysPageToRoleDto>> GetPageToRoleView()
        {
            _logger.Info("開始呼叫SysRolePageService.GetPageToRoleView");
            ApiResult<List<SysPageToRoleDto>> apiResult = new ApiResult<List<SysPageToRoleDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysRolePageService.GetPageToRoleView();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
    }
}
