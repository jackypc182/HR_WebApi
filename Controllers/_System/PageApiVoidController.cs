using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dal._System.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.Entry;
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
    public class PageApiVoidController : ControllerBase
    {
        private ISysPageApiVoidService _sysPageApiVoidService;
        private ILogger _logger;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysPageApiVoidService">頁面權限</param>
        public PageApiVoidController(ISysPageApiVoidService sysPageApiVoidService,
            ILogger logger
            )
        {
            _sysPageApiVoidService = sysPageApiVoidService;
            _logger = logger;
        }

        /// <summary>
        /// 取得頁面包含api權限
        /// </summary>
        [Route("GetPageToApiVoidView")]
        [HttpGet]
        public ApiResult<List<SysPageToApiVoidDto>> GetPageToApiVoidView()
        {
            _logger.Info("開始呼叫SysPageApiVoidService.GetPageToApiVoidView");
            ApiResult<List<SysPageToApiVoidDto>> apiResult = new ApiResult<List<SysPageToApiVoidDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysPageApiVoidService.GetPageToApiVoidView();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 新增頁面權限資料
        /// </summary>
        [Route("InsertPageApiVoid")]
        [HttpPost]
        public ApiResult<string> InsertPageApiVoid(SysPageApiVoidEntry sysPageApiVoidEntry)
        {
            _logger.Info("開始呼叫SysPageApiVoidService.InsertPageApiVoid");
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            return _sysPageApiVoidService.InsertPageApiVoidView(sysPageApiVoidEntry, KeyMan);
        }

        /// <summary>
        /// 刪除頁面權限資料
        /// </summary>
        [Route("DeleteRole")]
        [HttpDelete]
        public ApiResult<string> DeletePageApiVoid(SysPageApiVoidEntry sysPageApiVoidEntry)
        {
            _logger.Info("開始呼叫SysPageApiVoidService.DeletePageApiVoid");
            return _sysPageApiVoidService.DeletePageApiVoidView(sysPageApiVoidEntry);
        }
    }
}
