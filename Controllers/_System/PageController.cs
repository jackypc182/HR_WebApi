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
    public class PageController : ControllerBase
    {
        private ISystem_View_SysPage _sysPageService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysPageService">頁面</param>
        public PageController(ISystem_View_SysPage sysPageService
            )
        {
            _sysPageService = sysPageService;
        }

        /// <summary>
        /// 取得頁面資料
        /// </summary>
        /// <param name="PageCode">頁面key</param>
        [Route("GetPage")]
        [HttpGet]
        public ApiResult<List<SysPageDto>> GetPage(string PageCode)
        {
            return _sysPageService.GetPageView(PageCode);
        }

        /// <summary>
        /// 新增頁面
        /// </summary>
        [Route("InsertPage")]
        [HttpPost]
        public ApiResult<List<SysPageDto>> InsertPage(SysPageDto sysPage)
        {
            return _sysPageService.InsertPageView(sysPage);
        }

        /// <summary>
        /// 修改頁面
        /// </summary>
        /// <param name="sysPageDto">頁面key</param>
        [Route("UpdateRole")]
        [HttpPut]
        public ApiResult<List<SysPageDto>> UpdateRole(SysPageDto sysPageDto)
        {
            return _sysPageService.UpdatePageView(sysPageDto);
        }

        /// <summary>
        /// 刪除頁面
        /// </summary>
        [Route("DeletePage")]
        [HttpDelete]
        public ApiResult<List<SysPageDto>> DeletePage(string Code)
        {
            return _sysPageService.DeletePageView(Code);
        }
    }
}
