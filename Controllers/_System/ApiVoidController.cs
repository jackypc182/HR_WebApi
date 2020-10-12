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
using NLog;

namespace HR_WebApi.Controllers._System
{
    /// <summary>
    /// 權限控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVoidController : ControllerBase
    {
        private ISysApiVoidService _sysApiVoidService;
        private ILogger _logger;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysApiVoidService">方法資料</param>
        public ApiVoidController(ISysApiVoidService sysApiVoidService, ILogger logger)
        {
            _sysApiVoidService = sysApiVoidService;
            _logger = logger;
        }

        /// <summary>
        /// 取得頁面權限資料
        /// </summary>
        /// <param name="voidName">方法名稱</param>
        [Route("GetApiVoid")]
        [HttpGet]
        public List<SysApiVoidDto> GetApiVoidView(string voidName)
        {
            _logger.Info("開始呼叫SysApiVoidService.GetApiVoidView");
            return _sysApiVoidService.GetApiVoidView(voidName);
        }

        /// <summary>
        /// 新增方法資料
        /// </summary>
        [Route("InsertApiVoid")]
        [HttpPost]
        public StatusResultDto InsertApiVoidView(SysApiVoidDto sysApiVoidDto)
        {
            return _sysApiVoidService.InsertApiVoidView(sysApiVoidDto);
        }

        /// <summary>
        /// 更新方法資料
        /// </summary>
        [Route("UpdateApiVoid")]
        [HttpPut]
        public StatusResultDto UpdateApiVoidView(SysApiVoidDto sysApiVoidDto)
        {
            return _sysApiVoidService.UpdateApiVoidView(sysApiVoidDto);
        }

        /// <summary>
        /// 刪除方法資料
        /// </summary>
        [Route("DeleteApiVoid")]
        [HttpDelete]
        public StatusResultDto DeleteApiVoidView(int id)
        {
            return _sysApiVoidService.DeleteApiVoidView(id);
        }
    }
}
