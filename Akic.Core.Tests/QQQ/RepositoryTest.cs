using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core.Tests.QQQ
{
    public class RepositoryTest
    {
        Model1 db;
        public RepositoryTest()
        {
            db = new Model1();
        }

        public User GetOneByExpression(Expression<Func<User, bool>> whereLambda)
        {
           return db.Set<User>().SingleOrDefault(whereLambda);
        }
    }
}
