using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Repository;
using Akic.Core.Domain.Commom;

namespace Akic.Core.Tests.Domain.QueryArticleTest
{
    [TestClass]
    public class UnitTest1
    {
        IRepository<Article> _articleService = new EfRepository<Article>();
        [TestMethod]
        public void TestMethod1()
        {
            var list = _articleService.GetList();
            var getsomeTop=_articleService.getSomeListByField(list, 3, t => t.AddedDate, t => t.IsTop == true, true);
        }
    }
}
