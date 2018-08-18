using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Module
{
    [Table("MyMessage")]  
    public class MyMessage :BaseEntity
    {
        
        public string MId { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; }
        public DateTime? RecentTime { get; set; }
        public virtual User  UserModel { get; set; }
        public virtual Message MessageModel { get; set; }
    }
}
