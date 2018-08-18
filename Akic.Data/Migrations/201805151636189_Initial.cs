namespace Akic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(maxLength: 32),
                        Password = c.String(nullable: false, maxLength: 32),
                        RealName = c.String(nullable: false, maxLength: 32),
                        StuNumber = c.String(nullable: false, maxLength: 32),
                        Identification = c.String(nullable: false, maxLength: 64),
                        Gender = c.String(),
                        Phone = c.String(maxLength: 32),
                        Email = c.String(maxLength: 64),
                        PhotoUrl = c.String(maxLength: 96),
                        About = c.String(maxLength: 140),
                        PersonalPage = c.String(maxLength: 64),
                        State = c.Int(),
                        Roles = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FbDocument",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DocumentName = c.String(),
                        DocumentUrl = c.String(),
                        FeedbackId = c.String(maxLength: 128),
                        UploaderId = c.String(),
                        UploaderName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .ForeignKey("dbo.Feedback", t => t.FeedbackId)
                .Index(t => t.FeedbackId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ArticleComment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReadStatus = c.Int(nullable: false),
                        UpId = c.String(),
                        NickName = c.String(maxLength: 32),
                        Email = c.String(maxLength: 64),
                        Content = c.String(nullable: false, maxLength: 1024),
                        IsMember = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                        Identification = c.String(),
                        UniqueKey = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookComment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Score = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReadStatus = c.Int(nullable: false),
                        UpId = c.String(),
                        NickName = c.String(maxLength: 32),
                        Email = c.String(maxLength: 64),
                        Content = c.String(nullable: false, maxLength: 1024),
                        IsMember = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                        Identification = c.String(),
                        UniqueKey = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsComment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UpId = c.String(),
                        NickName = c.String(maxLength: 32),
                        Email = c.String(maxLength: 64),
                        Content = c.String(nullable: false, maxLength: 1024),
                        IsMember = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                        Identification = c.String(),
                        UniqueKey = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suggestion",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NickName = c.String(maxLength: 32),
                        Email = c.String(maxLength: 64),
                        Content = c.String(nullable: false, maxLength: 1024),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoComment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UpId = c.String(),
                        NickName = c.String(maxLength: 32),
                        Email = c.String(maxLength: 64),
                        Content = c.String(nullable: false, maxLength: 1024),
                        IsMember = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                        Identification = c.String(),
                        UniqueKey = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ArticleTitle = c.String(nullable: false, maxLength: 100),
                        Category = c.String(),
                        IsTop = c.Boolean(nullable: false),
                        ArticleContent = c.String(nullable: false),
                        ViewTimes = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        ArticleTags = c.String(),
                        ThumbPath = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Atlas",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AtlasName = c.String(maxLength: 255),
                        ThumbPath = c.String(maxLength: 255),
                        AtlasPath = c.String(maxLength: 255),
                        Remark = c.String(maxLength: 500),
                        Hits = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NewsTitle = c.String(nullable: false, maxLength: 100),
                        Category = c.String(),
                        IsTop = c.Boolean(nullable: false),
                        NewsContent = c.String(nullable: false),
                        ViewTimes = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        NewsTags = c.String(),
                        ThumbPath = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AtlasId = c.String(),
                        PhotoName = c.String(maxLength: 255),
                        PhotoTags = c.String(),
                        ThumbPath = c.String(nullable: false, maxLength: 255),
                        PhotoPath = c.String(nullable: false, maxLength: 255),
                        Remark = c.String(maxLength: 500),
                        Hits = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VideoName = c.String(nullable: false, maxLength: 50),
                        ThumbPath = c.String(),
                        VideoPath = c.String(),
                        Remark = c.String(maxLength: 500),
                        Hits = c.Int(nullable: false),
                        CommentNum = c.Int(nullable: false),
                        Category = c.String(),
                        ComesFrom = c.String(nullable: false, maxLength: 100),
                        IsLocal = c.Boolean(nullable: false),
                        Recommend = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FeedbackName = c.String(nullable: false, maxLength: 32),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Thread = c.String(),
                        Level = c.String(),
                        Logger = c.String(),
                        Message = c.DateTime(nullable: false),
                        Exception = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginLog",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        UserName = c.String(),
                        IP = c.String(),
                        ComputerName = c.String(),
                        Platform = c.String(),
                        UserAgent = c.String(),
                        Type = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 225),
                        Context = c.String(nullable: false),
                        Appendix = c.String(maxLength: 50),
                        Type = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        EditTime = c.DateTime(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyMessage",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MId = c.String(),
                        UserId = c.String(maxLength: 128),
                        Status = c.Boolean(nullable: false),
                        RecentTime = c.DateTime(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        MessageModel_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.MessageModel_Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MessageModel_Id);
            
            CreateTable(
                "dbo.RecentActivity",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 1000),
                        StartTime = c.DateTime(nullable: false),
                        Address = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TagName = c.String(nullable: false, maxLength: 50),
                        Belong = c.Int(nullable: false),
                        TagEnglish = c.String(),
                        TagDescription = c.String(maxLength: 500),
                        TagSum = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        SubscriberName = c.String(nullable: false, maxLength: 32),
                        StuNumber = c.String(nullable: false, maxLength: 32),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Professional = c.String(nullable: false, maxLength: 64),
                        Phone = c.String(nullable: false, maxLength: 32),
                        Email = c.String(maxLength: 64),
                        Past = c.String(maxLength: 128),
                        Experience = c.String(maxLength: 128),
                        Dealtime = c.DateTime(nullable: false),
                        Situation = c.String(maxLength: 2000),
                        State = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 25),
                        Password = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        AddedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfile", "Id", "dbo.UserInfo");
            DropForeignKey("dbo.MyMessage", "UserId", "dbo.User");
            DropForeignKey("dbo.MyMessage", "MessageModel_Id", "dbo.Message");
            DropForeignKey("dbo.FbDocument", "FeedbackId", "dbo.Feedback");
            DropForeignKey("dbo.FbDocument", "User_Id", "dbo.User");
            DropIndex("dbo.UserProfile", new[] { "Id" });
            DropIndex("dbo.MyMessage", new[] { "MessageModel_Id" });
            DropIndex("dbo.MyMessage", new[] { "UserId" });
            DropIndex("dbo.FbDocument", new[] { "User_Id" });
            DropIndex("dbo.FbDocument", new[] { "FeedbackId" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.UserInfo");
            DropTable("dbo.Reservation");
            DropTable("dbo.Tag");
            DropTable("dbo.RecentActivity");
            DropTable("dbo.MyMessage");
            DropTable("dbo.Message");
            DropTable("dbo.LoginLog");
            DropTable("dbo.Log");
            DropTable("dbo.Feedback");
            DropTable("dbo.Video");
            DropTable("dbo.Photo");
            DropTable("dbo.News");
            DropTable("dbo.Atlas");
            DropTable("dbo.Article");
            DropTable("dbo.VideoComment");
            DropTable("dbo.Suggestion");
            DropTable("dbo.NewsComment");
            DropTable("dbo.BookComment");
            DropTable("dbo.ArticleComment");
            DropTable("dbo.FbDocument");
            DropTable("dbo.User");
        }
    }
}
