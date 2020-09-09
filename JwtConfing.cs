using HR_WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HR_WebApi
{
    /// <summary>
    /// 用來設定jwt initial config
    /// </summary>
    public class JwtConfing
    {
        /// <summary>
        /// JwtConfing建構子
        /// </summary>
        public JwtConfing()
        {

        }

        /// <summary>
        /// 在starup設定config
        /// </summary>
        /// <param name="Configuration"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection Configure( IConfiguration Configuration , IServiceCollection services)
        {
            services.AddSingleton<JwtHelpers>();
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.IncludeErrorDetails = true; // WWW-Authenticate 會顯示詳細錯誤原因

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = Configuration.GetValue<string>("Jwt:NameClaim"),
                        RoleClaimType = Configuration.GetValue<string>("Jwt:RoleClaim"),
                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetValue<string>("Jwt:issuer"),
                        ValidateAudience = false,
                        //ValidAudience = Configuration.GetValue<string>("Jwt:Issuer"),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = false, // 如果 JWT 包含 key 才需要驗證，一般都只有簽章而已
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:signKey")))
                    };
                });
            return services;
        }
    }
}
