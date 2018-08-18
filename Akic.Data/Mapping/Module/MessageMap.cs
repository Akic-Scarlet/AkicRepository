using Akic.Core.Domain.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Module
{
    public class MessageMap : AkicEntityTypeConfiguration<Message>
    {

        public MessageMap()
        {
            HasKey(m => m.Id);
            Property(m => m.Appendix).IsOptional().HasMaxLength(50);
            Property(m => m.Title).HasMaxLength(225).IsRequired();
            Property(m => m.Context).IsRequired();
            //configure table map
            this.ToTable("Message");
        }    
    }
}
