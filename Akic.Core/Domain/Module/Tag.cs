using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Module
{
    [Table("Tag")]  
    public class Tag:BaseEntity
    {
     
     
        public string TagName { get; set; }
        public int Belong { get; set; }
        public string TagEnglish { get; set; }
        public string TagDescription { get; set; }
        public int TagSum { get; set; }
      
    }
}
