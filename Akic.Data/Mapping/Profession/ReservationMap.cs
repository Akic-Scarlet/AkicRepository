using Akic.Core.Domain.Profession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Profession
{
    public class ReservationMap : AkicEntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            this.HasKey(rt => rt.Id);
            this.Property(rt => rt.SubscriberName).HasMaxLength(32).IsRequired();
            this.Property(rt => rt.StuNumber).HasMaxLength(32).IsRequired();
            this.Property(rt => rt.Phone).HasMaxLength(32).IsRequired();
            
            this.Property(rt => rt.Professional).HasMaxLength(64).IsRequired();

            this.Property(rt => rt.Email).IsOptional().HasMaxLength(64);
            this.Property(rt => rt.Past).IsOptional().HasMaxLength(128);
            this.Property(rt => rt.Experience).IsOptional().HasMaxLength(128);
            this.Property(rt => rt.Situation).IsOptional().HasMaxLength(2000);

            this.ToTable("Reservation");
        }    
    }
}
