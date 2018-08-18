using Akic.Core.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akic.MvcFrameWork.App_Start
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
 
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
 
            if (OperatorProvider.Provider.GetCurrent() == null)
            {          
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
                return;
            }
        }
    }
}