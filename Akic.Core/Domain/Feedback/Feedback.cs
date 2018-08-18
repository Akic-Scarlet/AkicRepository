using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akic.Core.Domain.Feedback
{
       [Table("Feedback")]  
    public class Feedback:BaseEntity
    {      
        public string FeedbackName { get; set; }       
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public  int Status { get; set; }
        public virtual ICollection<FbDocument> FbDocuments { get; set; }
    }
}
