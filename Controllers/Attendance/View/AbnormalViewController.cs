using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Attendance.View
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/View/[controller]")]
    [ApiController]
    public class AbnormalViewController
    {
        IAbnormalViewService _abnormalViewService;
        public AbnormalViewController(IAbnormalViewService abnormalViewService) 
        {
            _abnormalViewService = abnormalViewService;
        }

        /// <summary>
        /// 異常查詢
        /// </summary>
        /// <remarks>        
        /// { "employeeList": [ "A1357","A0793" ],"dateBegin": "2020-09-01", "dateEnd": "2020-09-05","isCheck":true }
        /// </remarks>
        [HttpPost("AbnormalSearchView")]
        [Authorize(Roles = "AbnormalView/AbnormalSearchView,Admin")]
        public ApiResult<List<AbnormalSearchViewDto>> GetAbnormalSearchView(AbnormalSearchViewEntry abnormalSearchViewEntry)
        {
            return _abnormalViewService.GetAbnormalSearchView(abnormalSearchViewEntry);
        }
    }
}
