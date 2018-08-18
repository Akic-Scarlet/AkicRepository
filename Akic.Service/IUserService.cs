using Akic.Core.Domain.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public interface IUserService : IBaseService<User>
    {
        User CheckLogin(string username, string password);
    }
}
