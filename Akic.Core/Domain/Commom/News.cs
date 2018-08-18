using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Commom
{
    [Table("News")]  
    public class News :BaseEntity
    {
     
        public string NewsTitle { get; set; }
 
        public string Category { get; set; }
 
        public bool IsTop { get; set; }
      
        public string NewsContent { get; set; }
        public int ViewTimes { get; set; }
        public int CommentNum { get; set; }
   
        public string NewsTags { get; set; }
 
        public string ThumbPath { get; set; }
        public string UserID { get; set; }

    }
}
