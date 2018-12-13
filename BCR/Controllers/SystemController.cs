
using BCR.Models;
using Interfaces;
using Interfaces.Impl;
using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using System;

namespace BCR.Controllers
{

    public class SystemController : Controller
    {
        public ISystemService systemService;
        private ISystemService SystemService
        {
            get
            {
                if (systemService == null)
                {
                    systemService = new SystemService();
                }
                return systemService;
            }
        }
        public static string connstr = "";
        public static IHttpContextAccessor _accessor;
        public readonly IConfiguration _configuration;
        public SystemController(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
            connstr = configuration["connstr:mysql"];
        }
        [NoPermissionRequired]
        public IActionResult Login()
        {
            return View();
        }
        [NoPermissionRequired]
        public ResponseResult<string> PostLogins(string username, string password)
        {
            if (!string.IsNullOrEmpty(username.Trim()) && !string.IsNullOrEmpty(password.Trim()))
            {
                try
                {
                    string token = "";
                    password = MD5Utils.decode(password);
                    var user = SystemService.AuthUser(username, password, connstr);
                    if (user != null)
                    {
                        JwtUtils jwt = new JwtUtils();
                        JwtHeader header = new JwtHeader();
                        header.alg = AlgEnum.HS256;
                        JwtClaim claim = new JwtClaim();
                        claim.isadmin = user.AREA == 0 ? true : false;
                        claim.area = user.AREA;
                        claim.uid = user.ID;
                        claim.username = user.USERNAME;
                        claim.exp = DateTime.Now.AddMinutes(30).ToBinary();
                        token = jwt.EncodingJwt(header, claim);
                        return ResponseResult<string>.Success(token, "登录成功");
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    return ResponseResult<string>.Error("登录失败");
                }
            }
            return ResponseResult<string>.Error("登录失败");
        }
        [NoPermissionRequired]
        public IActionResult Logout()
        {
            //应该清除localstorage
            return View("Login");
        }
        [NoPermissionRequired]
        public IActionResult Error()
        {
            return View();
        }

    }
}