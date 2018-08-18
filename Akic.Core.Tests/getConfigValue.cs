using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Akic.Core.Config;

namespace Akic.Core.Tests
{
    [TestClass]
    public class getConfigValue
    {
        [TestMethod]
        public void GET_A_VALUE_FROM_CONFIG()
        {

            var str = Configs.getValue("LoginProvider");
            
        }
    }
}
