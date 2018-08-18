using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akic.Core.Domain.Commom;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Akic.Core.Domain.Comment
{
      [Table("BookComment")]  
    public class BookComment : CommentBase
    {
      
        public decimal Score { get; set; }
        public string BookId { get; set; }
   
    }
}
