﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Hangfire.Annotations;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Service.Menu.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuService _menuService;
        private ILogger _logger;
        public MenuController(IMenuService menuService, ILogger logger)
        {
            _menuService = menuService;
            _logger = logger;
        }
        /// <summary>
        /// 取得選單功能
        /// </summary>
        [Route("GetMenu")]
        [HttpGet]
        public ApiResult<List<SysMenuDto>> GetMenu(string code)
        {
            _logger.Info("開始呼叫MenuService.GetMenu");
            ApiResult<List<SysMenuDto>> apiResult = new ApiResult<List<SysMenuDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _menuService.GetMenu(code);
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
