using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Comment
{
    [Table("VideoComment")]  
    public class VideoComment : CommentBase
    {
        public string VideoId { get; set; }
    }
}
