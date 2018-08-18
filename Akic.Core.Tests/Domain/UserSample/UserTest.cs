using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Akic.Data;
using Akic.Core.Domain.UserSample;

namespace Akic.Core.Tests.Domain.UserSample
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserUserProfileTest()
        {
            Database.SetInitializer<AkicObjectContext>(new CreateDatabaseIfNotExists<AkicObjectContext>());
            using (var db = new AkicObjectContext())
            {
                db.Database.Create();

                UserInfo userModel = new UserInfo()
                {
                    UserName = "Daniel",
                    Password = "123456",
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Email = "Daniel@163.com",
                    //一个用户，只有一个用户详情
                    UserProfile = new UserProfile()
                    {
                        FirstName = "曹",
                        LastName = "操",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Address = "宝安区 深圳 中国",
                    }
                 
                };
                db.Entry(userModel).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
            }
        }
    }
}
