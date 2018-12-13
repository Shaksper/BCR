using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BCR.Controllers
{
    public class BaseController : Controller
    {
        public static IHttpContextAccessor _accessor;
        public readonly IConfiguration _configuration;
        public static string connstr = "";
        public BaseController(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
            connstr = configuration["connstr:mysql"];

        }
       
    }
}