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
        /// <summary>
        /// 設定註冊服務
        /// </summary>
        /// <param name="Configuration">設定檔</param>
        /// <param name="services">服務集合</param>
        /// <returns></returns>
        public static IServiceCollection Configure(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddSingleton<NLog.ILogger>(NLog.LogManager.GetLogger("HR"));

            
            services.AddScoped<JBHRIS.Api.Service.Salary.Payroll.ISalaryCalculationService, JBHRIS.Api.Service.Salary.Payroll.SalaryCalculationService>();
            services.AddScoped<JBHRIS.Api.Bll.Salary.Payroll.ISalaryCalculateModule, JBHRIS.Api.Bll.Salary.Payroll.SalaryCalculateModule>();
            services.AddScoped<JBHRIS.Api.Bll.Salary.Payroll.ISalaryCalculateModuleFactory, JBHRIS.Api.Bll.Salary.Payroll.SalaryCalculateModuleFactory>();
            //Service
            services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeInfoService, JBHRIS.Api.Service.Employee.Normal.EmployeeInfoService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeListService, JBHRIS.Api.Service.Employee.Normal.EmployeeListService>();             
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IEmployeeViewService, JBHRIS.Api.Service.Employee.View.EmployeeViewService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IDeptViewService, JBHRIS.Api.Service.Employee.Normal.DeptViewService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IJobViewService, JBHRIS.Api.Service.Employee.View.JobViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleCheckService, JBHRIS.Api.Service.Attendance.WorkScheduleCheckService>();


            //Dal
            services.AddScoped<JBHRIS.Api.Dal.Employee.IEmployee_Normal_GetEmployeeInfo, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetEmployeeInfo>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.IEmployee_Normal_GetPeopleByDept, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByDept>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_EmployeeInfoRepository, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_EmployeeInfoRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByLeaveDate, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByLeaveDate>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByOnBoardDate, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_GetPeopleByOnBoardDate>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployee, JBHRIS.Api.Dal.JBHR.Employee.Employee_View_GetEmployee>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDept, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDept>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDepts, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDepts>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDepta, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDepta>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJob, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJob>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobl, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobl>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobo, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobo>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobs, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobs>();

            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_EmployeePasswordRepository, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_EmployeePasswordRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByBirthday, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByBirthday>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployeeBirthday, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetEmployeeBirthday>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.IWorkscheduleCheck_ScheduleTypeRepository, JBHRIS.Api.Dal.JBHR.Attendance.WorkscheduleCheck_ScheduleTypeRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.ICalendarHolidayRepository, JBHRIS.Api.Dal.JBHR.Attendance.CalendarHolidayRepository>();

            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleFactory, JBHRIS.Api.Service.Attendance.WorkScheduleFactory>();

            services.AddScoped<JBHRIS.Api.Dal.JBHR.Repository.IUnitOfWork, JBHRIS.Api.Dal.JBHR.Repository.JbhrUnitOfWork>();
            services.AddScoped<DbContext, JBHRIS.Api.Dal.JBHR.JBHRContext>();
            return services;
        }



        



    }
}
