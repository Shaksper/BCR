using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BCR.Controllers
{
    public class PermitFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            var isDefined = false;
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                  .Any(a => a.GetType().Equals(typeof(NoPermissionRequired)));
            }
            if (isDefined) base.OnActionExecuting(filterContext);
            //验签
            string token = filterContext.HttpContext.Request.Query["token"].ToString();
            if (string.IsNullOrEmpty(token))
            {
                filterContext.Result = new RedirectResult("/System/Login");
            }
            else
            {
                JwtUtils jwt = new JwtUtils();
                JwtClaim claim = jwt.DecodingJwt(token);
                if (claim != null && DateTime.Now.ToBinary() <= claim.exp)
                {
                    if (claim.exp<=DateTime.Now.ToBinary())
                    {
                        //过期
                        filterContext.Result = new RedirectResult("/System/Login");
                    }
                    filterContext.HttpContext.Items.Add("user",claim);
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    filterContext.Result = new RedirectResult("/System/Login");
                }
            }
           
        }
    }
}
