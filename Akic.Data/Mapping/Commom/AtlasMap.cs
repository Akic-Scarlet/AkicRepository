using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Commom
{
    public class AtlasMap : AkicEntityTypeConfiguration<Atlas>
    {
        public AtlasMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.AtlasName).HasMaxLength(255).IsOptional();
            this.Property(p => p.AtlasPath).HasMaxLength(255).IsOptional();
            this.Property(p => p.ThumbPath).HasMaxLength(255).IsOptional();
            this.Property(p => p.Remark).HasMaxLength(500).IsOptional();
            this.ToTable("Atlas");
        }

      
   
    }
}
