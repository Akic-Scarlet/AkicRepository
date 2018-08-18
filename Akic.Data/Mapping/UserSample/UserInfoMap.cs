using Akic.Core.Domain.UserSample;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Data.Mapping.UserSample
{
    public class UserInfoMap:AkicEntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            //配置主键
            this.HasKey(s => s.Id);

            //给ID配置自动增长
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //配置字段
            this.Property(s => s.UserName).IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
            this.Property(s => s.Email).IsRequired().HasColumnType("nvarchar").HasMaxLength(25);
            this.Property(s => s.AddedDate).IsRequired();
            this.Property(s => s.ModifiedDate).IsRequired();

            //配置表
            this.ToTable("UserInfo");


        }
    }

   
}
