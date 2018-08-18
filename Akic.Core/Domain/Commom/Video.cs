using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Commom
{
    [Table("Video")]  
    public class Video:BaseEntity
    {
 
        public string VideoName { get; set; }
        public string ThumbPath { get; set; }
        public string VideoPath { get; set; }
        public string Remark { get; set; }
        public int Hits { get; set; }
        public int CommentNum { get; set; }  
        public string Category { get; set; }
        public string ComesFrom { get; set; }
        public bool IsLocal { get; set; }
        public bool Recommend { get; set; }
        public string UpId { get; set; }
        public bool IsTop { get; set; }
        public string MoudleId { get; set; }
    }
}
