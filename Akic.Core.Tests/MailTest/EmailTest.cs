using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Core.Mail;
using Akic.Core.Config;

namespace Akic.Core.Tests.MailTest
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void SEND_ONE_EMAIL()
        {
            string repicent = "1308468209@qq.com";
            string account="1308468209@qq.com";
            string title="Reset your password";
            string content = "123";
            MailHelper.Send(repicent, account, title, content,"","");

            
           

        }
    
    }
}
