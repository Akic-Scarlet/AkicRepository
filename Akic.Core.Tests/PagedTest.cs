using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Core.Domain.UserSample;
using System.Collections;
using System.Collections.Generic;

namespace Akic.Core.Tests
{
    [TestClass]
    public class PagedTest
    {
        [TestMethod]
        public void Assert_ID_Equal_SampleID()
        {
            IList<UserInfo> UserList=new List<UserInfo>();
            for (var i = 1; i <= 500; i++)
            {
                UserInfo userModel = new UserInfo() { Id = i.ToString(), };
                UserList.Add(userModel);
            }
            PagedList<UserInfo> page = new PagedList<UserInfo>(UserList,3,100);

            var q=300;
            foreach (var user in page)
            { 
                q++;
                Assert.AreEqual(user.Id, q);
            }


        }
    }
}
