using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using JBHRIS.Api.Dto.Attendance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HR_Api_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkScheduleCheckController : ControllerBase
    {
        private JBHRIS.Api.Service.Attendance.IWorkScheduleCheckService _workScheduleCheckService;

        public WorkScheduleCheckController(JBHRIS.Api.Service.Attendance.IWorkScheduleCheckService workScheduleCheckService)
        {
            _workScheduleCheckService = workScheduleCheckService;
        }
        [Route("Check")]
        [HttpPost]
        public ActionResult<WorkScheduleCheckResult> Check([FromBody] WorkScheduleCheckEntry workScheduleCheckEntry)// Check(dynamic workScheduleCheckEntry)//
        {
            //WorkScheduleCheckEntry workScheduleCheckEntry = new WorkScheduleCheckEntry();
            //workScheduleCheckEntry.CheckTypes.Add("CW7");
            //return _workScheduleCheckService.Check(JsonConvert.DeserializeObject<WorkScheduleCheckEntry>(workScheduleCheckEntry.ToString()));
            WorkScheduleCheckResult result = DataCheck(workScheduleCheckEntry);
            if (result.State)
                return _workScheduleCheckService.Check(workScheduleCheckEntry);
            else
                return result;
        }

        private WorkScheduleCheckResult DataCheck(WorkScheduleCheckEntry workScheduleCheckEntry)
        {
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            WorkScheduleCheckEntry WSCE = workScheduleCheckEntry;
            WorkScheduleCheckDto WSCD = workScheduleCheckEntry.workScheduleCheck;
            for (DateTime DT = WSCD.StartDate; DT <= WSCD.EndCheckDate; DT = DT.AddDays(1))
            {
                if (!WSCD.WorkSchedules.Where(p => p.AttendanceDate == DT).Any())
                {
                    result.State = false;
                    result.workScheduleIssues.Add(new WorkScheduleIssueDto
                    {
                        IssueDate = DT,
                        CheckType = "DataCheck",
                        ErrorCode = "DataCheck",//"CDT2",
                        ErrorMessage = string.Format("檢核日期：{0} 並無班表資料.", DT.ToString("yyyy-MM-dd")),
                    });
                }
                else if (!WSCD.ScheduleTypes.Where(p => p.Code == WSCD.WorkSchedules.Where(p => p.AttendanceDate == DT).First().ScheduleType).Any())
                {
                    result.State = false;
                    result.workScheduleIssues.Add(new WorkScheduleIssueDto
                    {
                        IssueDate = DT,
                        CheckType = "DataCheck",
                        ErrorCode = "DataCheck",//"CDT2",
                        ErrorMessage = string.Format("檢核日期：{0} 班別資料不存在.", DT.ToString("yyyy-MM-dd")),
                    });
                }
            }
            return result;
        }

    }
}