using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Repository;
using Akic.Core.Domain.Comment;

namespace Akic.Core.Tests.Domain.InsertArticleComment
{
    [TestClass]
    public class UnitTest1
    {
        IRepository<ArticleComment> _articleService = new EfRepository<ArticleComment>();
        [TestMethod]
        public void TestMethod1()
        {
            var model = new ArticleComment();
            model.Id = ResultHelper.ResultHelper.NewId;
            model.AddedDate = ResultHelper.ResultHelper.NowTime;
            model.Content = "QQQ";
            model.ArticleId = "1";
            //member infomation
            model.Email = "NULL@qq.com";
            model.UpId = "0";
            _articleService.Insert(model);

        }
    }
}
