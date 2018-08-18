using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.LogHandler;

namespace Akic.Core.Tests.Domain.LogTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LogRecord.WriteServiceLog("admin", "admin删除成功新闻", "warnning");
        }
    }
}
