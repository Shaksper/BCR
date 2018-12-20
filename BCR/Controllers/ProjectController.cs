
using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BCR.Controllers
{
    public class ProjectController : BaseController
    {
        public JwtClaim claim;
        public ProjectController(IHttpContextAccessor accessor, IConfiguration configuration) : base(accessor, configuration)
        {
            connstr = configuration["connstr:mysql"];
        }

        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 项目看板
        /// </summary>
        /// <returns></returns>
        public IActionResult ProjectTab()
        {
            return View();
        }
    }
}