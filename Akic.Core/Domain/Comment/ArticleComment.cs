using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Comment
{
    [Table("ArticleComment")]
    public class ArticleComment : CommentBase
    {
        public string ArticleId { get; set; }
        public string ReplyId { get; set; }
        public string ReplyCount { get; set; }
        
    }
}
