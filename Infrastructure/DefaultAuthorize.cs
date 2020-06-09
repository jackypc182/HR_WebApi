using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HR_WebApi.Infrastructure
{
    /// <summary>
    /// 預設驗證授權內容
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DefaultAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (AllowAnonymouse(context))
                return;

            #region 測試區塊(展示如果授權不過如何處理)
            IEnumerable<string> roles = (Roles?.Split(","));

            if (roles != null && roles.Any(s => s == "test"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            #endregion
        }

        /// <summary>
        /// 允許匿名存取
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool AllowAnonymouse(AuthorizationFilterContext context) =>
            context.Filters.Any(o => o is AllowAnonymousFilter);

        public string Roles { get; set; }
    }
}
