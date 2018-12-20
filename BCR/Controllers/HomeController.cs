using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Interfaces;
using Interfaces.Impl;
using Models;
using Library;

namespace BCR.Controllers
{
    public class HomeController : BaseController
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
        private IToDoService _toDoService;
        public IToDoService ToDoService
        {
            get
            {
                if (_toDoService == null)
                {
                    _toDoService = new ToDoService();
                }
                return _toDoService;
            }
        }
        public HomeController(IHttpContextAccessor accessor, IConfiguration configuration) : base(accessor, configuration)
        {
            connstr = configuration["connstr:mysql"];
        }

        [PermitFilterAttribute]
        public IActionResult Index()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            List<SelectListItem> items = new List<SelectListItem>();
            var rooms = ToDoService.getPriority(connstr);
            foreach (var item in rooms)
            {
                items.Add(new SelectListItem
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                });
            }
            items.FirstOrDefault().Selected = true;
            ViewBag.Items = items;
            return View();
        }
        [PermitFilterAttribute]
        public IActionResult Book()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            //根据区域获取会议室信息
            List<SelectListItem> items = new List<SelectListItem>();
            var rooms=SystemService.GetRoomInfo(connstr).Where(r => r.AREA == claim.area);
            foreach (var item in rooms)
            {
                items.Add(new SelectListItem {
                    Text=item.NAME,
                    Value=item.ID.ToString()
                });
            }
            items.FirstOrDefault().Selected = true;
            ViewBag.Items = items;
            return View();
        }
        /// <summary>
        ///  meetname: data.field.meetname, room: data.field.room, day: data.field.day, hour: data.field.hour, status: data.field.status
        /// </summary>
        /// <returns></returns>
        [PermitFilterAttribute]
        [HttpPost]
        public ResponseResult<string> PostBook([FromQuery]string token,string meetname,string room,string day,string hour,int status)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
            //判断会议室是否停用
            bool isstop=SystemService.IsStop(room, connstr);
            if (!isstop)
            {
                var h= hour.Split('至');
                var start_hh=h[0].Split(':');
                var start_hor = start_hh[0];
                var start_min =start_hh.Count()<=1?"00": start_hh[1];
                var end_hh = h[1].Split(':');
                var end_hor = end_hh[0];
                var end_min = end_hh.Count() <= 1 ? "00" : end_hh[1];
                var starttime =DateTime.Parse( day + " " + start_hor + ":" + start_min);
                var endtime =DateTime.Parse( day + " " + end_hor + ":" + end_min);
                if (starttime<=DateTime.Now)
                {
                    return ResponseResult<string>.Success("你是要穿越吗？", "你是要穿越吗？");
                }
                //判断时段是否可用
                bool enable=SystemService.AuthTime(room,starttime, endtime, connstr);
                if (enable)
                {
                        //入库
                        SYS_BOOKINFO book = new SYS_BOOKINFO {
                            MEETNAME=meetname,
                            ROOMID=room,
                            STARTTIME=starttime,
                            ENDTIME=endtime,
                            STATUS=status,
                            UID= claim.uid
                        };
                        var b=SystemService.BookRoom(book,connstr);
                        if (b)
                        {
                            return ResponseResult<string>.Success("操作成功", "操作成功");
                        }
                        else
                        {
                            return ResponseResult<string>.Success("操作失败", "操作失败");
                        }
                }
                else
                {
                    return ResponseResult<string>.Success("时间冲突", "时间冲突");
                }
            }
            else
            {
                return ResponseResult<string>.Success("会议室已停用", "会议室已停用");
                }
            }
            catch (Exception ex)
            {
                return ResponseResult<string>.Error("系统异常");
            }
        }

    }
}
