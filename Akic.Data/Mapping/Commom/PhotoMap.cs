using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Commom
{
    public class PhotoMap : AkicEntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.PhotoName).HasMaxLength(255).IsOptional();
            this.Property(p => p.PhotoPath).HasMaxLength(255).IsRequired();
            this.Property(p => p.ThumbPath).HasMaxLength(255).IsRequired();
            this.Property(p => p.Remark).HasMaxLength(500).IsOptional();
            this.ToTable("Photo");
        }    
     
       
    }
}
