using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Commom
{
    [Table("Photo")]  
    public class Photo:BaseEntity
    {
 
        public string AtlasId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoTags { get; set; }
        public string ThumbPath { get; set; }
        public string PhotoPath { get; set; }
 
        public string Remark { get; set; }
        public int Hits { get; set; }
        public int CommentNum { get; set; }
       
    }
}
