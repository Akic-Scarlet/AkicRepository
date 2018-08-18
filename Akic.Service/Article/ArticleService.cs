using Akic.Core.Domain.Commom;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class ArticleService:BaseService<Article>,IArticleService
    {
        IArticleRepositroy dal;

        public ArticleService(IArticleRepositroy dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
