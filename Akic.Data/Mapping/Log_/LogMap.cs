using System;
using Akic.Core.Domain.Log;

namespace Akic.Data.Mapping.Log_
{
    public class LogMap : AkicEntityTypeConfiguration<Log>
    {

        public LogMap()
        {
            HasKey(kc => kc.Id);
            ToTable("Log");
        }    
    }
}
