using Akic.Core.Domain.Commom;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akic.Core.Domain.Comment
{
    [Table("NewsComment")]  
    public class NewsComment:CommentBase
    {
        public string NewsId { get; set; }
        public string ReplyId { get; set; }
        public string ReplyCount { get; set; }
    }
}
