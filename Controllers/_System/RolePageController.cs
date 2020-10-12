using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dal._System.View;
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
    public class RolePageController : ControllerBase
    {
        private ISysRolePageService _sysRolePageService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysRolePageService">角色頁面權限</param>
        public RolePageController(ISysRolePageService sysRolePageService
            )
        {
            _sysRolePageService = sysRolePageService;
        }

        /// <summary>
        /// 取得角色頁面權限資料
        /// </summary>
        /// <param name="RoleCode">角色key</param>
        [Route("GetRolePageView")]
        [HttpGet]
        public List<SysRolePageDto> GetRolePageView(string RoleCode)
        {
            return _sysRolePageService.GetRolePageView(RoleCode);
        }

        /// <summary>
        /// 新增角色頁面權限資料
        /// </summary>
        [Route("InsertRolePage")]
        [HttpPost]
        public StatusResultDto InsertRolePage(SysRolePageDto sysRolePageDto)
        {
            return _sysRolePageService.InsertRolePageView(sysRolePageDto);
        }

        /// <summary>
        /// 刪除角色頁面權限資料
        /// </summary>
        [Route("DeleteRolePage")]
        [HttpDelete]
        public StatusResultDto DeleteRolePage(int id)
        {
            return _sysRolePageService.DeleteRolePageView(id);
        }
    }
}
