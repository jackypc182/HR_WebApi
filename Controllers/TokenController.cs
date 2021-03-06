﻿using HR_WebApi.Helpers;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Login;
using JBHRIS.Api.Service;
using JBHRIS.Api.Service.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApiAuthDemo.Controllers
{
    /**
     * https://blog.miniasp.com/post/2019/10/13/How-to-use-JWT-token-based-auth-in-aspnet-core-22
     **/

    /// <summary>
    /// 登入及授權
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _configuration;
        private UserValidateService _userValidateService;
        private UserInfoService _userInfoService;
        private IRefreshTokenService _refreshTokenService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="userValidateService"></param>
        /// <param name="userInfoService"></param>
        public TokenController(IConfiguration configuration,
            UserValidateService userValidateService,
            UserInfoService userInfoService,
            IRefreshTokenService refreshTokenService)
        {
            _configuration = configuration;
            _userValidateService = userValidateService;
            _userInfoService = userInfoService;
            _refreshTokenService = refreshTokenService;
        }
        /// <summary>
        /// 登入並取得Token
        /// </summary>
        /// <param name="UserId">使用者編號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        [Route("Signin")]
        [HttpPost]
        public ApiResult<TokenResultDto>  SignIn(string UserId, string Password)
        {
            // 以下變數值應該透過 IConfiguration 取得
            var issuer = _configuration["JWT:issuer"].ToString(); //"JwtAuthDemo";
            var signKey = _configuration["JWT:signKey"].ToString(); // 請換成至少 16 字元以上的安全亂碼
            var expires = Convert.ToInt32(_configuration["JWT:expires"]); // 單位: 分鐘

            TokenResultDto tokenResultDto;
            ApiResult<TokenResultDto> status = new ApiResult<TokenResultDto>();
            status.State = false;
            if (_userValidateService.ValidateUser(UserId,Password))
            {
                var refreshToken = Guid.NewGuid().ToString();
                _refreshTokenService.InsertRefreshToken(UserId, refreshToken);

                tokenResultDto = new TokenResultDto()
                {
                    accessToken = JwtHelpers.GenerateToken(issuer, signKey, UserId, expires, _userInfoService.GetApiRoles(UserId), JsonConvert.SerializeObject(_userInfoService.GetUserInfo(UserId))),
                    refreshToken = refreshToken
                };

                status.State = true;
                status.Result = tokenResultDto;
            }
            else
            {
                status.Message = "帳號密碼輸入錯誤";
            }

            return status;
        }

        /// <summary>
        /// 重新取得Token
        /// </summary>
        /// <param name="refreshToken">refreshToken</param>
        /// <returns></returns>
        [Route("RefreshToken")]
        [HttpPost]
        public ApiResult<TokenResultDto> RefreshToken(string refreshToken)
        {

            TokenResultDto tokenResultDto;
            ApiResult<TokenResultDto> status = new ApiResult<TokenResultDto>();
            status.State = false;
            var refreshTokenState = _refreshTokenService.UpdateRefreshToken(refreshToken);
            if (refreshTokenState.State)
            {
                // 以下變數值應該透過 IConfiguration 取得
                var issuer = _configuration["JWT:issuer"].ToString(); //"JwtAuthDemo";
                var signKey = _configuration["JWT:signKey"].ToString(); // 請換成至少 16 字元以上的安全亂碼
                var expires = Convert.ToInt32(_configuration["JWT:expires"]); // 單位: 分鐘
                string UserId = refreshTokenState.Result.Nobr.ToString();
                tokenResultDto = new TokenResultDto()
                {
                    accessToken = JwtHelpers.GenerateToken(issuer, signKey, UserId, expires, _userInfoService.GetApiRoles(UserId), JsonConvert.SerializeObject(_userInfoService.GetUserInfo(UserId))),
                    refreshToken = refreshToken
                };

                status.State = true;
                status.Result = tokenResultDto;
            }

            return status;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/claims")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/userdata")]
        public IActionResult GetUserData()
        {
            return Ok(User.Claims.Where(p=>p.Type.Contains("userdata")).FirstOrDefault().Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/username")]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/jwtid")]
        public IActionResult GetUniqueId()
        {
            var jti = User.Claims.FirstOrDefault(p => p.Type == "jti");
            return Ok(jti.Value);
        }
    }
 
}