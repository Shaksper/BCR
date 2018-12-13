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
        //public static string uid = "";
        //public static string username = "";
        //public static int area =0;
        public static string connstr = "";
        //public static bool isadmin = false;
        public BaseController(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
            connstr = configuration["connstr:mysql"];
            //JwtUtils jwt = new JwtUtils();
            //var token = _accessor.HttpContext.Request.Query["token"];
            //var claim = jwt.DecodingJwt(token);
            //uid = claim.uid;
            //username = claim.username;
            //area = claim.area;
            //isadmin = claim.isadmin;

        }
       
    }
}