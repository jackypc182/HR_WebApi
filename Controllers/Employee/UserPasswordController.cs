﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Service.Employee.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPasswordController : ControllerBase
    {
        ILogger _logger;
        IUserPasswordService _userPasswordService;

        public UserPasswordController(ILogger logger,IUserPasswordService userPasswordService)
        {
            _logger = logger;
            _userPasswordService = userPasswordService;
        }

        /// <summary>
        /// 驗證使用者
        /// </summary>
        /// <param name="verifyIdentityEntry"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("VerifyIdentity")]
        public ApiResult<string> VerifyIdentity(VerifyIdentityEntry verifyIdentityEntry)
        {
            _logger.Info("開始呼叫UserPasswordService.VerifyIdentity");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult.State = _userPasswordService.VerifyIdentity(verifyIdentityEntry);
            }
            catch(Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="verifyIdentityEntry"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdatePassword")]
        public ApiResult<string> UpdatePassword(UpdatePasswordEntry updatePasswordEntry)
        {
            _logger.Info("開始呼叫UserPasswordService.UpdatePassword");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult.State = _userPasswordService.UpdatePassword(updatePasswordEntry);
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }


    }
}
