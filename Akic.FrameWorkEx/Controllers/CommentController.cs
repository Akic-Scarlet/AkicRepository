using Akic.Core.Domain.Comment;
using Akic.Core.Domain.CommentReply;
using Akic.Core.JsonHelper;
using Akic.Core.ResultHelper;
using Akic.FrameWorkEx._Core;
using Akic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akic.FrameWorkEx.Controllers
{
    public class CommentController : BaseController
    {
           private INewsCommentService _newsCommentService;
           private IUserService _userService;
           private INewsCommentReplyService _newsCommentReplyService;
           private INewsService _newsService;

           private IArticleCommentService _articleCommentService;
           private IArticleCommentReplyService _articleCommentReplyService;
           private IArticleService _articleService;
           public CommentController(INewsCommentService newsCommentService, IUserService _userService, 
               INewsCommentReplyService newsCommentReplyService,INewsService _newsService,
               IArticleCommentService _articleCommentService,
               IArticleCommentReplyService _articleCommentReplyService, IArticleService _articleService
               
               )
        {
            this._newsCommentService = newsCommentService;
            this._userService = _userService;
            this._newsCommentReplyService = newsCommentReplyService;
            this._newsService = _newsService;

            this._articleCommentService = _articleCommentService;
            this._articleCommentReplyService = _articleCommentReplyService;
            this._articleService = _articleService;
        }
        //
        // GET: /Comment/
        public ActionResult Index()
        {
            return View();
        }
        #region NewsComment
        public ActionResult getNewsComment(string NewsId)
        {

            var getNewComList = _newsCommentService.GetList(t => t.NewsId == NewsId);
            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var userList = _userService.GetList();
            var data = from u in getNewComList
                       join t in userList on u.UpId equals t.Id
                       orderby u.AddedDate descending
                       select new { u.Id, t.UserName, u.Content, u.AddedDate, u.ReplyId, u.ReplyCount };

            var result = new { Data = data };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult getNewsReplyComment(string ReplyId)
        {

            var getNewReply = _newsCommentReplyService.GetList(t => t.NewsCommentId == ReplyId);
            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var userList = _userService.GetList();

            var data = from u in getNewReply
                       join t in userList on u.UpId equals t.Id
                       orderby u.AddedDate descending
                       select new { u.Id, t.UserName, u.Content, u.AddedDate };

            var result = new { Data = data };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult PostNewComment(string NewId, string Content)
        {
            var model = new NewsComment();
            model.Id = ResultHelper.NewId;
            model.AddedDate = ResultHelper.NowTime;
            model.Content = Content;
            model.NewsId = NewId;
            //member infomation
            model.Email = "NULL@qq.com";
            model.UpId = "0";
            if (model != null)
            {
                _newsCommentService.Insert(model);
                return Json(JsonHandler.CreateMessage(1, Akic.Core.Suggestion.InsertSucceed));
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Akic.Core.Suggestion.InsertFail));
            }

        }
        [HttpPost]
        public JsonResult PostNewReplyComment(string ReplyID, string Content)
        {
            var getComment = _newsCommentService.QueryWhere(t => t.Id == ReplyID);
            var count = _newsCommentReplyService.GetList(t => t.NewsCommentId == ReplyID).Count();
            getComment.ReplyId = ReplyID;
            getComment.ReplyCount = (count + 1).ToString();
            var model = new NewsCommentReply();
            model.Id = ResultHelper.NewId;
            model.AddedDate = ResultHelper.NowTime;
            model.Content = Content;
            model.NewsCommentId = ReplyID;
            //member infomation
            model.Email = "NULL@qq.com";
            model.UpId = "0";
            if (model != null)
            {
                _newsCommentReplyService.Insert(model);
                _newsCommentService.Update(getComment);
                return Json(JsonHandler.CreateMessage(1, Akic.Core.Suggestion.InsertSucceed));
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Akic.Core.Suggestion.InsertFail));
            }

        }

        #endregion
        #region ArticleComment
        public ActionResult getArticleComment(string ArticleId)
        {

            var getNewComList = _articleCommentService.GetList(t => t.ArticleId == ArticleId);
            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var userList = _userService.GetList();
            var data = from u in getNewComList
                       join t in userList on u.UpId equals t.Id
                       orderby u.AddedDate descending
                       select new { u.Id, t.UserName, u.Content, u.AddedDate, u.ReplyId, u.ReplyCount };

            var result = new { Data = data };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        public ActionResult getArticleReplyComment(string ReplyId)
        {

            var getNewReply = _articleCommentReplyService.GetList(t => t.ArticleCommentId == ReplyId);
            //接受一个对像，内部把此对象使用javaScript序列化类对象志字符串，发送到前台
            var userList = _userService.GetList();

            var data = from u in getNewReply
                       join t in userList on u.UpId equals t.Id
                       orderby u.AddedDate descending
                       select new { u.Id, t.UserName, u.Content, u.AddedDate };

            var result = new { Data = data };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult PostArticleComment(string ArticleId, string Content)
        {
            var model = new ArticleComment();
            model.Id = ResultHelper.NewId;
            model.AddedDate = ResultHelper.NowTime;
            model.Content = Content;
            model.ArticleId = ArticleId;
            //member infomation
            model.Email = "NULL@qq.com";
            model.UpId = "0";
            if (model != null)
            {
                _articleCommentService.Insert(model);
                return Json(JsonHandler.CreateMessage(1, Akic.Core.Suggestion.InsertSucceed));
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Akic.Core.Suggestion.InsertFail));
            }

        }
        [HttpPost]
        public JsonResult PostArticleReplyComment(string ReplyID, string Content)
        {
            var getComment = _articleCommentService.QueryWhere(t => t.Id == ReplyID);
            var count = _articleCommentReplyService.GetList(t => t.ArticleCommentId == ReplyID).Count();
            getComment.ReplyId = ReplyID;
            getComment.ReplyCount = (count + 1).ToString();
            var model = new ArticleCommentReply();
            model.Id = ResultHelper.NewId;
            model.AddedDate = ResultHelper.NowTime;
            model.Content = Content;
            model.ArticleCommentId = ReplyID;
            //member infomation
            model.Email = "NULL@qq.com";
            model.UpId = "0";
            if (model != null)
            {
                _articleCommentReplyService.Insert(model);
                _articleCommentService.Update(getComment);
                return Json(JsonHandler.CreateMessage(1, Akic.Core.Suggestion.InsertSucceed));
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Akic.Core.Suggestion.InsertFail));
            }

        }
        #endregion




	}
}