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
    public class AbsenceViewController : ControllerBase
    {
        IAbsenceTakenViewService _absenceTakenViewService;
        IAbsenceEntitleViewService _absenceEntitleViewService;
        /// <summary>
        /// 
        /// </summary>
        public AbsenceViewController(
        IAbsenceTakenViewService absenceTakenViewService,
        IAbsenceEntitleViewService absenceEntitleViewService)
        {
            _absenceTakenViewService = absenceTakenViewService;
            _absenceEntitleViewService = absenceEntitleViewService;
        }
        /// <summary>
        /// 得假查詢
        /// </summary>
        /// <remarks>
        /// {
        ///  "employeeList": [
        ///    "A1357","A0793"
        ///  ],
        ///  "leaveCodeList": [
        ///  ],
        ///  "dateBegin": "2020-09-05",
        ///  "dateEnd": "2020-09-09"
        /// }
        /// </remarks>
        /// <param name="abseneceEntitleViewEntry"></param>
        /// <returns></returns>
        [HttpPost("GetAbsenceEntitleView")]
        [Authorize(Roles = "AbsenceView/GetAbsenceEntitleView,Admin")]
        public ApiResult<List<AbsenceEntitleViewDto>> GetAbsenceEntitleView(AbseneceEntitleViewEntry  abseneceEntitleViewEntry)
        {
            return _absenceEntitleViewService.GetAbsenceEntitleView(abseneceEntitleViewEntry);
        }

        /// <summary>
        /// 請假查詢
        /// </summary>
        /// <remarks>
        /// {
        ///  "employeeList": [
        ///    "A1357","A0793"
        ///  ],
        ///  "leaveCodeList": [
        ///  ],
        ///  "dateBegin": "2020-09-05",
        ///  "dateEnd": "2020-09-09"
        /// }
        /// </remarks>
        /// <param name="abseneceTakenViewEntry"></param>
        /// <returns></returns>
        [HttpPost("GetAbsenceTakenView")]
        [Authorize(Roles = "AbsenceView/GetAbsenceTakenView,Admin")]
        public ApiResult<List<AbsenceTakenViewDto>> GetAbsenceTakenView(AbsenceTakenViewEntry abseneceTakenViewEntry)
        {
            return _absenceTakenViewService.GetAbsenceTakenView(abseneceTakenViewEntry);
        }
    }
}
