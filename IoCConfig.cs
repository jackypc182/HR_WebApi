using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HR_WebApi
{
    public class IoCConfig
    {

        public IoCConfig()
        {

        }
        public static IServiceCollection Configure(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddSingleton<NLog.ILogger>(NLog.LogManager.GetLogger("HR"));

            services.AddScoped<JBHRIS.Api.Service.Salary.Payroll.ISalaryCalculationService, JBHRIS.Api.Service.Salary.Payroll.SalaryCalculationService>();
            services.AddScoped<JBHRIS.Api.Bll.Salary.Payroll.ISalaryCalculateModule, JBHRIS.Api.Bll.Salary.Payroll.SalaryCalculateModule>();
            services.AddScoped<JBHRIS.Api.Bll.Salary.Payroll.ISalaryCalculateModuleFactory, JBHRIS.Api.Bll.Salary.Payroll.SalaryCalculateModuleFactory>();

            //services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeInfoService, JBHRIS.Api.Service.Employee.Normal.EmployeeInfoService>();
            //services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeListService, JBHRIS.Api.Service.Employee.Normal.EmployeeListService>();
            //services.AddScoped<JBHRIS.Api.Service.Employee.View.IEmployeeViewService, JBHRIS.Api.Service.Employee.View.EmployeeViewService > ();

            //services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normail_GetPeopleByBirthday, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normail_GetPeopleByBirthday>();
            return services;
        }



        



    }
}
