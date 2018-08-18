using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Commom
{
    [Table("Article")]  
    public class Article:BaseEntity
    {
   
        public string ArticleTitle { get; set; }
        public string Category { get; set; }
        public bool IsTop { get; set; }   
        public string ArticleContent { get; set; }
        public int ViewTimes { get; set; }
        public int CommentNum { get; set; }
        //[Required(ErrorMessage = @"请选择所属标签")]
        public string ArticleTags { get; set; }     
        public string ThumbPath { get; set; }
        public string UserID { get; set; }
    }
}
