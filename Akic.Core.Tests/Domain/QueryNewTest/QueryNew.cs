using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Core.Domain.Commom;
using Akic.Repository;
using System.Collections.Generic;
using Akic.Service;

namespace Akic.Core.Tests.Domain.QueryNewTest
{
    [TestClass]
    public class QueryNew
    {
        IRepository<News> _newsRepository = new EfRepository<News>();

                [TestMethod]
        public void QUERY_NEW_LIST()
        {
            News getOneNew = _newsRepository.QueryWhere(a => a.Id == "9");
            string aq = getOneNew.NewsContent;
            int commentNum = getOneNew.CommentNum;
            Assert.AreEqual(2, commentNum);

        }

        public void QUERY_THREE_OF_RANDOM_NEWS()
        {
          
            
        }
    }
}
