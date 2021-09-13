namespace NetChill.Backend.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieLists",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        MovieId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Category = c.String(nullable: false, maxLength: 255),
                        YearOfRelease = c.Int(nullable: false),
                        AvailabilityStarts = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        PosterPath = c.String(nullable: false),
                        ContentPath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.Users Values('701cde8a-506a-4cb6-a784-8dae9d340172' , 'Admin' , 'admin@gmail.com' , '12345678', 1)");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [Name], [Category], [YearOfRelease], [AvailabilityStarts], [Description], [IsFeatured], [PosterPath], [ContentPath]) VALUES (N'61647d10-ae13-ec11-b7a4-7478278301b4', N'Avatar', N'Sci-fi', 2009, N'2010-07-12 00:00:00', N'Jake, who is paraplegic, replaces his twin on the Na''vi inhabited Pandora for a corporate mission. After the natives accept him as one of their own, he must decide where his loyalties lie.', 1, N'https://m.media-amazon.com/images/M/MV5BMTYwOTEwNjAzMl5BMl5BanBnXkFtZTcwODc5MTUwMw@@._V1_FMjpg_UX1000_.jpg', N'https://www.youtube.com/embed/5PSNL1qE6VY')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [Name], [Category], [YearOfRelease], [AvailabilityStarts], [Description], [IsFeatured], [PosterPath], [ContentPath]) VALUES (N'6c40d847-ae13-ec11-b7a4-7478278301b4', N'Batman Begins', N'Action', 2005, N'2005-06-17 00:00:00', N'After witnessing his parents'' death, Bruce learns the art of fighting to confront injustice. When he returns to Gotham as Batman, he must stop a secret society that intends to destroy the city.', 1, N'https://resizing.flixster.com/gG9jEpn7NVg5pYWwQidlxiBJ3HA=/206x305/v2/https://flxt.tmsimg.com/NowShowing/48435/48435_aa.jpg', N'https://www.youtube.com/embed/neY2xVmOfUM')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [Name], [Category], [YearOfRelease], [AvailabilityStarts], [Description], [IsFeatured], [PosterPath], [ContentPath]) VALUES (N'466b1d78-ae13-ec11-b7a4-7478278301b4', N'Sherlock Homes', N'Mystery', 2010, N'2010-01-08 00:00:00', N'Detective Sherlock Holmes and his partner, Dr Watson, send Blackwood, a serial killer, to the gallows. However, they are shocked to learn that he is back from the dead and must pursue him again.', 0, N'https://i.pinimg.com/originals/04/37/7e/04377e17d4ee3bca9c2e32b7859e1cfa.jpg', N'https://www.youtube.com/embed/J7nJksXDBWc')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [Name], [Category], [YearOfRelease], [AvailabilityStarts], [Description], [IsFeatured], [PosterPath], [ContentPath]) VALUES (N'5de571d5-fa13-ec11-b7a4-7478278301b4', N'Shutter Island', N'Thriller', 2010, N'2010-06-04 00:00:00', N'Teddy Daniels and Chuck Aule, two US marshals, are sent to an asylum on a remote island in order to investigate the disappearance of a patient, where Teddy uncovers a shocking truth about the place.', 0, N'https://i.ytimg.com/vi/Udfq0fiScug/movieposter_en.jpg', N'https://www.youtube.com/embed/v8yrZSkKxTA')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [Name], [Category], [YearOfRelease], [AvailabilityStarts], [Description], [IsFeatured], [PosterPath], [ContentPath]) VALUES (N'fc5ff2c2-fc13-ec11-b7a4-7478278301b4', N'Venom: Let There Be Carnage', N'Adventure', 2021, N'2021-10-15 00:00:00', N'Venom springs into action when notorious serial killer Cletus Kasady transforms into the evil Carnage.', 1, N'https://upload.wikimedia.org/wikipedia/en/thumb/a/a7/Venom_Let_There_Be_Carnage_poster.jpg/220px-Venom_Let_There_Be_Carnage_poster.jpg', N'https://www.youtube.com/embed/-FmWuCgJmxo')");
            Sql("INSERT INTO [dbo].[Movies] ([Id], [Name], [Category], [YearOfRelease], [AvailabilityStarts], [Description], [IsFeatured], [PosterPath], [ContentPath]) VALUES (N'cef3d20f-5a14-ec11-b7a4-7478278301b4', N'No Time To Die', N'Action', 2021, N'2021-09-30 00:00:00', N'Recruited to rescue a kidnapped scientist, globe-trotting spy James Bond finds himself hot on the trail of a mysterious villain, who''s armed with a dangerous new technology.', 1, N'https://m.media-amazon.com/images/M/MV5BYWQ2NzQ1NjktMzNkNS00MGY1LTgwMmMtYTllYTI5YzNmMmE0XkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_.jpg', N'https://www.youtube.com/embed/N_gD9-Oa0fg')");

        }

        public override void Down()
        {
            DropForeignKey("dbo.MovieLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.MovieLists", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieLists", new[] { "MovieId" });
            DropIndex("dbo.MovieLists", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieLists");
        }
    }
}
