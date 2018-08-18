using Akic.Core.Domain.CommentReply;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class ArticleCommentReplyService : BaseService<ArticleCommentReply>, IArticleCommentReplyService
    {
         IArticleCommentReplyRepositroy dal;

         public ArticleCommentReplyService(IArticleCommentReplyRepositroy dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
