using Akic.Core.Domain.Log;
using System;


namespace Akic.Data.Mapping.Log_
{
    public class LoginLogMap : AkicEntityTypeConfiguration<LoginLog>
    {
        public LoginLogMap()
        {
            HasKey(kc => kc.Id);
            ToTable("LoginLog");
        }    
    }
}
