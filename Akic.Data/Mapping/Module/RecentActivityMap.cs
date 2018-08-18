using Akic.Core.Domain.Module;
using System;
using System.ComponentModel.DataAnnotations;

namespace Akic.Data.Mapping.Module
{
    public class RecentActivityMap : AkicEntityTypeConfiguration<RecentActivity>
    {
         
         
        public RecentActivityMap ()
        {
            this.HasKey(n => n.Id);
            this.Property(n => n.Title).HasMaxLength(100).IsRequired();
            this.Property(n => n.Content).HasMaxLength(1000).IsRequired();
            this.ToTable("RecentActivity");
        }
    }
}
