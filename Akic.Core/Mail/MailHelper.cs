using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Mail
{
    public class MailHelper
    {
        public static void Send(string recipientAddress, string senderAddress,string title,string content,string picpath,string zippath )
        {
            SmtpClient client = new SmtpClient("smtp.qq.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(senderAddress, "crdolknkjrfogeha");

            MailAddress from = new MailAddress(senderAddress, "Mr.Akic", Encoding.UTF8);//初始化发件人  
            MailAddress to = new MailAddress(recipientAddress, "", Encoding.UTF8);//初始化收件人  
           
            //设置邮件内容  
            MailMessage message = new MailMessage(from, to);
            if(picpath!="")
            { 
                //图像附件
                var attach = new Attachment(picpath, MediaTypeNames.Image.Jpeg);
                //设置ContentId
                attach.ContentId = "pic";
                message.Attachments.Add(attach);
            }
            if (zippath != "")
            {
                //ZIP附件
                var attach2 = new Attachment(zippath, "application/x-zip-compressed");
                message.Attachments.Add(attach2);
            }

            message.Body = content ;
            message.Subject = title;
            message.SubjectEncoding =   Encoding.UTF8; 
             message.BodyEncoding = Encoding.UTF8;  
             message.IsBodyHtml = true;

            //发送邮件  
            try
            {
                client.Send(message);
            }
            catch (InvalidOperationException iex)
            { throw iex; }
            catch (Exception ex)
            { throw ex; }
        }  
    }
}
