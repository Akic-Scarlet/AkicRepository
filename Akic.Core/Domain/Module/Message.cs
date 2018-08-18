using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Module
{
    [Table("Message")]  
    public class Message:BaseEntity
    {
     
    
        public string Title { get; set; }
        public string Context { get; set; }
        public string Appendix { get; set; }
        public string Type { get; set; }
      
        public virtual ICollection<MyMessage> MyMessageModel { get; set; }
    }
}
