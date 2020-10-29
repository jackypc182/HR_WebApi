using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.Result;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog.LayoutRenderers.Wrappers;

namespace HR_WebApi.Controllers.Attendance
{
    /// <summary>
    /// 考勤服務
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private IAttendanceService _attendanceService;
        private IAbsenceService _absenceService;
        private IOvertimeService _overtimeService;
        private JBHRContext _context;

        public AttendanceController(IAttendanceService attendanceService,
            IAbsenceService absenceService,
            IOvertimeService overtimeService,
            JBHRContext context)
        {
            _context = context;
            _absenceService = absenceService;
            _attendanceService = attendanceService;
            _overtimeService = overtimeService;
        }
        /// <summary>
        /// 取得考勤資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetAttendance")]
        [HttpPost]
        public List<AttendanceDto> GetAttendance([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetAttendance(attendanceEntry);
        }
        /// <summary>
        /// 取得行事曆資料(包含請假、加班、刷卡、班別資訊、異常資料)
        /// </summary>
        [Route("GetCalendar")]
        [HttpPost]
        public CalendarResultDto GetCalendar(AttendanceCalendarEntry attendanceCalendarEntry)   
        {

            var attendRotes = from att in _context.Attend
                              join r in _context.Rote on att.Rote equals r.Rote1
                              where attendanceCalendarEntry.EmployeeList.Contains(att.Nobr)
                              && attendanceCalendarEntry.DateBegin <= att.Adate && att.Adate <= attendanceCalendarEntry.DateEnd
                              select new { att, r };

            var attendCards = from card in _context.Attcard
                              where attendanceCalendarEntry.EmployeeList.Contains(card.Nobr)
                              && attendanceCalendarEntry.DateBegin <= card.Adate 
                              && card.Adate <= attendanceCalendarEntry.DateEnd
                              select card;

            var abss = new List<AbsenceTakenDto>();
            abss = _absenceService.GetAbsenceTaken(new AbsenceEntry()
            {
                EmployeeList = attendanceCalendarEntry.EmployeeList,
                DateBegin = attendanceCalendarEntry.DateBegin,
                DateEnd = attendanceCalendarEntry.DateEnd,
                HcodeList = new List<string>()
            }); ;

            var ots = new List<OvertimeDto>();
            ots = _overtimeService.GetOvertime(new AttendanceEntry()
            { 
                EmployeeList = attendanceCalendarEntry.EmployeeList,
                DateBegin = attendanceCalendarEntry.DateBegin,
                DateEnd = attendanceCalendarEntry.DateEnd 
            });

            var abnormalsSql = from aa in _context.AttendAbnormal
                               join mt in _context.Mtcode on new { X1 = aa.Type, X2 = "ATTEND_ABNORMAL" } equals new { X1 = mt.Code, X2 = mt.Category }
                               join bs in _context.Base on aa.Nobr equals bs.Nobr
                               join rt in _context.Rote on aa.RoteCode equals rt.Rote1
                               join aac in _context.AttendAbnormalCheck on new { X1 = aa.Nobr, X2 = aa.Adate, X3 = aa.Type } equals new { X1 = aac.Nobr, X2 = aac.Adate, X3 = aac.Type }
                               into accGrp
                               from acg in accGrp.DefaultIfEmpty()
                               join mt1 in _context.Mtcode on new { X1 = "ATTEND_ABNORMAL_CHECK", X2 = acg.RemarkType } equals new { X1 = mt1.Category, X2 = mt1.Code }
                               into mt1Grp
                               from dmt1 in mt1Grp.DefaultIfEmpty()
                               where attendanceCalendarEntry.EmployeeList.Contains(aa.Nobr)
                               && attendanceCalendarEntry.DateBegin <= aa.Adate
                               && aa.Adate <= attendanceCalendarEntry.DateEnd
                               select new AbnormalViewDto()
                               {
                                   EmployeeId = aa.Nobr,
                                   EmployeeName = bs.NameC,
                                   AttendanceDate = aa.Adate,
                                   Type = aa.Type,
                                   State = mt.Name,
                                   ErrorMins = aa.ErrorMins,
                                   OnTime = aa.OnTime,
                                   OffTime = aa.OffTime,
                                   ActualOnTime = aa.OnTimeActual,
                                   ActualOffTime = aa.OffTimeActual,
                                   RoteName = rt.Rotename,
                                   IsCheck = false,
                                   Remark = dmt1.Name,
                                   Serno = acg.Serno,
                                   RemarkType = acg.RemarkType
                               };
            List<AbnormalViewDto> listAbnormals = new List<AbnormalViewDto>();
            listAbnormals = abnormalsSql.ToList();
            listAbnormals.ForEach(a =>
            {
                if (!String.IsNullOrEmpty(a.Remark))
                {
                    a.IsCheck = true; 
                }
            });


            List<CalendarDto> attendanceCalendarDtos = new List<CalendarDto>();
            attendRotes.ToList().ForEach(a => {
                if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Attend"))
                {
                    #region 出勤
                    attendanceCalendarDtos.Add(new CalendarDto()
                    {
                        CalendarDate = a.att.Adate,
                        CalendarType = "Attend",
                        Color = "fff",
                        BeginTime = a.r.OnTime,
                        EndTime = a.r.OffTime,
                        EmployeeId = a.att.Nobr,
                        Remark = null,
                        Use = a.r.WkHrs,
                        Name = a.r.Rotename
                    });
                    #endregion
                }
                if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Abnormal"))
                {
                    #region 遲到
                    if (a.att.LateMins > 0)
                    {
                        attendanceCalendarDtos.Add(new CalendarDto()
                        {
                            CalendarDate = a.att.Adate,
                            CalendarType = "LateMins",
                            Color = "fff",
                            BeginTime = a.r.OnTime,
                            EndTime = a.r.OffTime,
                            EmployeeId = a.att.Nobr,
                            Remark = null,
                            Use = a.att.LateMins,
                            Name = "遲到"
                        });
                    }
                    #endregion
                    #region 早退
                    if (a.att.EMins > 0)
                    {
                        attendanceCalendarDtos.Add(new CalendarDto()
                        {
                            CalendarDate = a.att.Adate,
                            CalendarType = "EMins",
                            Color = "fff",
                            BeginTime = a.r.OnTime,
                            EndTime = a.r.OffTime,
                            EmployeeId = a.att.Nobr,
                            Remark = null,
                            Use = a.att.EMins,
                            Name = "早退"
                        });
                    }
                    #endregion
                    #region 忘刷
                    if (a.att.Forget > 0)
                    {
                        attendanceCalendarDtos.Add(new CalendarDto()
                        {
                            CalendarDate = a.att.Adate,
                            CalendarType = "Forget",
                            Color = "fff",
                            BeginTime = a.r.OnTime,
                            EndTime = a.r.OffTime,
                            EmployeeId = a.att.Nobr,
                            Remark = null,
                            Use = 1,
                            Name = "忘刷"
                        });
                    }
                    #endregion
                    #region 曠職
                    if (a.att.Abs)
                    {
                        attendanceCalendarDtos.Add(new CalendarDto()
                        {
                            CalendarDate = a.att.Adate,
                            CalendarType = "Absenteeism",
                            Color = "fff",
                            BeginTime = a.r.OnTime,
                            EndTime = a.r.OffTime,
                            EmployeeId = a.att.Nobr,
                            Remark = null,
                            Use = a.att.EMins,
                            Name = "曠職"
                        });
                    }
                    #endregion
                }
            });

            #region 刷卡
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Card"))
            {
                //刷卡
                attendCards.ToList().ForEach(a =>
                {
                    attendanceCalendarDtos.Add(new CalendarDto()
                    {
                        CalendarDate = a.Adate,
                        CalendarType = "Card",
                        Color = "fff",
                        BeginTime = a.T1,
                        EndTime = a.T2,
                        EmployeeId = a.Nobr,
                        Remark = null,
                        Use = 0,
                        Name = "刷卡"
                    });
                });
            }
            #endregion
            #region 請假
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Abs"))
            {
                //請假
                abss.ForEach(a =>
                {
                    attendanceCalendarDtos.Add(new CalendarDto()
                    {
                        CalendarDate = a.BeginDate,
                        CalendarType = "Abs",
                        Color = "fff",
                        BeginTime = a.BeginTime,
                        EndTime = a.EndTime,
                        EmployeeId = a.EmployeeID,
                        Remark = a.AbsenceUnit,
                        Use = a.AbsenceAmount,
                        Name = a.HolidayName
                    });
                });
            }
            #endregion
            #region 加班
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Ot"))
            {
                //加班
                ots.ForEach(a =>
                {
                    attendanceCalendarDtos.Add(new CalendarDto()
                    {
                        CalendarDate = a.OverTimeDate,
                        CalendarType = "Ot",
                        Color = "fff",
                        BeginTime = a.BeginTime,
                        EndTime = a.EndTime,
                        EmployeeId = a.EmployeeID,
                        Remark = null,
                        Use = a.OverTimeHours,
                        Name = "加班"
                    });
                });
            }
            #endregion
            #region 異常 ex:早來、晚走
            if (attendanceCalendarEntry.AttendTypeList.Contains("AttendType_Abnormal"))
            {
                listAbnormals.ForEach(a =>
                {
                    if (a.IsCheck)
                    {
                        attendanceCalendarDtos.Add(new CalendarDto()
                        {
                            CalendarDate = a.AttendanceDate,
                            CalendarType = a.Type,
                            Color = "fff",
                            BeginTime = a.ActualOnTime,
                            EndTime = a.ActualOffTime,
                            EmployeeId = a.EmployeeId,
                            Remark = null,
                            Use = 0,
                            Name = a.State
                        });
                    }
                });
            }
            #endregion

            CalendarResultDto calendarResultDto = new CalendarResultDto();
            calendarResultDto.result = attendanceCalendarDtos;
            calendarResultDto.State = true;

            return calendarResultDto;
        }
        /// <summary>
        /// 取得調班資料
        /// </summary>
        /// <param name="attendanceEntry"></param>
        /// <returns></returns>
        [Route("GetRoteChange")]
        [HttpPost]
        public List<RoteChangeDto> GetRoteChange([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetRoteChange(attendanceEntry);
        }
        /// <summary>
        /// 取得異常名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleAbnormal")]
        [HttpPost]
        public List<string> GetPeopleAbnormal([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetPeopleAbnormal(attendanceEntry);
        }
        /// <summary>
        /// 取得工作名單
        /// </summary>
        /// <param name="attendanceEntry"></param>
        [Route("GetPeopleWork")]
        [HttpPost]
        public List<string> GetPeopleWork([FromBody]AttendanceRoteEntry attendanceEntry)
        {
            return _attendanceService.GetPeopleWork(attendanceEntry);
        }
        
        /// <summary>
        /// 取得班別代碼
        /// </summary>
        /// <returns></returns>
        [Route("GetRote")]
        [HttpPost]
        public List<RoteDto> GetRote()
        {
            return _attendanceService.GetRote();
        }
        /// <summary>
        /// 取得行事曆
        /// </summary>
        [Route("GetAttendCalendar")]
        [HttpPost]
        public void GetAttendCalendar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 出勤種類
        /// </summary>
        [Route("GetAttendType")]
        [HttpGet]
        public AttendanceTypeResultDto GetAttendType()
        {
            List<AttendanceTypeDto> attendanceTypes = new List<AttendanceTypeDto>() 
            {
                new AttendanceTypeDto(){Code = "AttendType_Attend", Name = "出勤",Sort = 1,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Card", Name = "刷卡",Sort = 2,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Abs", Name = "請假",Sort = 3,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Ot", Name = "加班",Sort = 4,Display = true},
                new AttendanceTypeDto(){Code = "AttendType_Abnormal", Name = "異常",Sort = 5,Display = true},
            };
            AttendanceTypeResultDto attendanceTypeResultDto = new AttendanceTypeResultDto();
            attendanceTypeResultDto.result = attendanceTypes;
            attendanceTypeResultDto.State = true;

            return attendanceTypeResultDto;
        }

        /// <summary>
        /// 出勤明細表
        /// </summary>
        [Route("GetAttendDetail")]
        [HttpPost]
        public AttendanceDetailResultDto GetAttendDetail(AttendanceDetailEntry attendanceDetailEntry)
        {
            List<AttendanceDetailDto> attendanceDetailDtos = new List<AttendanceDetailDto>();
            AttendanceEntry attendanceEntry = new AttendanceEntry() { };

            var attends = from att in _context.Attend
                          where attendanceDetailEntry.EmployeeList.Contains(att.Nobr)
                          && attendanceDetailEntry.DateBegin <= att.Adate && att.Adate <= attendanceDetailEntry.DateEnd
                          select att;

            var bases = from bs in _context.Base where attendanceDetailEntry.EmployeeList.Contains(bs.Nobr) select bs;

            var attendCards = from card in _context.Attcard where attendanceDetailEntry.EmployeeList.Contains(card.Nobr)
                             && attendanceDetailEntry.DateBegin <= card.Adate && card.Adate <= attendanceDetailEntry.DateEnd
                             select card;

            var abss = new List<AbsenceTakenDto>();
                abss = _absenceService.GetAbsenceTaken(new AbsenceEntry()
                {
                    EmployeeList = attendanceDetailEntry.EmployeeList,
                    DateBegin = attendanceDetailEntry.DateBegin,
                    DateEnd = attendanceDetailEntry.DateEnd,
                    HcodeList = new List<string>()
                }); ;

            var ots = new List<OvertimeDto>();
                ots = _overtimeService.GetOvertime(new AttendanceEntry() { EmployeeList = attendanceDetailEntry.EmployeeList, DateBegin = attendanceDetailEntry.DateBegin ,DateEnd = attendanceDetailEntry.DateEnd});


            var abnormalsSql = from aa in _context.AttendAbnormal
                               join mt in _context.Mtcode on new { X1 = aa.Type, X2 = "ATTEND_ABNORMAL" } equals new { X1 = mt.Code, X2 = mt.Category }
                               join bs in _context.Base on aa.Nobr equals bs.Nobr
                               join rt in _context.Rote on aa.RoteCode equals rt.Rote1
                               join aac in _context.AttendAbnormalCheck on new { X1 = aa.Nobr, X2 = aa.Adate, X3 = aa.Type } equals new { X1 = aac.Nobr, X2 = aac.Adate, X3 = aac.Type }
                               into accGrp
                               from acg in accGrp.DefaultIfEmpty()
                               join mt1 in _context.Mtcode on new { X1 = "ATTEND_ABNORMAL_CHECK", X2 = aa.Type } equals new { X1 = mt1.Category, X2 = mt1.Code }
                               into mt1Grp
                               from d in mt1Grp.DefaultIfEmpty()
                               where attendanceDetailEntry.EmployeeList.Contains(aa.Nobr)
                               && attendanceDetailEntry.DateBegin <= aa.Adate
                               && aa.Adate <= attendanceDetailEntry.DateEnd
                               select new AbnormalViewDto()
                               {
                                   EmployeeId = aa.Nobr,
                                   EmployeeName = bs.NameC,
                                   AttendanceDate = aa.Adate,
                                   Type = aa.Type,
                                   State = mt.Name,
                                   ErrorMins = aa.ErrorMins,
                                   OnTime = aa.OnTime,
                                   OffTime = aa.OffTime,
                                   ActualOnTime = aa.OnTimeActual,
                                   ActualOffTime = aa.OffTimeActual,
                                   RoteName = rt.Rotename,
                                   IsCheck = false,
                                   Remark = acg.Remark,
                                   Serno = acg.Serno,
                                   RemarkType = acg.RemarkType
                               };

            List<AbnormalViewDto> listAbnormals = new List<AbnormalViewDto>();
            listAbnormals = abnormalsSql.ToList();
            listAbnormals.ForEach(a =>
            {
                if (!String.IsNullOrEmpty(a.Remark))
                {
                    a.IsCheck = true;
                }
            });

            var rotes = from r in _context.Rote select r;
            var data = from att in attends
                       join b in bases on att.Nobr equals b.Nobr
                       join r in rotes on att.Rote equals r.Rote1
                       join ac in attendCards
                       on new { X1 = att.Nobr, X2 = att.Adate } equals new { X1 = ac.Nobr, X2 = ac.Adate }
                       into acGrp
                       from ac in acGrp.DefaultIfEmpty()
                       select new AttendanceDetailDto()
                       {
                           EmployeeId = b.Nobr.ToString(),
                           EmployeeName = b.NameC.ToString(),
                           AttendDate = att.Adate,
                           RoteCode = r.Rote1,
                           RoteName = r.Rotename,
                           RoteDateB = att.Adate.ToShortDateString(),
                           RoteDateE = att.Adate.ToShortDateString(),
                           RoteTimeB = r.OnTime,
                           RoteTimeE = r.OffTime,
                           CardDateB = ac.Adate.ToShortDateString(),
                           CardDateE = ac.Adate.ToShortDateString(),
                           CardTimeB = ac.T1,
                           CardTimeE = ac.T2,
                           LateMin = att.LateMins,
                           EarlyMin = att.EMins,
                           Forget = att.Forget,
                           IsAbs = att.Abs,
                           ListAbs = null,
                           ListOt = null,
                           ListAbnormal = null
                       };
            attendanceDetailDtos = data.ToList();
            attendanceDetailDtos.ForEach(d =>
            {
                d.ListAbs = new List<AbsenceTakenDto>();
                d.ListOt = new List<OvertimeDto>();
                d.ListAbnormal = new List<CheckAbnormalDto>();
                abss.ForEach(abs =>
                {
                    if(d.AttendDate == abs.BeginDate && d.EmployeeId == abs.EmployeeID)
                    {
                        d.ListAbs.Add(abs);
                    }
                });

                ots.ForEach(ot =>
                {
                    if (d.AttendDate == ot.OverTimeDate && d.EmployeeId == ot.EmployeeID)
                    {
                        d.ListOt.Add(ot);
                    }
                });

                listAbnormals.ForEach(abno =>
                {
                    if (d.AttendDate == abno.AttendanceDate && d.EmployeeId == abno.EmployeeId)
                    {
                        CheckAbnormalDto checkAbnormalDto = new CheckAbnormalDto() 
                        { 
                            Type = abno.Type,
                            Name = abno.State,
                            Check = abno.IsCheck,
                            Mins = abno.ErrorMins
                        };
                        d.ListAbnormal.Add(checkAbnormalDto);
                    }
                });
            });

            AttendanceDetailResultDto attendanceDetailResultDto = new AttendanceDetailResultDto();
            attendanceDetailResultDto.result = attendanceDetailDtos;
            attendanceDetailResultDto.State = true;

            return attendanceDetailResultDto;
        }
    }
}