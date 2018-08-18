using Akic.Core;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public IRepository<T> baseDal;

        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T QueryWhere(Expression<Func<T, bool>> predicate)
        {
            return baseDal.QueryWhere(predicate);
        }

        public List<T> GetList( )
        {
            return baseDal.GetList( );
        }
        public List<T> GetList(Expression<Func<T, bool>> wherelambda)
        {
            return baseDal.GetList(wherelambda);
        }
        public List<T> GetList(Expression<Func<T, bool>> wherelambda, int count)
        {
            return baseDal.GetList(wherelambda,count);
        }

        public T GetById(object id)
        {
            return baseDal.GetById(id);
        }

        public void Insert(T entity)
        {
             baseDal.Insert(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
             baseDal.Insert(entities);
        }

        public void Update(T entity)
        {
            baseDal.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            baseDal.Update(entities);
        }

        public void Delete(T entity)
        {
            baseDal.Delete(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            baseDal.Delete(entities);
        }
        public void Delete(string id) 
        {
            baseDal.Delete(id);
        }
        public List<T> QueryOrderBy<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy)
        {
            return baseDal.QueryOrderBy(predicate, keySelector, IsQueryOrderBy);
        }
        public List<T> GetPageList<TKey>(int pageIndex, int pagesize, Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy)
        {
            return baseDal.GetPageList(pageIndex, pagesize, predicate, keySelector, IsQueryOrderBy);
        }
        public List<T> getSomeListByField<TKey>(List<T> source, int count, Expression<Func<T, TKey>> field)
        {
            return baseDal.getSomeListByField(source, count, field);
        }
        public virtual List<T> getSomeListByField<TKey>(List<T> source, int count, Expression<Func<T, TKey>> field, Expression<Func<T, bool>> predicate, bool IsQueryOrderBy)
        {
            return baseDal.getSomeListByField(source, count, field,predicate,IsQueryOrderBy);
        }
    }
}
