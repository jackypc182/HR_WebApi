using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Attendance.View
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/View/[controller]")]
    [ApiController]
    public class AbsenceViewController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public AbsenceViewController()
        {

        }
        /// <summary>
        /// 得假查詢\
        /// </summary>
        /// <param name="abseneceEntitleViewEntry"></param>
        /// <returns></returns>
        [HttpPost("GetAbsenceEntitleView")]
        public ApiResult<List<AbsenceEntitleViewDto>> GetAbsenceEntitleView(AbseneceEntitleViewEntry  abseneceEntitleViewEntry)
        {
            ApiResult<List<AbsenceEntitleViewDto>> result = new ApiResult<List<AbsenceEntitleViewDto>>();
            return result;
        }
        /// <summary>
        /// 請假查詢
        /// </summary>
        /// <param name="abseneceTakenViewEntry"></param>
        /// <returns></returns>
        [HttpPost("GetAbsenceTakenView")]
        public ApiResult<List<AbsenceTakenViewDto>> GetAbsenceTakenView(AbsenceTakenViewEntry abseneceTakenViewEntry)
        {
            ApiResult<List<AbsenceTakenViewDto>> result = new ApiResult<List<AbsenceTakenViewDto>>();
            return result;
        }
    }
}
