using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core
{
    public interface IPagedList<T>
    {
        /// <summary>
        /// page index
        /// </summary>
        int PageIndex { get; set; }
        /// <summary>
        /// page size
        /// </summary>
        int PageSize { get; set; }
        /// <summary>
        /// Total count
        /// </summary>
        int TotalCount { get; set; }
        /// <summary>
        /// total pages
        /// </summary>
        int TotalPages { get; set; }
        /// <summary>
        /// has previous page
        /// </summary>
        bool HasPreviousPage { get;  }
        /// <summary>
        /// has nextpage
        /// </summary>
        bool HasNextPage { get; }
    }
}
