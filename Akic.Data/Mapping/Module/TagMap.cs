using Akic.Core.Domain.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Module
{

    public class TagMap : AkicEntityTypeConfiguration<Tag>
    {

        public TagMap() 
        {
            HasKey(t => t.Id);
            Property(t => t.TagName).HasMaxLength(50).IsRequired();
            Property(t => t.TagDescription).HasMaxLength(500).IsOptional();
            ToTable("Tag");
        }
      
    }
}
