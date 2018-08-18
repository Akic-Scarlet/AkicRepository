using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Repository;
using Akic.Core.Domain.CommentReply;

namespace Akic.Core.Tests.Domain.QueryNewReply
{
    [TestClass]
    public class UnitTest1
    {
 
        IRepository<NewsCommentReply> _newsRepository = new EfRepository<NewsCommentReply>();

        [TestMethod]
        public void QUERY_NEW_LIST()
        {
            var getList = _newsRepository.GetList(a => a.NewsCommentId == "1");
            foreach (var item in getList)
            {
                string aq = item.Content;
            }
            string q;
           

        }
    }
}
