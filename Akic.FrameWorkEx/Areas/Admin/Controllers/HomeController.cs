using Akic.Core;
using Akic.Core.Domain.Commom;
using Akic.Core.JsonHelper;
using Akic.FrameWorkEx._Core;
using Akic.LogHandler;
using Akic.MvcFrameWork.App_Start;
using Akic.Service;
using System.Linq;
using System.Web.Mvc;

namespace Akic.FrameWorkEx.Areas.Admin.Controllers
{
   [HandlerLoginAttribute]
    public class HomeController : BaseController
    {
          private readonly INewsService _newsServer;
          private readonly IArticleService _articleServer;
          private readonly ILogService _logServer;
          private readonly IVideoService _videoServer;
          private readonly IUserService _userService;
          private int countNow;
          public HomeController(INewsService newsServer, IArticleService ArticleServer, ILogService LogServer
             , IVideoService _videoServer, IUserService _userService)
        {
            this._newsServer = newsServer;
            this._articleServer = ArticleServer;
            this._logServer = LogServer;
            this._videoServer = _videoServer;
            this._userService = _userService;
             
        }
        
	
        //
        // GET: /Admin/Home/
        public ActionResult main()
        {
            return View();
        }
        public ActionResult top()
        {
            return View();
        }
        public ActionResult left()
        {
            return View();
        }
        public ActionResult index()
        {
            return View();
        }


        public ActionResult  default1()
        {
            return View();
        }
        public ActionResult imgtable()
        {
            return View();
        }
        public ActionResult tools()
        {
            return View();

        }
        public ActionResult computer()
        {
            return View();
        }
        public ActionResult tab()
        {
            return View();
        }
        public ActionResult error()
        {
            return View();
        }
        public ActionResult form()
        {
            return View();
        }
        public ActionResult blgo()
        {
            return View();
        }
        public ActionResult blgoManage()
        {
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _newsServer.GetList().Count();
            countNow = pageIndex;
            ViewBag.Count = totalCount;
            ViewBag.Index = countNow;
            return View();
        }
        public ActionResult VideoPost()
        {

            return View();
        }
        public ActionResult VideoManage()
        {
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _videoServer.GetList().Count();
            countNow = pageIndex;
            ViewBag.Count = totalCount;
            ViewBag.Index = countNow;
            return View();
        }
        public ActionResult LogManage()
        {
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _logServer.GetList().Count();
            countNow = pageIndex;
            ViewBag.Count = totalCount;
            ViewBag.Index = countNow;
            return View();
        }

        public ActionResult filelist()
        {
            return View();
        }
        public ActionResult imglist()
        {
            return View();
        }
        public ActionResult right()
        {
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _articleServer.GetList().Count();
            countNow = pageIndex;
            ViewBag.Count = totalCount;
            ViewBag.Index = countNow;
            return View();
        }
  
        [HttpPost]
        public JsonResult Delete(string id)
        {
            var model = _newsServer.QueryWhere(t => t.Id == id);
            if (!string.IsNullOrWhiteSpace(id))
            {
                _newsServer.Delete(id);
                LogRecord.WriteServiceLog("admin", "admin删除成功" + model.NewsTitle + "新闻", "warnning");
                return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
            }
            else
            {
                LogRecord.WriteServiceLog("admin", "admin删除失败" + model.NewsTitle + "新闻", "normal");
              return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }
       
       

        }
        [HttpPost]
        public JsonResult BlogDelete(string id)
        {
            var model = _articleServer.QueryWhere(t => t.Id == id);
            if (!string.IsNullOrWhiteSpace(id))
            {

                _articleServer.Delete(id);
                LogRecord.WriteServiceLog("admin", "admin删除成功" + model.ArticleTitle + "博客文章", "warnning");
                return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
            }
            else
            {
                LogRecord.WriteServiceLog("admin", "admin删除失败" + model.ArticleTitle + "博客文章", "normal");
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }
        }
        [HttpPost]
        public JsonResult VideoDelete(string id)
        {
            var model = _videoServer.QueryWhere(t => t.Id == id);
            if (!string.IsNullOrWhiteSpace(id))
            {

                _videoServer.Delete(id);
                LogRecord.WriteServiceLog("admin", "admin删除成功" + model.VideoName + "视频", "warnning");
                return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
            }
            else
            {
                LogRecord.WriteServiceLog("admin", "admin删除失败" + model.VideoName + "视频", "normal");
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }
        }
        public ActionResult Test()
        {
            
            return View();

        }
        public ActionResult getPageData()
        {
            int pageSize = Request["pageSize"] == null ? 5 : int.Parse(Request["pageSize"]);
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _newsServer.GetList().Count();
            var getPageList = _newsServer.GetPageList(pageIndex, pageSize, u => true, a => true, true);

            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var data = from u in getPageList select new { u.Id, u.NewsTitle, u.AddedDate, u.IsTop, u.Category, u.ThumbPath };
            string strNav = PagerHelper.ShowPageNavigate(pageIndex, pageSize, totalCount);
            var result = new { Data = data, NavStr = strNav };
            countNow = pageIndex;
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult getBlogPageData()
        {
            int pageSize = Request["pageSize"] == null ? 5 : int.Parse(Request["pageSize"]);
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _articleServer.GetList().Count();
            var getPageList = _articleServer.GetPageList(pageIndex, pageSize, u => true, a => true, true);

            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var data = from u in getPageList select new { u.Id, u.ArticleTitle, u.AddedDate, u.IsTop, u.Category, u.ThumbPath };
            string strNav = PagerHelper.ShowPageNavigate(pageIndex, pageSize, totalCount);
            var result = new { Data = data, NavStr = strNav };
            countNow = pageIndex;
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult getLogPageData()
        {
            int pageSize = Request["pageSize"] == null ? 5 : int.Parse(Request["pageSize"]);
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _logServer.GetList().Count();
            var getPageList = _logServer.GetPageList(pageIndex, pageSize, u => true, a => true, true);

            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var data = from u in getPageList select new { u.Id, u.Logger,u.Message, u.AddedDate, u.Level,  };
            string strNav = PagerHelper.ShowPageNavigate(pageIndex, pageSize, totalCount);
            var result = new { Data = data, NavStr = strNav };
            countNow = pageIndex;
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult getVideoPageData()
        {
            int pageSize = Request["pageSize"] == null ? 5 : int.Parse(Request["pageSize"]);
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _videoServer.GetList().Count();
            var getPageList = _videoServer.GetPageList(pageIndex, pageSize, u => true, a => true, true);
            var userList = _userService.GetList();
            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var data = from u in getPageList
                       join t in userList on u.UpId equals t.Id
                       orderby u.AddedDate
                       select new Video { 
                          Id= u.Id,
                          VideoName= u.VideoName,
                         AddedDate=  u.AddedDate,
                         IsTop=  u.IsTop,
                        Category=   u.Category,
                        ThumbPath=   u.ThumbPath ,
                        IsLocal=   u.IsLocal,
                        Recommend=   u.Recommend,
                        UpId=t.UserName
                       };
            string strNav = PagerHelper.ShowPageNavigate(pageIndex, pageSize, totalCount);
            var result = new { Data = data, NavStr = strNav };
            countNow = pageIndex;
            return Json(result, JsonRequestBehavior.AllowGet);

        }
 
       
	}
}