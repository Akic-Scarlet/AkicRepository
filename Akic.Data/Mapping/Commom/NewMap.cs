using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Commom
{
    public class NewMap : AkicEntityTypeConfiguration<News>
    {
        public NewMap()
        {
            this.HasKey(n => n.Id);
            this.Property(n => n.NewsTitle).HasMaxLength(100).IsRequired();
            this.Property(n => n.NewsContent).IsRequired();
            this.ToTable("News");
        }

    }
}
