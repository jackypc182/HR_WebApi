using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Hangfire.Annotations;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto.Menu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_WebApi.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private JBHRContext _context;
        public MenuController(JBHRContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 取得選單功能
        /// </summary>
        [Route("GetMenu")]
        [HttpGet]
        public GetMenuResultDto GetMenu()
        {
            var MenuSql = from f in _context.FileStructure
                          select f;
            var Menus = MenuSql.ToList();
            List<SysMenuDto> sysMenus = new List<SysMenuDto>();
            Menus.ForEach(m =>
            {
                sysMenus.Add(new SysMenuDto()
                {
                    Code = m.Code,
                    SPath = m.SPath,
                    SFileName = m.SIconName,
                    SFileTitle = m.SFileTitle,
                    SParentKey = m.SParentKey,
                    SidePath = "",
                    IconName = m.SIconName,
                    Tag = m.NoticeTitle,
                    IOrder = m.IOrder,
                    KeyMan = m.SKeyMan,
                    KeyDate = m.DKeyDate,
                });
            });
            sysMenus.ForEach(m =>
            {
                m.SidePath = repeatSite(sysMenus, m);
            });
            GetMenuResultDto getMenuResultDto = new GetMenuResultDto();
            getMenuResultDto.result = sysMenus;
            getMenuResultDto.State = true;

            return getMenuResultDto;
        }

        private static string repeatSite(List<SysMenuDto> listMenus, SysMenuDto r)
        {
            IEnumerable<SysMenuDto> parentSql;
            parentSql = from listm in listMenus
                        where listm.Code == r.SParentKey
                        select listm;
            List<SysMenuDto> parents = parentSql.ToList();
            if (parents.Count > 0)
            {
                SysMenuDto p = parents[0];
                r.SidePath = p.Code + "/" + r.Code + "/" + p.SidePath;
                repeatSite(parents, p);
            }
            return r.SidePath;
        }
    }
}
