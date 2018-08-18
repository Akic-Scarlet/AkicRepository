using System;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace Akic.Core.Domain.Log
{
    [Table("LoginLog")]  
    public class LoginLog :BaseEntity
    {
       
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        public string ComputerName { get; set; }
        
        public string Platform { get; set; }
        public string UserAgent { get; set; }
        public string Type { get; set; }
    }
}
