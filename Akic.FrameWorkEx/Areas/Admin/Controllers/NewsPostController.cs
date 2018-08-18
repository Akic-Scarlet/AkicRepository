using Akic.Core;
using Akic.Core.Domain.Commom;
using Akic.Core.JsonHelper;
using Akic.Core.ResultHelper;
using Akic.LogHandler;
using Akic.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akic.FrameWorkEx.Areas.Admin.Controllers
{
    public class NewsPostController : Controller
    {
            private readonly INewsService _newsServer;


            public NewsPostController(INewsService newsServer)
        {
            this._newsServer = newsServer;
             
        }
        //
        // GET: /Admin/NewsPost/
        public ActionResult Index()
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
                LogRecord.WriteServiceLog("admin", "admin添加成功" + model.NewsTitle + "新闻", "warnning");
                return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                
            }
            else
            {
                LogRecord.WriteServiceLog("admin", "admin添加失败" + model.NewsTitle + "新闻", "warnning");
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
        public ActionResult Upload(HttpPostedFileBase Filedata)
        {
            // 没有文件上传，直接返回
            if (Filedata == null || string.IsNullOrEmpty(Filedata.FileName) || Filedata.ContentLength == 0)
            {
                return HttpNotFound();
            }

            //获取文件完整文件名(包含绝对路径)
            //文件存放路径格式：/files/upload/{日期}/{md5}.{后缀名}
            //例如：/files/upload/20130913/43CA215D947F8C1F1DDFCED383C4D706.jpg
            string newId = ResultHelper.NewId;
            string FileEextension = Path.GetExtension(Filedata.FileName);
            string uploadDate = DateTime.Now.ToString("yyyyMM");

            string imgType = Request["imgType"];
            string FoldType = Request["FileType"];
            string virtualPath = "/";
            if (imgType == "normal")
            {
                virtualPath = string.Format("~/Content/Images/{0}/{1}/{2}{3}", FoldType, uploadDate, newId, FileEextension);
            }
            else
            {
                virtualPath = string.Format("~/Content/Images/{0}2/{1}/{2}{3}", FoldType, uploadDate, newId, FileEextension);
            }
            string fullFileName = this.Server.MapPath(virtualPath);

            //创建文件夹，保存文件
            string path = Path.GetDirectoryName(fullFileName);
            Directory.CreateDirectory(path);
            if (!System.IO.File.Exists(fullFileName))
            {
                Filedata.SaveAs(fullFileName);
            }

            var data = new { imgtype = imgType, imgpath = virtualPath.Remove(0, 1) };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
 
	}
}