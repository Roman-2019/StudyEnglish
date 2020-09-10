namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PictureWords", "Picture_Id", "dbo.Pictures");
            DropForeignKey("dbo.PictureWords", "Word_Id", "dbo.Words");
            DropIndex("dbo.PictureWords", new[] { "Picture_Id" });
            DropIndex("dbo.PictureWords", new[] { "Word_Id" });
            AddColumn("dbo.Pictures", "WordId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "WordId");
            AddForeignKey("dbo.Pictures", "WordId", "dbo.Words", "Id", cascadeDelete: true);
            DropTable("dbo.PictureWords");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PictureWords",
                c => new
                    {
                        Picture_Id = c.Int(nullable: false),
                        Word_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Picture_Id, t.Word_Id });
            
            DropForeignKey("dbo.Pictures", "WordId", "dbo.Words");
            DropIndex("dbo.Pictures", new[] { "WordId" });
            DropColumn("dbo.Pictures", "WordId");
            CreateIndex("dbo.PictureWords", "Word_Id");
            CreateIndex("dbo.PictureWords", "Picture_Id");
            AddForeignKey("dbo.PictureWords", "Word_Id", "dbo.Words", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PictureWords", "Picture_Id", "dbo.Pictures", "Id", cascadeDelete: true);
        }
    }
}
