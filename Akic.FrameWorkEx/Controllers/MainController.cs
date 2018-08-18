using Akic.Core;
using Akic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akic.FrameWorkEx.Controllers
{
    public class MainController : Controller
    {
        private INewsService _newsService;
        public MainController(INewsService NewsService)
        {
            this._newsService = NewsService;
        }
        //
        // GET: /Main/
        public ActionResult Index(int? pageindex)
        {
            if (pageindex == null)
                pageindex = 1;
            int index = 1;
            int pagesize = 5;
            var list=_newsService.GetList();
            ViewBag.countTotal = list.Count();
            ViewBag.pageindex = pageindex;
            ViewBag.getSomeTopNews = _newsService.GetList(t => t.IsTop == true, 3);
            ViewBag.getSomeTopFloat = _newsService.GetList(t => t.IsTop == true, 2);
            ViewBag.getSomeDateNews = _newsService.getSomeListByField(list, 3, t => t.AddedDate);
            list = _newsService.GetPageList((int)pageindex, pagesize, u => true, a => true, true);
            ViewBag.index = index;
            return View(list);
        }
       
        public ActionResult getPageData()
        {
            int pageSize = Request["pageSize"] == null ? 3 : int.Parse(Request["pageSize"]);
            int pageIndex = Request["pageIndex"] == null ? 1 : int.Parse(Request["pageIndex"]);
            int totalCount = _newsService.GetList().Count();
            var getPageList = _newsService.GetPageList(pageIndex, pageSize, u => true, a => true, true);

            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var data = from u in getPageList select new { u.Id, u.NewsTitle, u.AddedDate, u.CommentNum, u.ViewTimes,u.NewsContent };
            string strNav = PagerHelper.ShowPageNavigate(pageIndex, pageSize, totalCount);
            var result = new { Data = data, NavStr = strNav };
           
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Single(string id)
        {
            ViewBag.index = 1;
            var list = _newsService.GetList();
            ViewBag.getSomeTopNews = _newsService.GetList(t => t.IsTop == true, 3);
            ViewBag.getSomeTopFloat = _newsService.GetList(t => t.IsTop == true, 2);
            ViewBag.getSomeDateNews = _newsService.getSomeListByField(list, 3, t => t.AddedDate);
            var model = _newsService.QueryWhere(u => u.Id == id);
            return View(model);
        }
       

	}
}