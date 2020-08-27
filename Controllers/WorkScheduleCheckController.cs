using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

namespace HR_Api_Demo.Controllers
{
    /// <summary>
    /// 排班檢核服務
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class WorkScheduleCheckController : ControllerBase
    {
        private JBHRIS.Api.Service.Attendance.IWorkScheduleCheckService _workScheduleCheckService;
        private ILogger _logger;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="workScheduleCheckService"></param>
        public WorkScheduleCheckController(JBHRIS.Api.Service.Attendance.IWorkScheduleCheckService workScheduleCheckService, NLog.ILogger logger)
        {
            _workScheduleCheckService = workScheduleCheckService;
            _logger = logger;
        }
        /// <summary>
        /// 排班檢核
        /// </summary>
        /// <param name="workScheduleCheckEntry"></param>
        /// <returns></returns>
        [Route("Check")]
        [HttpPost]
        public ActionResult<WorkScheduleCheckResult> Check([FromBody] WorkScheduleCheckEntry workScheduleCheckEntry)// Check(dynamic workScheduleCheckEntry)//
        {
            //WorkScheduleCheckEntry workScheduleCheckEntry = new WorkScheduleCheckEntry();
            //workScheduleCheckEntry.CheckTypes.Add("CW7");
            //return _workScheduleCheckService.Check(JsonConvert.DeserializeObject<WorkScheduleCheckEntry>(workScheduleCheckEntry.ToString()));
            //WorkScheduleCheckResult result = DataCheck(workScheduleCheckEntry);
            //if (result.State)
            _logger.Info("開始呼叫WorkScheduleCheck.Check");
                return _workScheduleCheckService.Check(workScheduleCheckEntry);
            //else
            //    return result;
        }
        /// <summary>
        /// 查詢現有班表資料，同時合併輸入的資料進行檢核班表是否有違規
        /// </summary>
        /// <param name="workScheduleCheckEntry">檢核條件</param>
        /// <returns></returns>
        [Route("CheckWithQuery")]
        [HttpPost]
        public ActionResult<WorkScheduleCheckResult> CheckWithQuery([FromBody] WorkScheduleCheckEntry workScheduleCheckEntry)// Check(dynamic workScheduleCheckEntry)//
        {
            _logger.Info("開始呼叫WorkScheduleCheck.CheckWithQuery");
            return _workScheduleCheckService.CheckWithQuery(workScheduleCheckEntry);            
        }
        /// <summary>
        /// 取得班別設定
        /// </summary>
        /// <returns></returns>
        [Route("GetScheduleTypes")]
        [HttpPost]
        public string GetScheduleTypes()
        {
            _logger.Info("開始呼叫WorkScheduleCheck.GetScheduleTypes");
            List<ScheduleTypeDto> result = new List<ScheduleTypeDto>();
            result = _workScheduleCheckService.GetScheduleTypeList();
            return JsonConvert.SerializeObject(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workschedulecheckEntry"></param>
        /// <returns></returns>
        [Route("GetWorkschedules")]
        [HttpPost]
        public string GetWorkschedules([FromBody]WorkschedulecheckEntry workschedulecheckEntry  )
        {
            _logger.Info("開始呼叫WorkScheduleCheck.GetWorkschedules");
            Dictionary<string, List<WorkScheduleDto>> workSchedulecheckDic = new Dictionary<string, List<WorkScheduleDto>>();
            workSchedulecheckDic = _workScheduleCheckService.GetWorkScheduleList(workschedulecheckEntry);
            return JsonConvert.SerializeObject(workSchedulecheckDic);
        }

        /// <summary>
        /// 輸入資料檢核
        /// </summary>
        /// <param name="workScheduleCheckEntry"></param>
        /// <returns></returns>
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
                else 
                if (!WSCD.ScheduleTypes.Where(p => p.Code == WSCD.WorkSchedules.Where(p => p.AttendanceDate == DT).First().ScheduleType).Any())
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