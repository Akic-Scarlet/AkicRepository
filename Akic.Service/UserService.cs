using Akic.Core.Domain.Module;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class UserService : BaseService<User>, IUserService
    {
         IUserRepository dal;

         public UserService(IUserRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
         public User CheckLogin(string username, string password)
         {
             return dal.QueryWhere(u => u.UserName == username && u.Password == password);
         }
    }
}
