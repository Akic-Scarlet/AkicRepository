using Akic.Core.Domain.Commom;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class NewsService :BaseService<News>,INewsService
    {
        INewsRepository dal;

        public NewsService(INewsRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }

        public List<News> getSomeTop(List<News> source,int count)
        {
           var tmp=(from r in source
                    where r.IsTop=true
                        orderby r.AddedDate 
                    select r).Take(count);
            return tmp.ToList();
        }

        public List<News> getSomeNew(List<News> source, int count)
        {
            var tmp = (from r in source
                       orderby r.AddedDate
                       select r).Take(count);
            return tmp.ToList();
        }

       
    }
}
