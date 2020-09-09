using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    /// �Ұ�
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration">�]�w��</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// �]�w��
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// �]�w�A��
        /// </summary>
        /// <param name="services">�A�ȶ��X</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ConfigurationDto>(Configuration);
            services.AddSingleton<NLog.ILogger>(NLog.LogManager.GetLogger("HR"));
            //var config = Configuration.GetSection("Moduleregister");
            services.AddDbContext<JBHRIS.Api.Dal.JBHR.JBHRContext>(options => options.UseSqlServer(Configuration["HrConnectionStrings:DefaultConnection"]));
            //JwtConfing.Configure(Configuration, services);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        // �����ҥ��ѮɡA�^�����Y�|�]�t WWW-Authenticate ���Y�A�o�̷|��ܥ��Ѫ��Բӿ��~��]
                        options.IncludeErrorDetails = true; // �w�]�Ȭ� true�A���ɷ|�S�O����

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            //// �z�L�o���ŧi�A�N�i�H�q "sub" ���Ȩó]�w�� User.Identity.Name
                            //NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                            //// �z�L�o���ŧi�A�N�i�H�q "roles" ���ȡA�åi�� [Authorize] �P�_����
                            //RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            NameClaimType = Configuration.GetValue<string>("Jwt:NameClaim"),
                            RoleClaimType = Configuration.GetValue<string>("Jwt:RoleClaim"),
                            // �@��ڭ̳��|���� Issuer
                            ValidateIssuer = true,
                            ValidIssuer = Configuration.GetValue<string>("Jwt:issuer"),

                            // �Y�O��@���A���q�`���ӻݭn���� Audience
                            ValidateAudience = false,
                            //ValidAudience = "JwtAuthDemo", // �����ҴN���ݭn��g

                            // �@��ڭ̳��|���� Token �����Ĵ���
                            ValidateLifetime = true,

                            // �p�G Token ���]�t key �~�ݭn���ҡA�@�볣�u��ñ���Ӥw
                            ValidateIssuerSigningKey = false,

                            // "1234567890123456" ���ӱq IConfiguration ���o
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
                contact.Name = "�L�ӿ�";
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JBHR Web API",
                    Version = "v1",
                    Contact = contact,
                    Description = "�H�ƨt��api"
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

            // ���\ DefaultAuthorize(IAuthorizationFilter) �i�H�YAllowAnonymousAttribute�i�H���T�B�@
            services.AddMvcCore(o => o.EnableEndpointRouting = false);
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
            });
        }
    }
}
