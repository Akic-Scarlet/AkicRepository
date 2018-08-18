using Akic.Core.Domain.CommentReply;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class NewsCommentReplyService :BaseService<NewsCommentReply>, INewsCommentReplyService
    {
         INewsCommentReplyRepositroy dal;
         public NewsCommentReplyService(INewsCommentReplyRepositroy dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
