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
    public class PageApiVoidController : ControllerBase
    {
        private ISysPageApiVoidService _sysPageApiVoidService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysPageApiVoidService">頁面權限</param>
        public PageApiVoidController(ISysPageApiVoidService sysPageApiVoidService
            )
        {
            _sysPageApiVoidService = sysPageApiVoidService;
        }

        /// <summary>
        /// 取得頁面權限資料
        /// </summary>
        /// <param name="PageCode">頁面key</param>
        [Route("GetPageApiVoidView")]
        [HttpGet]
        public List<SysPageApiVoidDto> GetPageApiVoidView(string PageCode)
        {
            return _sysPageApiVoidService.GetPageApiVoidView(PageCode);
        }

        /// <summary>
        /// 新增頁面權限資料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///  POST /Todo
        ///  {
        ///    "pageCode": "string",
        ///    "apiVoidCode": "string",
        ///    "keyDate": "2020-10-08T04:35:37.469Z",
        ///    "keyName": "string"
        ///  }
        ///
        /// </remarks>
        [Route("InsertPageApiVoid")]
        [HttpPost]
        public StatusResultDto InsertPageApiVoid(SysPageApiVoidDto sysPageApiVoidDto)
        {
            return _sysPageApiVoidService.InsertPageApiVoidView(sysPageApiVoidDto);
        }

        /// <summary>
        /// 刪除頁面權限資料
        /// </summary>
        [Route("DeleteRole")]
        [HttpDelete]
        public StatusResultDto DeletePageApiVoid(int id)
        {
            return _sysPageApiVoidService.DeletePageApiVoidView(id);
        }
    }
}
