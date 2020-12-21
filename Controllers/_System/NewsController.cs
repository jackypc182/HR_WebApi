using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Service._System.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers._System
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private ISysNewsService _sysNewsService;
        private ILogger _logger;

        public  NewsController(ILogger logger, ISysNewsService sysNewsService)
        {
            _sysNewsService = sysNewsService;
            _logger = logger;
        }

        /// <summary>
        /// 取得公佈欄
        /// </summary>
        [Route("GetNews")]
        [HttpGet]
        [Authorize(Roles = "News/GetNews,Admin")]
        public ApiResult<List<NewsDto>> GetNews()
        {
            _logger.Info("開始呼叫SysNewsService.GetNews");
            ApiResult<List<NewsDto>> apiResult = new ApiResult<List<NewsDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysNewsService.GetNews();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得公佈欄詳細
        /// </summary>
        [Route("GetNewsById")]
        [HttpGet]
        [Authorize(Roles = "News/GetNewsById,Admin")]
        public ApiResult<NewsDto> GetNewsById(string id)
        {
            _logger.Info("開始呼叫SysNewsService.GetNewsById");
            ApiResult<NewsDto> apiResult = new ApiResult<NewsDto>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysNewsService.GetNewsById(id);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 新增公佈欄
        /// </summary>
        [Route("InsertNews")]
        [HttpPost]
        [Authorize(Roles = "News/InsertNews,Admin")]
        public ApiResult<string> InsertNews(NewsDto newsDto)
        {
            _logger.Info("開始呼叫SysNewsService.InsertNews");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                apiResult.State = _sysNewsService.InsertNews(newsDto, KeyMan);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 修改公佈欄
        /// </summary>
        [Route("UpdateNews")]
        [HttpPut]
        [Authorize(Roles = "News/UpdateNews,Admin")]
        public ApiResult<string> UpdateNews(NewsDto newsDto)
        {
            _logger.Info("開始呼叫SysNewsService.UpdateNews");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var KeyMan = User.Identity.Name;
                if (KeyMan == null) KeyMan = "";
                apiResult.State = _sysNewsService.UpdateNews(newsDto, KeyMan);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 刪除公佈欄
        /// </summary>
        [Route("DeleteNewsById")]
        [HttpDelete]
        [Authorize(Roles = "News/DeleteNewsById,Admin")]
        public ApiResult<string> DeleteNewsById(string id)
        {
            _logger.Info("開始呼叫SysNewsService.DeleteNewsById");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult.State = _sysNewsService.DeleteNewsById(id);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
    }
}
