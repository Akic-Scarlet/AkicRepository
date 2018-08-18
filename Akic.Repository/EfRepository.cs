using Akic.Core;
using Akic.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Repository
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
         AkicObjectContext db { get {
                //先从线程缓存CallContext中根据key查找EF容器对象，如果没有则创建,同时保存到缓存中
                object obj = CallContext.GetData(typeof(AkicObjectContext).FullName);
                if (obj == null)
                {
                    //例化EF的上下文容器对象
                    obj = new AkicObjectContext();
                    //将EF的上下文容器对象存入线程缓存CallContext中
                    CallContext.SetData(typeof(AkicObjectContext).FullName, obj);
                }
                //将当前的EF上下文对象返回
                return obj as AkicObjectContext;
             
            }
        }
        private DbSet<T> Entities;
        public T QueryWhere(Expression<Func<T, bool>> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }

        public EfRepository()
        {
            Entities = db.Set<T>();
        }


        

        #region Utilities

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg +=string.Format("Property: {0} Error: {1} {2}",error.PropertyName,error.ErrorMessage, Environment.NewLine);
            return msg;
        }

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="dbEx">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbEntityValidationException dbEx)
        {
            var fullErrorText = GetFullErrorText(dbEx);

            foreach (var entry in dbEx.EntityValidationErrors.Select(error => error.Entry))
            {
                if (entry == null)
                    continue;

                //rollback of entity changes
                entry.State = EntityState.Unchanged;
            }

            db.SaveChanges();
            return fullErrorText;
        }

#endregion
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {    
            return Entities.Find(id);
        }
        public virtual List<T> GetList() 
        {
            return Entities.ToList();
        }
        public virtual List<T> GetList(Expression<Func<T, bool>> wherelambda)
        {
            var tmp = Entities.Where(wherelambda).ToList() ;
            return tmp;
        }
        public virtual List<T> GetList(Expression<Func<T, bool>> wherelambda, int count)
        {
            var tmp = Entities.Where(wherelambda).Take(count).ToList();
            return tmp;
        }
        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Add(entity);

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }
  

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Add(entity);

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    Entities.Remove(entity);

                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);

                
            }
        }
        public virtual void Delete(string id)
        {
            try
            {
                  
                var model = Entities.FirstOrDefault(t => t.Id == id);
                if(model==null)
                    throw new ArgumentNullException("entity");
                Entities.Remove(model);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);


            }
        }

        /// <summary>
        /// 升序查询还是降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="IsQueryOrderBy"></param>
        /// <returns></returns>
        public virtual List<T> QueryOrderBy<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy)
        {
            if (IsQueryOrderBy)
            {
                return Entities.Where(predicate).OrderBy(keySelector).ToList();
            }
            return Entities.Where(predicate).OrderByDescending(keySelector).ToList();

        }

        /// <summary>
        /// 升序分页查询还是降序分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pagesize">一页多少条</param>
        /// <param name="rowcount">返回共多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <param name="IsQueryOrderBy">true为升序 false为降序</param>
        /// <returns></returns>
        public virtual List<T> GetPageList<TKey>(int pageIndex, int pagesize, Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> keySelector, bool IsQueryOrderBy)
        {
 
            if (IsQueryOrderBy)
            {
                return Entities.Where(predicate).OrderBy(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
            }
            else
            {
                return Entities.Where(predicate).OrderByDescending(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
            }
        }
        public virtual List<T> getSomeListByField<TKey>(List<T> source, int count, Expression<Func<T, TKey>> field)
        { 
            var tmp=(from r in source
                         orderby field
                         select r).Take(count).ToList();
            return tmp;
        }
        public  List<T> getSomeListByField<TKey>(List<T> source, int count, Expression<Func<T, TKey>> field,Expression<Func<T, bool>> predicate,bool IsQueryOrderBy)
        {
            if (IsQueryOrderBy)
            {
                return Entities.Where(predicate).OrderBy(field).Take(count).ToList();
            }
            else
            {
                return Entities.Where(predicate).OrderByDescending(field).Take(count).ToList();
            }
        }
    }
}

