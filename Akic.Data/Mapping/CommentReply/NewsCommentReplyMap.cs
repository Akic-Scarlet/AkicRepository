﻿using Akic.Core.Domain.CommentReply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.CommentReply
{
    public class NewsCommentReplyMap : AkicEntityTypeConfiguration<NewsCommentReply>
    {
        public NewsCommentReplyMap()
        {
            HasKey(nc => nc.Id);
            Property(nc => nc.Email).HasMaxLength(64);
            Property(nc => nc.Content).HasMaxLength(1024).IsRequired();
            ToTable("NewsCommentReply");
        }
    }
}