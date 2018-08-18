using Akic.Core.Domain.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Repository
{
    public class UserRepository:EfRepository<User>,IUserRepository
    {
    }
}
