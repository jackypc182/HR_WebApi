using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using Hangfire;
//using Hangfire.Console;
//using Hangfire.Dashboard.Management;
//using Hangfire.SqlServer;
using JBHRIS.Api.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace HR_WebApi
{
    /// <summary>
    /// 啟動
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration">設定檔</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 設定檔
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 設定服務
        /// </summary>
        /// <param name="services">服務集合</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ConfigurationDto>(Configuration);
            services.AddSingleton<NLog.ILogger>(NLog.LogManager.GetLogger("HR"));
            services.AddMemoryCache();
            //var config = Configuration.GetSection("Moduleregister");
            services.AddDbContext<JBHRIS.Api.Dal.JBHR.JBHRContext>(options => options.UseSqlServer(Configuration["HrConnectionStrings:DefaultConnection"]));
            //JwtConfing.Configure(Configuration, services);
            //services.AddHangfire(configuration => configuration
            // .UseSimpleAssemblyNameTypeSerializer()
            //                       .UseRecommendedSerializerSettings()
            //                       .UseColouredConsoleLogProvider()
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics.ServerCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics.RecurringJobCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics.RetriesCount)

            //                       //.UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics.EnqueuedCountOrNull)
            //                       //.UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics.FailedCountOrNull)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics
            //                                                   .EnqueuedAndQueueCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics
            //                                                   .ScheduledCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics
            //                                                   .ProcessingCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics
            //                                                   .SucceededCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics.FailedCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics.DeletedCount)
            //                       .UseDashboardMetric(Hangfire.Dashboard.DashboardMetrics
            //                                                   .AwaitingCount)
            //                       .UseConsole()
            //                       .UseNLogLogProvider()
            // .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
            // {
            //     CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //     SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            //     QueuePollInterval = TimeSpan.Zero,
            //     UseRecommendedIsolationLevel = true,
            //     DisableGlobalLocks = true
            // })
            // .UseManagementPages(p => p.AddJobs(() => GetModuleTypes()))
            // );
            // Add the processing server as IHostedService
            //services.AddHangfireServer();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        // 當驗證失敗時，回應標頭會包含 WWW-Authenticate 標頭，這裡會顯示失敗的詳細錯誤原因
                        options.IncludeErrorDetails = true; // 預設值為 true，有時會特別關閉

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            //// 透過這項宣告，就可以從 "sub" 取值並設定給 User.Identity.Name
                            //NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                            //// 透過這項宣告，就可以從 "roles" 取值，並可讓 [Authorize] 判斷角色
                            //RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            NameClaimType = Configuration.GetValue<string>("Jwt:NameClaim"),
                            RoleClaimType = Configuration.GetValue<string>("Jwt:RoleClaim"),
                            // 一般我們都會驗證 Issuer
                            ValidateIssuer = true,
                            ValidIssuer = Configuration.GetValue<string>("Jwt:issuer"),

                            // 若是單一伺服器通常不太需要驗證 Audience
                            ValidateAudience = false,
                            //ValidAudience = "JwtAuthDemo", // 不驗證就不需要填寫

                            // 一般我們都會驗證 Token 的有效期間
                            ValidateLifetime = true,

                            // 如果 Token 中包含 key 才需要驗證，一般都只有簽章而已
                            ValidateIssuerSigningKey = false,

                            // "1234567890123456" 應該從 IConfiguration 取得
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:signKey")))
                        };
                    });

            IoCConfig.Configure(Configuration, services);

            var conf = Configuration.Get<ConfigurationDto>();
            if (conf.ModuleRegister != null && conf.ModuleRegister.Module != null)
                foreach (var mod in conf.ModuleRegister.Module)
                {
                    var asmInterface = Assembly.LoadFrom(conf.SourceDir + mod.InterfaceAssembly);
                    var asmConcrete = Assembly.LoadFrom(conf.SourceDir + mod.ConcreteClassAssembly);
                    var typeInterface = asmInterface.GetType(mod.Interface);
                    var typeClass = asmConcrete.GetType(mod.ConcreteClass);
                    services.AddScoped(typeInterface, typeClass);
                }

            services.AddSwaggerGen(c =>
            {
                var contact = new OpenApiContact();
                contact.Email = "stanley@jbjob.com.tw";
                contact.Name = "林志興";                
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JBHR Web API",
                    Version = "v1",
                    Contact = contact,
                    Description = "人事系統api"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                                       {
                                         new OpenApiSecurityScheme
                                         {
                                           Reference = new OpenApiReference
                                           {
                                             Type = ReferenceType.SecurityScheme,
                                             Id = "Bearer"
                                           }
                                          },
                                          new string[] { }
                                        }
                                      });
                c.UseAllOfToExtendReferenceSchemas();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                string commentsFile = Path.Combine(baseDirectory, commentsFileName);
                c.IncludeXmlComments(commentsFile);
            });

            // 允許 DefaultAuthorize(IAuthorizationFilter) 可以吃AllowAnonymousAttribute可以正確運作
            services.AddMvcCore(o => o.EnableEndpointRouting = false);
        }

        private Type[] GetModuleTypes()
        {
            var assemblies = new[] { this.GetType().Assembly };
            //var assemblies = new[] { typeof(JBHRIS.Api.Service.Attendance.Normal.CardMachineService).Assembly };
            var moduleTypes = assemblies.SelectMany(f =>
            {
                try
                {
                    return f.GetTypes();
                }
                catch (Exception)
                {
                    return new Type[] { };
                }
            }
                                                   )
                                        .ToArray();

            assemblies = new[] { typeof(JBHRIS.Api.Service.Attendance.Normal.CardMachineService).Assembly };
            //var assemblies = new[] { typeof(JBHRIS.Api.Service.Attendance.Normal.CardMachineService).Assembly };
            var moduleTypes1 = assemblies.SelectMany(f =>
            {
                try
                {
                    return f.GetTypes();
                }
                catch (Exception)
                {
                    return new Type[] { };
                }
            }
                                                   )
                                        .ToArray();

            return moduleTypes.Union(moduleTypes1).ToArray();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Error");
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //app.UseHangfireDashboard();
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseStaticFiles();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "JBHR Web API V1");
                //c.SwaggerEndpoint("/swagger.json", "JBHR Web API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHangfireDashboard();
            });
        }
    }
}
