using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Repository;
using Akic.Core.Domain.Module;

namespace Akic.Core.Tests.Domain.QueryUserTest
{
    [TestClass]
    public class QueryTest
    {
        private readonly IRepository<User> _userRepository=new EfRepository<User>();
     
        [TestMethod]
        public void QUERY_ONE_USER()
        {
            User getUser = _userRepository.QueryWhere(a => a.UserName == "QQQ");
           string aq= getUser.Identification;
           Assert.AreEqual("路人", aq);
        }
    }
}
