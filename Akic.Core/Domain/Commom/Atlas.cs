using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Commom
{
    [Table("Atlas")]  
    public class Atlas:BaseEntity
    {
     

      
        public string AtlasName { get; set; }
        public string ThumbPath { get; set; }
        public string AtlasPath { get; set; }
        public string Remark { get; set; }
        public int Hits { get; set; }
        public int CommentNum { get; set; }
      
    }
}
