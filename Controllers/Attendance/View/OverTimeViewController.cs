using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HR_WebApi.Controllers.Attendance.View
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/View/[controller]")]
    [ApiController]
    public class OverTimeViewController
    {

        IOverTimeViewService _overTimeViewService;
        public OverTimeViewController(IOverTimeViewService overTimeViewService)
        {
            _overTimeViewService = overTimeViewService;
        }

        /// <summary>
        /// 加班查詢
        /// </summary>
        /// <remarks>
        /// { "employeeList": [ "A1357","A0793" ], "dateBegin": "2020-09-05", "dateEnd": "2020-09-09" }
        /// </remarks>
        [HttpPost("OverTimeSearchView")]
        public ApiResult<List<OverTimeSearchViewDto>> GetOverTimeSearchView(OverTimeSearchViewEntry overTimeSearchViewEntry)
        {
            return _overTimeViewService.GetOverTimeSearchView(overTimeSearchViewEntry);
        }
    }
}
