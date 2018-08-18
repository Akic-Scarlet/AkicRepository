using Akic.Core.JsonHelper;
using Akic.Core.Operator;
using Akic.Core.Security;
using Akic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Akic.Core.Domain.Module;
using Akic.Core;
namespace Akic.FrameWorkEx.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        public LoginController(IUserService UserService) 
        {
            this._userService = UserService;
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckLogin(string username, string password, string code)
        {

                if (Session["Akic_VerifyCode"]==null || code.ToLower()!= Session["Akic_VerifyCode"].ToString())
                    return Json(JsonHandler.CreateMessage(0, "验证码错误"), JsonRequestBehavior.AllowGet);
                User userEntity = _userService.CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.Id;
                    operatorModel.RoleId = userEntity.Roles;
                    operatorModel.UserName = userEntity.UserName;
                    operatorModel.LoginTime = DateTime.Now;
                    OperatorProvider.Provider.AddCurrent(operatorModel);                
                }
                  return Json(JsonHandler.CreateMessage(1, ""), JsonRequestBehavior.AllowGet);
       }
	}
}