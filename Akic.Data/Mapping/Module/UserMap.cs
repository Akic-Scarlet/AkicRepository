using Akic.Core.Domain.Feedback;
using Akic.Core.Domain.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Module
{
    public class UserMap : AkicEntityTypeConfiguration<User>
    {
        public UserMap() 
        {
            this.HasKey(u => u.Id);
            this.Property(u => u.UserName).IsOptional().HasMaxLength(32);
            this.Property(u => u.Password).HasMaxLength(32).IsRequired();
            this.Property(u => u.RealName).HasMaxLength(32).IsRequired();
            this.Property(u => u.StuNumber).HasMaxLength(32).IsRequired();
            this.Property(u => u.Identification).HasMaxLength(64).IsRequired();
            this.Property(u => u.Gender).IsOptional();
            this.Property(u => u.Phone).IsOptional().HasMaxLength(32);
            this.Property(u => u.Email).IsOptional().HasMaxLength(64);
            this.Property(u => u.PhotoUrl).IsOptional().HasMaxLength(96);
            this.Property(u => u.About).IsOptional().HasMaxLength(140);
            this.Property(u => u.PersonalPage).IsOptional().HasMaxLength(64);
            this.Property(u => u.State).IsOptional();
            //configure table map
            this.ToTable("User");
        }
    }
}
