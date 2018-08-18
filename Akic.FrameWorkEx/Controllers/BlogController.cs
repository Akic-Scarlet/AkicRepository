using Akic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akic.FrameWorkEx.Controllers
{
    public class BlogController : Controller
    {
          private IArticleService _articleService;
          public BlogController(IArticleService ArticleService)
        {
            this._articleService = ArticleService;
        }
        //
        // GET: /Blog/
          public ActionResult Index(int? pageindex)
        {
            if (pageindex == null)
                pageindex = 1;
            int pagesize = 5;
            var list = _articleService.GetList();
            ViewBag.getSomeTopArticle = _articleService.getSomeListByField(list, 5, t => t.AddedDate, t => t.IsTop == true, true);
            ViewBag.getSomeRecentArticle = _articleService.getSomeListByField(list, 5, t => t.AddedDate, t => true, true);
            ViewBag.countTotal = list.Count();
            ViewBag.pageindex = pageindex;
            list = _articleService.GetPageList((int)pageindex, pagesize, u => true, a => true, true);     
            return View(list);
        }
          public ActionResult detail(string id)
          {
              var list = _articleService.GetList();
              ViewBag.getSomeTopArticle = _articleService.getSomeListByField(list, 5, t => t.AddedDate, t => t.IsTop == true, true);
              ViewBag.getSomeRecentArticle = _articleService.getSomeListByField(list, 5, t => t.AddedDate, t => true, true);
              var model = _articleService.QueryWhere(u => u.Id == id);
              return View(model);
 
        }
	}
}