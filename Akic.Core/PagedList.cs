using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core
{

    public class PagedList<T> : List<T>, IPagedList<T>
    {

        public PagedList(IQueryable<T> source, int pageIndex, int pagesize )
        {        
            this.TotalCount = source.Count();
            this.TotalPages = TotalCount / pagesize;
            if (TotalCount % pagesize>0)
                ++TotalPages;

            this.PageSize = pagesize;
            this.PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pagesize).Take(pagesize).ToList());

        }
        public PagedList(IList<T> source, int pageIndex, int pagesize )
        {
            this.TotalCount = source.Count();
            this.TotalPages = TotalCount / pagesize;
            if (TotalCount % pagesize > 0)
                ++TotalPages;

            this.PageSize = pagesize;
            this.PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pagesize).Take(pagesize).ToList());
        }
        public PagedList(IEnumerable<T> source, int pageIndex, int pagesize)
        {
            this.TotalCount = source.Count();
            this.TotalPages = TotalCount / pagesize;
            if (TotalCount % pagesize > 0)
                ++TotalPages;

            this.PageSize = pagesize;
            this.PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pagesize).Take(pagesize).ToList());
        }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get { return PageIndex > 0; } }

        public bool HasNextPage { get { return PageIndex + 1 < TotalPages; } }
    }
}
