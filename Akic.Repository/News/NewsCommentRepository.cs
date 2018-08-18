using Akic.Core.Domain.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Repository
{
    public class NewsCommentRepository : EfRepository<NewsComment>, INewsCommentRepository
    {
    }
}
