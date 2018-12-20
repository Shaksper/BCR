using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BCR.Controllers
{
    public class ReportController : BaseController
    {
        public JwtClaim claim;
        public ReportController(IHttpContextAccessor accessor, IConfiguration configuration) : base(accessor, configuration)
        {
            connstr = configuration["connstr:mysql"];
        }
        /// <summary>
        /// 周报
        /// </summary>
        /// <returns></returns>
        public IActionResult Weekly()
        {
            return View();
        }
        /// <summary>
        /// 月报
        /// </summary>
        /// <returns></returns>
        public IActionResult Monthly()
        {
            return View();
        }
    }
}