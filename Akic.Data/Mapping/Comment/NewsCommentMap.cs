using Akic.Core.Domain.Comment;
using Akic.Core.Domain.Commom;

namespace Akic.Data.Mapping.Comment
{
    public class NewsCommentMap : AkicEntityTypeConfiguration<NewsComment>
    {
        public NewsCommentMap()
        {
            HasKey(nc => nc.Id);
            Property(nc => nc.Email).HasMaxLength(64);
            Property(nc => nc.NickName).HasMaxLength(32);
            Property(nc => nc.Content).HasMaxLength(1024).IsRequired();
            ToTable("NewsComment");
        }
    }
}
