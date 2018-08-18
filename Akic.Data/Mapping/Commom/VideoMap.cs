using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Commom
{
    public class VideoMap : AkicEntityTypeConfiguration<Video>
    {
        public VideoMap() 
        {
            this.HasKey(v => v.Id);
            this.Property(v => v.VideoName).HasMaxLength(50).IsRequired();
            this.Property(v => v.Remark).HasMaxLength(500).IsOptional();
            this.ToTable("Video");
        }
    }
}
