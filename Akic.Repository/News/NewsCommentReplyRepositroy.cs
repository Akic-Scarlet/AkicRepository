﻿using Akic.Core.Domain.CommentReply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Repository
{
    public class NewsCommentReplyRepositroy : EfRepository<NewsCommentReply>, INewsCommentReplyRepositroy
    {
    }
}
