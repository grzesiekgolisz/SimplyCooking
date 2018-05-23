namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiany_comment_photo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "RecipeID" });
            DropColumn("dbo.Photos", "Title");
            DropColumn("dbo.Photos", "Contents");
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        Comment_ = c.String(),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            AddColumn("dbo.Photos", "Contents", c => c.String());
            AddColumn("dbo.Photos", "Title", c => c.String());
            CreateIndex("dbo.Comments", "RecipeID");
            CreateIndex("dbo.Comments", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Comments", "RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete: true);
        }
    }
}
