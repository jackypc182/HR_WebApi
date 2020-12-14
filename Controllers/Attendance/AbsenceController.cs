using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_WebApi.Api.Dto;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 請假服務
    /// </summary>
    /// <description>
    /// 請假服務的輔助說明
    /// </description>
    /// <remarks>測試123</remarks>    
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private IAbsenceService _absenceService;
        private ILogger _logger;
        /// <summary>
        /// 請假控制器
        /// </summary>
        /// <param name="absenceService">請假服務</param>
        /// <param name="logger"></param>
        public AbsenceController(IAbsenceService absenceService,ILogger logger)
        {
            _absenceService = absenceService;
            _logger = logger;
        }
        /// <summary>
        /// 取得請假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns>產生的結果</returns>
        /// <remarks>請假服務的輔助說明</remarks>  
        [Route("GetAbsenceTaken")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetAbsenceTaken,Admin")]
        public ApiResult<List<AbsenceTakenDto>> GetAbsenceTaken(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsenceTaken");
            ApiResult<List<AbsenceTakenDto>> apiResult = new ApiResult<List<AbsenceTakenDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetAbsenceTaken(absenceEntryDto);
                apiResult.State = true;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得銷假資料
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsenceCancel")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetAbsenceCancel,Admin")]
        public ApiResult<List<AbsenceCancelDto>> GetAbsenceCancel(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsenceCancel");
            ApiResult<List<AbsenceCancelDto>> apiResult = new ApiResult<List<AbsenceCancelDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetAbsenceCancel(absenceEntryDto);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得剩餘時數
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetAbsBalance")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetAbsBalance,Admin")]
        public ApiResult<List<AbsenceBalanceDto>> GetAbsBalance(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetAbsBalance");
            ApiResult<List<AbsenceBalanceDto>> apiResult = new ApiResult<List<AbsenceBalanceDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetAbsBalance(absenceEntryDto);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 請假名單
        /// </summary>
        /// <param name="absenceEntryDto"></param>
        /// <returns></returns>
        [Route("GetPeopleAbs")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetPeopleAbs,Admin")]
        public ApiResult<List<string>> GetPeopleAbs(AbsenceEntry absenceEntryDto)
        {
            _logger.Info("開始呼叫AbsenceService.GetPeopleAbs");
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetPeopleAbs(absenceEntryDto);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
        /// <summary>
        /// 取得假別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetHcode")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetHcode,Admin")]
        public ApiResult<List<HcodeDto>> GetHcode()
        {
            _logger.Info("開始呼叫AbsenceService.GetHcode");
            ApiResult<List<HcodeDto>> apiResult = new ApiResult<List<HcodeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetHcode();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得假別類別
        /// </summary>
        /// <returns></returns>
        [Route("GetHcodeTypes")]
        [HttpGet]
        [Authorize(Roles = "Absence/GetHcodeTypes,Admin")]
        public ApiResult<List<HcodeTypeDto>> GetHcodeTypes()
        {
            _logger.Info("開始呼叫AbsenceService.GetHcodeTypes");
            ApiResult<List<HcodeTypeDto>> apiResult = new ApiResult<List<HcodeTypeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetHcodeTypes();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得請假類別假別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetHcodeTypesByHcode")]
        [HttpPost]
        [Authorize(Roles = "Absence/GetHcodeTypesByHcode,Admin")]
        public ApiResult<List<HcodeDto>> GetHcodeTypesByHcode(HcodeTypesByHcodeEntry hcodeTypesByHcodeEntry)
        {
            _logger.Info("開始呼叫AbsenceService.GetHcodeTypes");
            ApiResult<List<HcodeDto>> apiResult = new ApiResult<List<HcodeDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _absenceService.GetHcodeTypesByHcode(hcodeTypesByHcodeEntry);
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