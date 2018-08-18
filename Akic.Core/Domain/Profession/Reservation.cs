using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Domain.Profession
{
       [Table("Reservation")]  
    public class Reservation : BaseEntity
    {
       
        public string SubscriberName { get; set; }
        public string StuNumber { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string Professional { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Past { get; set; }
        public string Experience { get; set; }
    
        public string Situation { get; set; }
       
        public int State { get; set; }
    }
}
