namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Voice = c.Binary(),
                        AudioPath = c.String(),
                        WordId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.WordId)
                .Index(t => t.WordId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Marker = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RussianWord = c.String(),
                        EnglishWord = c.String(),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorOnRussian = c.String(),
                        ColorOnEnglish = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ColorWords",
                c => new
                    {
                        Color_Id = c.Int(nullable: false),
                        Word_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Color_Id, t.Word_Id })
                .ForeignKey("dbo.Colors", t => t.Color_Id, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.Word_Id, cascadeDelete: true)
                .Index(t => t.Color_Id)
                .Index(t => t.Word_Id);
            
            CreateTable(
                "dbo.PictureWords",
                c => new
                    {
                        Picture_Id = c.Int(nullable: false),
                        Word_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_Id, t.Word_Id })
                .ForeignKey("dbo.Pictures", t => t.Picture_Id, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.Word_Id, cascadeDelete: true)
                .Index(t => t.Picture_Id)
                .Index(t => t.Word_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Words", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.PictureWords", "Word_Id", "dbo.Words");
            DropForeignKey("dbo.PictureWords", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.ColorWords", "Word_Id", "dbo.Words");
            DropForeignKey("dbo.ColorWords", "Color_Id", "dbo.Colors");
            DropForeignKey("dbo.Audios", "WordId", "dbo.Words");
            DropForeignKey("dbo.Audios", "TopicId", "dbo.Topics");
            DropIndex("dbo.PictureWords", new[] { "Word_Id" });
            DropIndex("dbo.PictureWords", new[] { "Picture_Id" });
            DropIndex("dbo.ColorWords", new[] { "Word_Id" });
            DropIndex("dbo.ColorWords", new[] { "Color_Id" });
            DropIndex("dbo.Words", new[] { "TopicId" });
            DropIndex("dbo.Audios", new[] { "TopicId" });
            DropIndex("dbo.Audios", new[] { "WordId" });
            DropTable("dbo.PictureWords");
            DropTable("dbo.ColorWords");
            DropTable("dbo.Pictures");
            DropTable("dbo.Colors");
            DropTable("dbo.Words");
            DropTable("dbo.Topics");
            DropTable("dbo.Audios");
        }
    }
}
