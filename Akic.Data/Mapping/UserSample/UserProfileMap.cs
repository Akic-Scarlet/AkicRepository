using Akic.Core.Domain.UserSample;

namespace Akic.Data.Mapping.UserSample
{
    public class UserProfileMap:AkicEntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            this.HasKey(s => s.Id);

            this.Property(s => s.FirstName).IsRequired();
            this.Property(s => s.LastName).IsRequired();
            this.Property(s => s.Address).HasMaxLength(100).HasColumnType("nvarchar").IsRequired();

            this.Property(s => s.AddedDate).IsRequired();
            this.Property(s => s.ModifiedDate).IsRequired();
            

            //配置关系[一个用户只能有一个用户详情！！！]
            this.HasRequired(s => s.User).WithRequiredDependent(s => s.UserProfile);

            this.ToTable("UserProfile"); 
           }
        //配置主键
           
    }
}
