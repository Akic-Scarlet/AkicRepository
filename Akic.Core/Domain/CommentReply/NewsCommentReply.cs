using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.CommentReply
{
      [Table("NewsCommentReply")]  
    public class NewsCommentReply : BaseEntity
    {
        public string UpId { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public string NewsCommentId { get; set; }

    }
}
