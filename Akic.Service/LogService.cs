using Akic.Core.Domain.Log;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Service
{
    public class LogService : BaseService<Log>, ILogService
    {
         ILogRepository dal;

         public LogService(ILogRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
