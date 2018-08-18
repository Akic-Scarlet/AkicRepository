using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Core.Security;
 

namespace Akic.Core.Tests
{
    [TestClass]
    public class Md5Test
    {
        [TestMethod]
        public void Md5Ouput()
        {
            string testStr="jishiyuReborn";
            string getStr=Md5.MD5(testStr);
          

        }
    }
}
