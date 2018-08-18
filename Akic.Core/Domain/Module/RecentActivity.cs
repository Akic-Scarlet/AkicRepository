using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akic.Core.Domain.Module
{
    [Table("RecentActivity")]  
   public  class RecentActivity:BaseEntity
    {
         
   
        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public string Address { get; set; }
        
        public bool Status { get; set; }
    }
}
