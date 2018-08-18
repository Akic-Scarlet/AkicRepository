using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Akic.Core
{
    public class PagerHelper
    {
        /// <summary>
        /// 生成分页Html数据
        /// </summary>
        /// <param name="currentPage">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="totalCount">数据总条数</param>
        /// <returns>pagerHtmlString</returns>
        public static string GeneratePagerString(int currentPage, int pageSize, int totalCount)
        {
            var redirectToUrl = HttpContext.Current.Request.Url.AbsolutePath;
            pageSize = pageSize <= 0 ? 4 : pageSize;

            //1.0 总页数
            int totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1);

            //2.0 分页条的容量
            int pageBarSize = 6;//默认一个分页条显示6个页码。分页条容量 

            //3.0 分页条的个数 totalPages个页数按 pageBarSize = 6  可以 分为多少个分页条
            int pageBarNum = (totalPages + pageBarSize - 1) / pageBarSize; // totalPages=13时，也就是把13个页码分成3个分页条

            //判断当前页currentPage坐落在第几个分页条内
            int position = (currentPage - 1) / pageBarSize;

            //根据分页条的序号，计算出该分页条的第一个页码start和最后一个页码end
            int start = position * pageBarSize + 1;

            //如果是最后一个分页条，则需判断它实际的页条容量；否则页条容量就是pageBarSize
            int curBarCapacity = pageBarSize;
            if (position == pageBarNum - 1)
            {
                curBarCapacity = totalPages - (pageBarNum - 1) * pageBarSize;
            }

            StringBuilder pagerHtmlString = new StringBuilder();
            StringBuilder endHtmlString = new StringBuilder();
           
            //处理首页
            pagerHtmlString.AppendFormat("<li class='start-page'><a href='{0}?pageIndex={1}&pageSize={2}'>首页</a></li> ", redirectToUrl, 1, pageSize);

            //处理上一页:如果当前页不是第一页,就加上上一页
            if (currentPage > 1)
            {
                pagerHtmlString.AppendFormat("<li class='prev-page'><a href='{0}?pageIndex={1}&pageSize={2}'>上一页</a></li> ", redirectToUrl, currentPage - 1, pageSize);
            }

            //假如起始位置start为1  7  13
            for (int i = 0; i < curBarCapacity; i++)  //curBarCapacity=3  i=0 1 2
            {
                int j = start + i; //要显示的页码当量值
                if (j == currentPage)
                {
                    //对当前页的处理:class=active
                    pagerHtmlString.AppendFormat("<li class='active show-page'><span>{0}</span></li> ", currentPage);

                    if (curBarCapacity == pageBarSize)
                    {
                        //不处理最后一个分页条页
                        if (currentPage == start + pageBarSize - 1)
                        {
                            if (currentPage + 1 < totalPages)
                            {
                                endHtmlString.AppendFormat("<li ><a href='{0}?pageIndex={1}&pageSize={2}'>{3}</a></li>", redirectToUrl, currentPage + 1, pageSize, currentPage + 1);
                            }
                            endHtmlString.Append("<li ><span>...</span></li>");
                            endHtmlString.AppendFormat("<li ><a href='{0}?pageIndex={1}&pageSize={2}'>{3}</a></li>", redirectToUrl, totalPages, pageSize, totalPages);
                        }
                    }

                }
                else
                {
                    pagerHtmlString.AppendFormat("<li ><a href='{0}?pageIndex={1}&pageSize={2}'>{3}</a></li> ", redirectToUrl, j, pageSize, j);
                }
            }

            //省略号的处理
            pagerHtmlString.Append(endHtmlString.ToString());

            //处理下一页：如果当前页不是最后一页，则加上下一页。也即中间的所有分页条都显示下一页
            if (currentPage != totalPages)
            {
                pagerHtmlString.AppendFormat("<li class='next-page'><a href='{0}?pageIndex={1}&pageSize={2}'>下一页</a></li> ", redirectToUrl, currentPage + 1, pageSize);
            }

            //处理末页
            pagerHtmlString.AppendFormat("<li id='end-page'><a href='{0}?pageIndex={1}&pageSize={2}'>末页</a></li> ", redirectToUrl, totalPages, pageSize);

            pagerHtmlString.AppendFormat("<li id='total-page'><span>共-{0}-页</span></li>", totalPages);

            pagerHtmlString.Append(" ");

            return pagerHtmlString.ToString();
        }
        public static string ShowPageNavigate(int currentPage, int pageSize, int totalCount)
        {

            var redirectTo = HttpContext.Current.Request.Url.AbsolutePath;
            pageSize = pageSize <= 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {

                //if (currentPage != 1)

                {//处理首页连接

                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a> ", redirectTo, pageSize);
                }
                if (currentPage > 1)
                {//处理上一页的连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", redirectTo, currentPage - 1, pageSize);
                }

                else
                {
                    // output.Append("<span class='pageLink'>上一页</span>");

                }
                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {

                        if (currint == i)
                        {//当前页处理

                            //output.Append(string.Format("[{0}]", currentPage));

                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage, pageSize, currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint);

                        }
                    }
                    output.Append(" ");

                }

                if (currentPage < totalPages)
                {//处理下一页的链接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a> ", redirectTo, currentPage + 1, pageSize);
                }
                else
                {
                    //output.Append("<span class='pageLink'>下一页</span>");
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a> ", redirectTo, totalPages, pageSize);
                }
                output.Append(" ");
            }
            output.AppendFormat("第{0}页 / 共{1}页", currentPage, totalPages);//这个统计加不加都行

            return output.ToString();

        }

    }
}
