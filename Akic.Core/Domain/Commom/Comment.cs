using Akic.Core.DiyValidate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Commom
{
 
    public class CommentBase:BaseEntity
    {
        public string UpId { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int IsMember { get; set; }
        public string UniqueKey { get; set; }
    }
}
