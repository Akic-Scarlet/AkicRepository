using Akic.Core.Domain.Log;
using Akic.Core.ResultHelper;
using Akic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.LogHandler
{
    public static class LogRecord
    {
        public static void WriteServiceLog(string oper, string mes, string loglevel)
        {
            Log entity = new Log();
            
            entity.Id = ResultHelper.NewId;
            entity.AddedDate = ResultHelper.NowTime;
            entity.Message = mes;
            entity.Level = loglevel;
            entity.Logger = oper; 
            LogRepository logRepository = new LogRepository();
            logRepository.Insert(entity);
        }
    }
}
