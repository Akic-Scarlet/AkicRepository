using Akic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        List<T> GetList( );
        List<T> GetList(Expression<Func<T, bool>> wherelambda);
        List<T> GetList(Expression<Func<T, bool>> wherelambda, int count);
        T QueryWhere(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities); 
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Delete(string id);

        List<T> QueryOrderBy<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy);
        List<T> GetPageList<TKey>(int pageIndex, int pagesize, Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy);
        List<T> getSomeListByField<TKey>(List<T> source, int count, Expression<Func<T, TKey>> field);
        List<T> getSomeListByField<TKey>(List<T> source, int count, Expression<Func<T, TKey>> field, Expression<Func<T, bool>> predicate, bool IsQueryOrderBy);

    }
}
