using Akic.Core.DiyValidate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Comment
{
    [Table("Suggestion")]  
    public class Suggestion:BaseEntity
    {
        
       
        public string NickName { get; set; }
         
        public string Email { get; set; }
      
        public string Content { get; set; }
         
    }
}
