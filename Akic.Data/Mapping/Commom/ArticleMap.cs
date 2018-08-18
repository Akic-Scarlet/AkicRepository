using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Commom
{
    public class ArticleMap : AkicEntityTypeConfiguration<Article>
    {
        public ArticleMap() 
        {
         this.HasKey(n => n.Id);
            this.Property(n => n.ArticleTitle).HasMaxLength(100).IsRequired();
            this.Property(n => n.ArticleContent).IsRequired();
            this.ToTable("Article");
        }
    }
}
