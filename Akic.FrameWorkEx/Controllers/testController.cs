using Akic.Core;
using Akic.Core.Domain.Commom;
using Akic.Core.JsonHelper;
using Akic.Core.ResultHelper;
using Akic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akic.FrameWorkEx.Controllers
{
    public class testController : Controller
    {
           private readonly INewsService _newsServer;


           public testController(INewsService newsServer)
        {
            this._newsServer = newsServer;
             
        }
        //
        // GET: /test/
        public ActionResult fUCK()
        {
            return View();
        }
        public ActionResult formQ()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Create(News model)
        {
            model.Id = ResultHelper.NewId;
            model.AddedDate = ResultHelper.NowTime;
            model.CommentNum = 0;
            if (model != null)
            {

                _newsServer.Insert(model);
                return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));

            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
	}
}