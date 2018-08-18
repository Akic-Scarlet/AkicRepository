using Akic.Core.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Repository
{
    public class ArticleRepositroy:EfRepository<Article>,IArticleRepositroy
    {
    }
}
