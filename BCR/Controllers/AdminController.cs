using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCR.Models;
using Interfaces;
using Interfaces.Impl;
using Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;

namespace BCR.Controllers
{
    public class AdminController : BaseController
    {
        public JwtClaim claim;
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
        public AdminController(IHttpContextAccessor accessor, IConfiguration configuration) : base(accessor, configuration)
        {
            connstr = configuration["connstr:mysql"];
        }
        #region areainfo

        [PermitFilter]
        public IActionResult Area()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            return View();
        }
        [PermitFilter]
        public string getArea()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            List<SYS_AREA> model = SystemService.getArea(connstr);
            LayTableModel<List<SYS_AREA>> table = new LayTableModel<List<SYS_AREA>>();
            table.message = "success";
            table.code = 200;
            table.total = model.Count;
            table.rows = new Rows<List<SYS_AREA>>();
            table.rows.item = new List<SYS_AREA>();
            table.rows.item = model;
            return JsonConvert.SerializeObject(table);
        }
        [PermitFilter]
        public IActionResult editArea(int id)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            List<SYS_AREA> model = SystemService.getArea(connstr);
            var res = model.Where(m => m.ID == id).FirstOrDefault();
            ViewBag.model = res;
            return View();
        }
        [PermitFilter]
        public IActionResult addArea()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            ViewBag.model = null;
            return View("editArea");
        }
        [PermitFilterAttribute]
        [HttpPost]
        public ResponseResult<string> addArea([FromQuery]string token, string name, string abb)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                if (string.IsNullOrEmpty(name)||string.IsNullOrEmpty(abb))
                {
                    return ResponseResult<string>.Error("参数异常");
                }
                SYS_AREA area = new SYS_AREA { NAME=name,ABBREVIATION=abb};
                var b = SystemService.addArea(area, connstr);
                if (b)
                {
                    return ResponseResult<string>.Success("操作成功", "操作成功");
                }
                else
                {
                    return ResponseResult<string>.Success("操作失败", "操作失败");
                }
            }
            catch (Exception ex)
            {
                return ResponseResult<string>.Error("系统异常");
            }
        }

        #endregion

        #region roominfo

        [PermitFilter]
        public IActionResult RoomInfo()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            return View();
        }
        [PermitFilter]
        public string getRoom()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            List<SYS_ROOMINFO> model = SystemService.getRoom(connstr);
            LayTableModel<List<SYS_ROOMINFO>> table = new LayTableModel<List<SYS_ROOMINFO>>();
            table.message = "success";
            table.code = 200;
            table.total = model.Count;
            table.rows = new Rows<List<SYS_ROOMINFO>>();
            table.rows.item = new List<SYS_ROOMINFO>();
            table.rows.item = model;
            return JsonConvert.SerializeObject(table);
        }
        [PermitFilter]
        public IActionResult editRoom(int id)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            List<SYS_ROOMINFO> model = SystemService.getRoom(connstr);
            var res = model.Where(m => m.ID == id).FirstOrDefault();
            ViewBag.model = res;
            return View();
        }
        
        [PermitFilter]
        public IActionResult addRoom()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            ViewBag.model = null;
            return View("editRoom");
        }
        [PermitFilterAttribute]
        [HttpPost]
        public ResponseResult<string> addRoom([FromQuery]string token, string name, int area,int status)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return ResponseResult<string>.Error("参数异常");
                }
                SYS_ROOMINFO room = new SYS_ROOMINFO { NAME = name,AREA=area,STATUS=status};
                var b = SystemService.addRoom(room, connstr);
                if (b)
                {
                    return ResponseResult<string>.Success("操作成功", "操作成功");
                }
                else
                {
                    return ResponseResult<string>.Success("操作失败", "操作失败");
                }
            }
            catch (Exception ex)
            {
                return ResponseResult<string>.Error("系统异常");
            }
        }

        #endregion

        #region userinfo

        [PermitFilter]
        public IActionResult UserInfo()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            return View();
        }
        [PermitFilter]
        public string getUser()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            List<SYS_USER> model = SystemService.getUser(connstr);
            LayTableModel<List<SYS_USER>> table = new LayTableModel<List<SYS_USER>>();
            table.message = "success";
            table.code = 200;
            table.total = model.Count;
            table.rows = new Rows<List<SYS_USER>>();
            table.rows.item = new List<SYS_USER>();
            table.rows.item = model;
            return JsonConvert.SerializeObject(table);
        }
        [PermitFilter]
        public IActionResult editUser(string id)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            List<SYS_USER> model = SystemService.getUser(connstr);
            var res = model.Where(m => m.ID == id).FirstOrDefault();
            ViewBag.model = res;
            return View();
        }

        [PermitFilter]
        public IActionResult addUser()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            ViewBag.model = null;
            return View("editUser");
        }
        [PermitFilterAttribute]
        [HttpPost]
        public ResponseResult<string> addUser([FromQuery]string token, string username, int area, string password,string email)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password)||area==0)
                {
                    return ResponseResult<string>.Error("参数异常");
                }
                SYS_USER room = new SYS_USER { ID=Guid.NewGuid().ToString(),USERNAME=username,PASSWORD=MD5Utils.decode(password),AREA=area,EMAIL=email,UPDATETIME=DateTime.Now};
                var b = SystemService.addUser(room, connstr);
                if (b)
                {
                    return ResponseResult<string>.Success("操作成功", "操作成功");
                }
                else
                {
                    return ResponseResult<string>.Success("操作失败", "操作失败");
                }
            }
            catch (Exception ex)
            {
                return ResponseResult<string>.Error("系统异常");
            }
        }
        [PermitFilter]
        public IActionResult editPwd() {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            return View();
        }
        [PermitFilterAttribute]
        [HttpPost]
        public ResponseResult<string> editPwd([FromQuery]string token, string name, int area, string oldpwd, string newpwd)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                var user=SystemService.getUser(connstr).Where(u => u.USERNAME == name.Trim() && u.AREA == area&&u.PASSWORD==MD5Utils.decode(oldpwd)).FirstOrDefault();
                if (user==null)
                {
                    return ResponseResult<string>.Error("密码验证不通过");
                }
                var PASSWORD = MD5Utils.decode(newpwd);
                var b = SystemService.editUserPwd(user.ID,PASSWORD, connstr);
                if (b)
                {
                    return ResponseResult<string>.Success("操作成功", "操作成功");
                }
                else
                {
                    return ResponseResult<string>.Error("操作失败");
                }
            }
            catch (Exception ex)
            {
                return ResponseResult<string>.Error("系统异常");
            }
        }
        #endregion

        #region bookinfo

        [PermitFilter]
        public IActionResult BookInfo()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            return View();
        }
        [PermitFilter]
        public string getBook()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            List<SYS_BOOKINFO> model = SystemService.getBook(connstr);
            LayTableModel<List<SYS_BOOKINFO>> table = new LayTableModel<List<SYS_BOOKINFO>>();
            table.message = "success";
            table.code = 200;
            table.total = model.Count;
            table.rows = new Rows<List<SYS_BOOKINFO>>();
            table.rows.item = new List<SYS_BOOKINFO>();
            table.rows.item = model;
            return JsonConvert.SerializeObject(table);
        }
        [PermitFilterAttribute]
        [HttpPost]
        public ResponseResult<string> delBook([FromQuery]string token, int id)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                if (id == 0)
                {
                    return ResponseResult<string>.Error("参数异常");
                }
                var b = SystemService.delBook(id, connstr);
                if (b)
                {
                    return ResponseResult<string>.Success("操作成功", "操作成功");
                }
                else
                {
                    return ResponseResult<string>.Success("操作失败", "操作失败");
                }
            }
            catch (Exception ex)
            {
                return ResponseResult<string>.Error("系统异常");
            }
        }
        #endregion
    }
}