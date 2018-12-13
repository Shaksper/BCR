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
using Microsoft.Extensions.Options;
using Models;
using Newtonsoft.Json;

namespace BCR.Controllers
{
    public class RoomController : BaseController
    {
        public JwtClaim claim;
        private IRoomService _roomService;
        public IRoomService RoomService
        {
            get
            {
                if (_roomService == null)
                {
                    _roomService = new RoomService();
                }
                return _roomService;
            }
        }
      
        public RoomController(IHttpContextAccessor accessor, IConfiguration configuration) : base(accessor, configuration)
        {
        }

        [PermitFilterAttribute]
        public IActionResult ShowLF(DateTime time)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            if (time == DateTime.MinValue || time == null)
            {
                time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            List<ShowModel> showModels = getStatus(claim.area, time);
            ViewBag.model = showModels;
            ViewBag.actionname = "ShowLF";
            ViewBag.time = time;
            return View("Show");
        }
        [PermitFilterAttribute]
        public IActionResult ShowBJ(DateTime time)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            if (time == DateTime.MinValue || time == null)
            {
                time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            List<ShowModel> showModels = getStatus(claim.area, time);
            ViewBag.model = showModels;
            ViewBag.actionname = "ShowBJ";
            ViewBag.time = time;
            return View("Show");
        }
        [PermitFilterAttribute]
        public IActionResult ShowJN(DateTime time)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            ViewBag.username = claim.username;
            ViewBag.area = claim.area;
            if (time == DateTime.MinValue || time == null)
            {
                time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            List<ShowModel> showModels = getStatus(claim.area, time);
            ViewBag.model = showModels;
            ViewBag.actionname = "ShowJN";
            ViewBag.time = time;
            return View("Show");
            
        }

        private List<ShowModel> getStatus(int area,DateTime time)
        {
            var bookd = RoomService.AreaBook(area, connstr);
            //按照会议室名称分组
            var namegroup = bookd.GroupBy(b => b.roomname);
            bookd = bookd.Where(b => b.starttime.Year == time.Year && b.starttime.Month == time.Month && b.starttime.Day == time.Day).ToList();
            List<ShowModel> showModels = new List<ShowModel>();
            foreach (var item in namegroup)
            {
                for (int i = 7; i <= 22; i++)
                {
                    var init = DateTime.Parse(time.Year + "-" + time.Month + "-" + time.Day + " " + i + ":00");
                    var _115 = init;
                    var _1530 = init.AddMinutes(15);
                    var _3045 = init.AddMinutes(30);
                    var _4560 = init.AddMinutes(45);
                    var nesthour = init.AddHours(1);
                    var value115 = item.Where(d => d.starttime <= init && d.endtime >= _1530);
                    var value1530 = item.Where(d => d.starttime <= _1530 && d.endtime >= _3045);
                    var value3045 = item.Where(d => d.starttime <= _3045 && d.endtime >= _4560);
                    var value4560 = item.Where(d => d.starttime <= _4560 && d.endtime >= nesthour);
                    showModels.Add(new ShowModel
                    {
                        roomname = item.FirstOrDefault().roomname,
                        hour = i,
                        color_115 = value115.Count() <= 0 ? "#" + ColorType._22b14c.ToString().Replace("_", "") : "#" + ((ColorType)value115.FirstOrDefault().status).ToString(),
                        color_115_user = value115.Count() <= 0 ? "无人预约" :"预约人："+ value115.FirstOrDefault().username,
                        color_1530 = value1530.Count() <= 0 ? "#" + ColorType._22b14c.ToString().Replace("_", "") : "#" + ((ColorType)value1530.FirstOrDefault().status).ToString(),
                        color_1530_user= value1530.Count() <= 0 ? "无人预约" : "预约人：" + value1530.FirstOrDefault().username,
                        color_3045 = value3045.Count() <= 0 ? "#" + ColorType._22b14c.ToString().Replace("_", "") : "#" + ((ColorType)value3045.FirstOrDefault().status).ToString(),
                        color_3045_user= value3045.Count() <= 0 ? "无人预约" : "预约人：" + value3045.FirstOrDefault().username,
                        color_4560 = value4560.Count() <= 0 ? "#" + ColorType._22b14c.ToString().Replace("_", "") : "#" + ((ColorType)value4560.FirstOrDefault().status).ToString(),
                        color_4560_user= value4560.Count() <= 0 ? "无人预约" : "预约人：" + value4560.FirstOrDefault().username
                    });
                }
            }

            return showModels;
        }
    }
}