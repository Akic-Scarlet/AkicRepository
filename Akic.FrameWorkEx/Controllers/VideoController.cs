using Akic.Core.Domain.Commom;
using Akic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akic.FrameWorkEx.Controllers
{
    public class VideoController : Controller
    {
        private IVideoService _VideoService;
        private IUserService _userService;
        public VideoController(IVideoService _VideoService, IUserService _userService)
        {
            this._VideoService = _VideoService;
            this._userService = _userService;
        }
        //
        // GET: /Video/
        public ActionResult Index()
        {
            var list = _VideoService.GetList();
            var userlist=_userService.GetList();
            var getlist = (from r in list
                          join u in userlist on r.UpId equals u.Id
                          orderby r.AddedDate
                          select new Video{
                              Id=r.Id,
                              VideoName= r.VideoName,
                              UpId= u.UserName,
                              AddedDate= r.AddedDate,
                              CommentNum= r.CommentNum,
                              ThumbPath= r.ThumbPath,
                              Category=r.Category,
                               Recommend=r.Recommend,
                               IsTop=r.IsTop
                          }).ToList();
            ViewBag.getSomeU3DTopVideo = _VideoService.getSomeListByField(list, 2, t => t.AddedDate, t => t.IsTop == true && t.Category == "Untiy3d", true);
            ViewBag.getSomeCSharpTopVideo = _VideoService.getSomeListByField(list, 2, t => t.AddedDate, t => t.IsTop == true&&t.Category=="CSharp", true);
            ViewBag.getOneTopVideo = _VideoService.getSomeListByField(list, 1, t => t.AddedDate, t => t.IsTop == true&&t.Recommend==true, true);


            ViewBag.getRightRecomVideo = (from r in list
                           join u in userlist on r.UpId equals u.Id
                           orderby r.AddedDate
                           where r.Recommend=true
                           select new Video
                           {
                               Id = r.Id,
                               VideoName = r.VideoName,
                               UpId = u.UserName,
                               AddedDate = r.AddedDate,
                               CommentNum = r.CommentNum,
                               ThumbPath = r.ThumbPath,
                               Category = r.Category,
                               Recommend = r.Recommend,
                               IsTop = r.IsTop
                           }).Take(3).ToList();
            ViewBag.getRightTopVideo = (from r in list
                                        join u in userlist on r.UpId equals u.Id
                                        orderby r.AddedDate
                                        where r.IsTop = true
                                        select new Video
                                        {
                                            Id = r.Id,
                                            VideoName = r.VideoName,
                                            UpId = u.UserName,
                                            AddedDate = r.AddedDate,
                                            CommentNum = r.CommentNum,
                                            ThumbPath = r.ThumbPath,
                                            Category = r.Category,
                                            Recommend = r.Recommend,
                                            IsTop = r.IsTop
                                        }).Take(3).ToList(); ;


            return View(getlist);
        }
        public ActionResult Single(string id)
        {
            var list = _VideoService.GetList();
            var userlist = _userService.GetList();
            var model = _VideoService.QueryWhere(u => u.Id == id);
             var user=_userService.QueryWhere(t=>t.Id==model.UpId);
             model.UpId = user.UserName;
             var getlist = (from r in list
                            join u in userlist on r.UpId equals u.Id
                            orderby r.AddedDate
                            select new Video
                            {
                                Id = r.Id,
                                VideoName = r.VideoName,
                                UpId = u.UserName,
                                AddedDate = r.AddedDate,
                                CommentNum = r.CommentNum,
                                ThumbPath = r.ThumbPath,
                                Category = r.Category,
                                Recommend = r.Recommend,
                                IsTop = r.IsTop
                            }).ToList();
             ViewBag.getRightRecomVideo = (from r in list
                                           join u in userlist on r.UpId equals u.Id
                                           orderby r.AddedDate
                                           where r.Recommend = true
                                           select new Video
                                           {
                                               Id = r.Id,
                                               VideoName = r.VideoName,
                                               UpId = u.UserName,
                                               AddedDate = r.AddedDate,
                                               CommentNum = r.CommentNum,
                                               ThumbPath = r.ThumbPath,
                                               Category = r.Category,
                                               Recommend = r.Recommend,
                                               IsTop = r.IsTop
                                           }).Take(3).ToList();
             ViewBag.getRightTopVideo = (from r in list
                                         join u in userlist on r.UpId equals u.Id
                                         orderby r.AddedDate
                                         where r.IsTop = true
                                         select new Video
                                         {
                                             Id = r.Id,
                                             VideoName = r.VideoName,
                                             UpId = u.UserName,
                                             AddedDate = r.AddedDate,
                                             CommentNum = r.CommentNum,
                                             ThumbPath = r.ThumbPath,
                                             Category = r.Category,
                                             Recommend = r.Recommend,
                                             IsTop = r.IsTop
                                         }).Take(3).ToList(); ;


            return View(model);
        }
        public ActionResult Search()
        {
            return View();
        }
	}
}