using Akic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> wherelambda);
        List<T> GetList(Expression<Func<T, bool>> wherelambda,int count);
        T QueryWhere(Expression<Func<T, bool>> wherelambda);
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(object id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);
        void Delete(string id);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<T> entities);
         List<T> QueryOrderBy<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy);
         List<T> GetPageList<TKey>(int pageIndex, int pagesize, Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy);
         List<T> getSomeListByField<TKey>(List<T>source, int count, Expression<Func<T, TKey>> field);
         List<T> getSomeListByField<TKey>(List<T> source, int count, Expression<Func<T, TKey>> field, Expression<Func<T, bool>> predicate,bool IsQueryOrderBy);
    }
}
