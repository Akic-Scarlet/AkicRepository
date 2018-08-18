using Akic.Core.Domain.Comment;
using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.Comment
{
    public class ArticleCommentMap : AkicEntityTypeConfiguration<ArticleComment>
    {
        public ArticleCommentMap()
        {
            HasKey(nc => nc.Id);
            Property(nc => nc.Email).HasMaxLength(64);
            Property(nc => nc.NickName).HasMaxLength(32);
            Property(nc => nc.Content).HasMaxLength(1024).IsRequired();
            ToTable("ArticleComment");
        }
    }
}
