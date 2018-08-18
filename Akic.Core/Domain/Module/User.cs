using Akic.Core.Domain.Feedback;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Module
{
    [Table("User")]
    public class User:BaseEntity
    {
    
 
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string StuNumber { get; set; }
        public string Identification { get; set; }
        public int Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string About { get; set; }
        public string PersonalPage { get; set; }
        public int State { get; set; }
        public string Roles { get; set; }

        public ICollection<FbDocument> FbDocument { get; set; }
        public ICollection<MyMessage> MyMessage { get; set; }
    }
}
