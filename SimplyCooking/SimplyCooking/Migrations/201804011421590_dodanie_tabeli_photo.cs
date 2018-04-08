namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_tabeli_photo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Contents = c.String(),
                        Image = c.Binary(),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Photos", new[] { "RecipeId" });
            DropTable("dbo.Photos");
        }
    }
}
