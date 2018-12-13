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
    public class ToDoController : BaseController
    {
        public JwtClaim claim;
        private IToDoService _toDoService;
        public IToDoService ToDoService {
            get {
                if (_toDoService==null)
                {
                    _toDoService = new ToDoService();
                }
                return _toDoService;
            }
        }
        public ToDoController(IHttpContextAccessor accessor, IConfiguration configuration) : base(accessor, configuration)
        {
            connstr = configuration["connstr:mysql"];
        }
        [PermitFilter]
        public string getToDo()
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            if (claim.area==0)
            {
                claim.uid = "";
            }
            List<ToDoModel> model = ToDoService.getToDo(claim.uid,connstr);
            LayTableModel<List<ToDoModel>> table = new LayTableModel<List<ToDoModel>>();
            table.message = "success";
            table.code = 200;
            table.total = model.Count;
            table.rows = new Rows<List<ToDoModel>>();
            table.rows.item = new List<ToDoModel>();
            table.rows.item = model;
            return JsonConvert.SerializeObject(table);
        }
        [PermitFilter]
        [HttpPost]
        public ResponseResult<string> addToDo([FromQuery]string token, string title, string content,string proirity)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                if (string.IsNullOrEmpty(proirity)||string.IsNullOrEmpty(title))
                {
                    return ResponseResult<string>.Error("操作异常");
                }
                SYS_TODOLIST area = new SYS_TODOLIST {ID=Guid.NewGuid().ToString(),TITLE=title,CONTENT=content,PRIORITY=int.Parse(proirity),CREATETIME=DateTime.Now,UID= claim.uid,PROGRESS=0 };
                var b = ToDoService.addToDo(area, connstr);
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
        [HttpPost]
        public ResponseResult<string> editProgress([FromQuery]string token, string id, int progress)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                if (progress<0||progress>100)
                {
                    return ResponseResult<string>.Error("输入异常");
                }
                
                var b = ToDoService.editProgress(id,progress, connstr);
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
        [PermitFilter]
        [HttpPost]
        public ResponseResult<string> completeToDo([FromQuery]string token, string id)
        {
            claim = (JwtClaim)_accessor.HttpContext.Items["user"];
            try
            {
                var b = ToDoService.completeToDo(id, connstr);
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
    }
}