using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Home;
using JBHRIS.Api.Home;
using JBHRIS.Api.Service._System.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;


namespace HR_WebApi.Controllers.Home
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BillBoardController : ControllerBase
    {
        ISysNewsService _sysNewsService;
        ILogger _logger;

        public BillBoardController(ISysNewsService sysNewsService, ILogger logger) 
        {
            _logger = logger;
            _sysNewsService = sysNewsService;
        }

        /// <summary>
        /// 取得公佈欄(員工)
        /// </summary>
        /// <returns></returns>
        [Route("GetBillboards")]
        [HttpPost]
        [Authorize(Roles = "BillBoard/GetBillboards,Admin")]
        public ApiResult<List<BillboardDto>> GetBillboards()
        {
            _logger.Info("開始呼叫SysNewsService.GetBillboards");
            ApiResult<List<BillboardDto>> apiResult = new ApiResult<List<BillboardDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysNewsService.GetBillboards();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得公佈欄詳細(員工)
        /// </summary>
        /// <returns></returns>
        [Route("GetBillboardsById")]
        [HttpPost]
        [Authorize(Roles = "BillBoard/GetBillboardsById,Admin")]
        public ApiResult<BillboardDetailDto> GetBillboardsById(string id)
        {
            _logger.Info("開始呼叫SysNewsService.GetBillboardsById");
            ApiResult<BillboardDetailDto> apiResult = new ApiResult<BillboardDetailDto>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysNewsService.GetBillboardsById(id);
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
