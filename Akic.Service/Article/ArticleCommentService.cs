using Akic.Core.Domain.Comment;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class ArticleCommentService : BaseService<ArticleComment>, IArticleCommentService
    {
        IArticleCommentRepositroy dal;

        public ArticleCommentService(IArticleCommentRepositroy dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
