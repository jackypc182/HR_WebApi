using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Home
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BillBoardController : ControllerBase
    {
        /// <summary>
        /// 取得公佈欄
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public ApiResult<List<BillboardDto>> GetBillboards()
        {
            return new ApiResult<List<BillboardDto>>();
        }
        /// <summary>
        /// 新增公佈欄
        /// </summary>
        /// <param name="billboardDto"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public ApiResult<BillboardResultDto> AddBillboard([FromBody] BillboardDto billboardDto)
        {
            return new ApiResult<BillboardResultDto>();
        }
        /// <summary>
        /// 更新公佈欄
        /// </summary>
        /// <param name="billboardDto"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPut]
        public ApiResult<BillboardResultDto> UpdateBillboard([FromBody] BillboardDto billboardDto)
        {
            return new ApiResult<BillboardResultDto>();
        }
        /// <summary>
        /// 刪除公佈欄
        /// </summary>
        /// <param name="billboardDto"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public ApiResult<BillboardResultDto>  DeleteBillboard([FromBody] BillboardDto billboardDto)
        {
            return new ApiResult<BillboardResultDto>();
        }
    }
}
