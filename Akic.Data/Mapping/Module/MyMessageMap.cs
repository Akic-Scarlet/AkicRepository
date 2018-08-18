using Akic.Core.Domain.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Module
{
    public class MyMessageMap : AkicEntityTypeConfiguration<MyMessage>
    {

        public MyMessageMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Status).IsRequired();
           
            //configure table map
            this.ToTable("MyMessage");
        }    
    }
}
