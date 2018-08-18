using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akic.Core.Domain.Log
{
    [Table("Log")]  
    public class Log:BaseEntity
    {
       
 
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
