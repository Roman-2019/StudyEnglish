namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "TopicId");
            AddForeignKey("dbo.Pictures", "TopicId", "dbo.Topics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "TopicId", "dbo.Topics");
            DropIndex("dbo.Pictures", new[] { "TopicId" });
            DropColumn("dbo.Pictures", "TopicId");
        }
    }
}
