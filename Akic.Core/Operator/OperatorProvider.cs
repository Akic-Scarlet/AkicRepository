using Akic.Core.Security;
using Akic.Core.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akic.Core.JsonHelper;
using Akic.Core.Config;
namespace Akic.Core.Operator
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "Akic_Login_Key";
        private string LoginProvider = Configs.getValue("LoginProvider");

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel =null;
            try {
                if (LoginProvider == "Cookie")
                {
                    operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
                }
                else
                {
                    operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
                }


                return operatorModel;
            }
            catch {
                return null;
            }
          
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            try
            {
                if (LoginProvider == "Cookie")
                {
                    WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 60);
                }
                else
                {
                    WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));//Configuration of session in IIS,Runtime 20min on default situation 
                }
            }
            catch
            {
                return;
            }
          
            
             
        }
        public void RemoveCurrent()
        {
            try
            {
                if (LoginProvider == "Cookie")
                {
                    WebHelper.RemoveCookie(LoginUserKey.Trim());
                }
                else
                {
                    WebHelper.RemoveSession(LoginUserKey.Trim());
                }
            }
            catch
            {
                return;
            }
          
        }
    }
}
