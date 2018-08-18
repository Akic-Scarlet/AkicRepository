using Akic.Core.Domain.Comment;
using Akic.Core.Domain.CommentReply;
using Akic.Core.Domain.Commom;
using Akic.Core.Domain.Feedback;
using Akic.Core.Domain.Log;
using Akic.Core.Domain.Module;
using Akic.Core.Domain.Profession;
using Akic.Data.Mapping;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace Akic.Data
{
    public class AkicObjectContext : DbContext
    {
        public AkicObjectContext()
            : base("name=DbConnectionString")
        {
            Database.SetInitializer<AkicObjectContext>(null);
        }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<NewsComment> NewsComment { get; set; }
        public virtual DbSet<NewsCommentReply> NewsCommentReply { get; set; }
        public virtual DbSet<Suggestion> Suggestion { get; set; }
        public virtual DbSet<VideoComment> VideoComment { get; set; }
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleComment> ArticleComment { get; set; }
        public virtual DbSet<ArticleCommentReply> ArticleCommentReply { get; set; }
        public virtual DbSet<Atlas> Atlas { get; set; }
        public virtual DbSet<News> New { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<FbDocument> FbDocument { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<LoginLog> LoginLog { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<MyMessage> MyMessage { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }




      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
              .Where(type => !String.IsNullOrEmpty(type.Namespace))
              .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                   && type.BaseType.GetGenericTypeDefinition() == typeof(AkicEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

    }
}
