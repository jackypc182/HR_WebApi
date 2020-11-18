using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using JBHRIS.Api.Service.Employee.Normal;

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
            services.AddScoped<JBHRIS.Api.Service.Employee.Normal.IEmployeeRoleService, JBHRIS.Api.Service.Employee.Normal.EmployeeRoleService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IEmployeeViewService, JBHRIS.Api.Service.Employee.View.EmployeeViewService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IDeptViewService, JBHRIS.Api.Service.Employee.Normal.DeptViewService>();
            services.AddScoped<JBHRIS.Api.Service.Employee.View.IJobViewService, JBHRIS.Api.Service.Employee.View.JobViewService>();
            services.AddScoped<JBHRIS.Api.Service.UserInfoService, JBHRIS.Api.Service.UserInfoService>();
            services.AddScoped<JBHRIS.Api.Service.UserValidateService, JBHRIS.Api.Service.UserValidateService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleFactory, JBHRIS.Api.Service.Attendance.WorkScheduleFactory>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleCheckService, JBHRIS.Api.Service.Attendance.WorkScheduleCheckService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.ICardService, JBHRIS.Api.Service.Attendance.Normal.CardService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IRoteChangeService, JBHRIS.Api.Service.Attendance.Normal.RoteChangeService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAbsenceService, JBHRIS.Api.Service.Attendance.Normal.AbsenceService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IAttendanceService, JBHRIS.Api.Service.Attendance.Normal.AttendanceService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.Normal.IOvertimeService, JBHRIS.Api.Service.Attendance.Normal.OvertimeService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IAbsenceEntitleViewService, JBHRIS.Api.Service.Attendance.View.AbsenceEntitleViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IAbsenceTakenViewService, JBHRIS.Api.Service.Attendance.View.AbsenceTakenViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IOverTimeViewService, JBHRIS.Api.Service.Attendance.View.OverTimeViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.ICardViewService, JBHRIS.Api.Service.Attendance.View.CardViewService>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.View.IAbnormalViewService, JBHRIS.Api.Service.Attendance.View.AbnormalViewService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysRoleViewService, JBHRIS.Api.Service._System.View.SysRoleViewService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysRolePageService, JBHRIS.Api.Service._System.View.SysRolePageService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysPageApiService, JBHRIS.Api.Service._System.View.SysPageApiService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysPageApiVoidService, JBHRIS.Api.Service._System.View.SysPageApiVoidService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysUserRoleViewService, JBHRIS.Api.Service._System.View.SysUserRoleViewService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysApiVoidService, JBHRIS.Api.Service._System.View.SysApiVoidService>();
            services.AddScoped<JBHRIS.Api.Service._System.View.ISysNewsService, JBHRIS.Api.Service._System.View.SysNewsService>();
            services.AddScoped<JBHRIS.Api.Service.Token.IRefreshTokenService, JBHRIS.Api.Service.Token.RefreshTokenService>();

            //Dal

            services.AddScoped<JBHRIS.Api.Dal.Employee.IEmployee_Normal_GetEmployeeInfo, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetEmployeeInfo>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.IEmployee_Normal_GetPeopleByDept, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByDept>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_EmployeeInfoRepository, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_EmployeeInfoRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByLeaveDate, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByLeaveDate>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByOnBoardDate, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_GetPeopleByOnBoardDate>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployee, JBHRIS.Api.Dal.JBHR.Employee.Employee_View_GetEmployee>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployeeJob, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetEmployeeJob>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDept, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDept>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDepts, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDepts>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetDepta, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetDepta>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJob, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJob>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobl, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobl>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobo, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobo>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetJobs, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetJobs>();
            services.AddScoped<JBHRIS.Api.Dal._System.IUserValidateDal, JBHRIS.Api.Dal.JBHR._System.UserValidateDal>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_GetCardApply, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_GetCardApply>();
            services.AddScoped<EmployeeRoleService, EmployeeRoleService>();

            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_EmployeePasswordRepository, JBHRIS.Api.Dal.JBHR.Employee.Normal.Employee_Normal_EmployeePasswordRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.Normal.IEmployee_Normal_GetPeopleByBirthday, JBHRIS.Api.Dal.JBHR.Employee.Employee_Normal_GetPeopleByBirthday>();
            services.AddScoped<JBHRIS.Api.Dal.Employee.View.IEmployee_View_GetEmployeeBirthday, JBHRIS.Api.Dal.JBHR.Employee.View.Employee_View_GetEmployeeBirthday>();
            
            services.AddScoped<JBHRIS.Api.Dal.Attendance.IWorkscheduleCheck_ScheduleTypeRepository, JBHRIS.Api.Dal.JBHR.Attendance.WorkscheduleCheck_ScheduleTypeRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.ICalendarHolidayRepository, JBHRIS.Api.Dal.JBHR.Attendance.CalendarHolidayRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICard_Normal_GetAttCard, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Card_Normal_GetAttCard>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICardReasonRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.CardReasonRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICardRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.CardRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IRoteChangeRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.RoteChangeRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsenceTakenRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.AbsenceTakenRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsenceCancelRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.AbsenceCancelRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IOverTimeRepository, JBHRIS.Api.Dal.JBHR.Attendance.Normal.OverTimeRepository>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.ICardMachineSettingDal, JBHRIS.Api.Dal.JBHR.Attendance.Normal.CardMachineSettingDal>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsence_Normal_GetHcodeTypes, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Absence_Normal_GetHcodeTypes>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.Normal.IAbsence_Normal_GetHcodeTypesByHcode, JBHRIS.Api.Dal.JBHR.Attendance.Normal.Absence_Normal_GetHcodeTypesByHcode>(); 
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAttendRote, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAttendRote>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_Abnormal, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_Abnormal>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAbsenceEntitleView, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAbsenceEntitleView>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAbsenceTakenView, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAbsenceTakenView>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetOvertimeSearch, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetOvertimeSearch>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetCardSearch, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetCardSearch>();
            services.AddScoped<JBHRIS.Api.Dal.Attendance.View.IAttend_View_GetAbnormalSearch, JBHRIS.Api.Dal.JBHR.Attendance.View.Attend_View_GetAbnormalSearch>();
            services.AddScoped<JBHRIS.Api.Dal._System.ISystem_UserDal, JBHRIS.Api.Dal.JBHR._System.System_UserDal>();
            services.AddScoped<JBHRIS.Api.Dal._System.ISystem_UserDataRole, JBHRIS.Api.Dal.JBHR._System.System_UserDataRole>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysRelcode, JBHRIS.Api.Dal.JBHR._System.View.System_View_SysRelcode>();
            services.AddScoped<JBHRIS.Api.Dal.Token.IRefreshToken_View, JBHRIS.Api.Dal.JBHR.Token.RefreshToken_View>();
            //bll

            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysRole, JBHRIS.Api.Dal.JBHR._System.System_View_SysRole>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysPage, JBHRIS.Api.Dal.JBHR._System.System_View_SysPage>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysRolePage, JBHRIS.Api.Dal.JBHR._System.System_View_SysRolePage>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysPageApiVoid, JBHRIS.Api.Dal.JBHR._System.System_View_SysPageApiVoid>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysUserRole, JBHRIS.Api.Dal.JBHR._System.System_View_SysUserRole>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysApiVoid, JBHRIS.Api.Dal.JBHR._System.System_View_SysApiVoid>();
            services.AddScoped<JBHRIS.Api.Dal._System.View.ISystem_View_SysNews, JBHRIS.Api.Dal.JBHR._System.View.System_View_SysNews>();
            services.AddScoped<JBHRIS.Api.Bll.Attendance.Normal.ICardTextRecordConvertBll, JBHRIS.Api.Bll.Attendance.CardTextRecordConvertBll>();
            services.AddScoped<JBHRIS.Api.Service.Attendance.IWorkScheduleFactory, JBHRIS.Api.Service.Attendance.WorkScheduleFactory>();

            services.AddScoped<JBHRIS.Api.Dal.JBHR.Repository.IUnitOfWork, JBHRIS.Api.Dal.JBHR.Repository.JbhrUnitOfWork>();
            services.AddScoped<DbContext, JBHRIS.Api.Dal.JBHR.JBHRContext>();
            return services;
        }
    }
}
