using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JBHRIS.Api.Dto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace HR_WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<ConfigurationDto>(Configuration);
            services.AddSingleton<NLog.ILogger>(NLog.LogManager.GetLogger("HR"));
            //var config = Configuration.GetSection("Moduleregister");
            services.AddDbContext<JBHRIS.Api.Dal.JBHR.JBHRContext>(options => options.UseSqlServer(Configuration["HrConnectionStrings:DefaultConnection"]));

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
            //test for ci 
            //fix vstest
            //abc
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
