namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Recipes", name: "Typeofmeal_TypeofmealID", newName: "Typeofmeals_TypeofmealID");
            RenameIndex(table: "dbo.Recipes", name: "IX_Typeofmeal_TypeofmealID", newName: "IX_Typeofmeals_TypeofmealID");
            AddColumn("dbo.Recipes", "Typeofdishes_TypeofdishID", c => c.Int());
            AddColumn("dbo.Typeofdishes", "Photo_PhotoId", c => c.Int());
            AddColumn("dbo.Typeofdishes", "Recipe_RecipeID", c => c.Int());
            CreateIndex("dbo.Recipes", "Typeofdishes_TypeofdishID");
            CreateIndex("dbo.Typeofdishes", "Photo_PhotoId");
            CreateIndex("dbo.Typeofdishes", "Recipe_RecipeID");
            AddForeignKey("dbo.Typeofdishes", "Photo_PhotoId", "dbo.Photos", "PhotoId");
            AddForeignKey("dbo.Typeofdishes", "Recipe_RecipeID", "dbo.Recipes", "RecipeID");
            AddForeignKey("dbo.Recipes", "Typeofdishes_TypeofdishID", "dbo.Typeofdishes", "TypeofdishID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Typeofdishes_TypeofdishID", "dbo.Typeofdishes");
            DropForeignKey("dbo.Typeofdishes", "Recipe_RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.Typeofdishes", "Photo_PhotoId", "dbo.Photos");
            DropIndex("dbo.Typeofdishes", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.Typeofdishes", new[] { "Photo_PhotoId" });
            DropIndex("dbo.Recipes", new[] { "Typeofdishes_TypeofdishID" });
            DropColumn("dbo.Typeofdishes", "Recipe_RecipeID");
            DropColumn("dbo.Typeofdishes", "Photo_PhotoId");
            DropColumn("dbo.Recipes", "Typeofdishes_TypeofdishID");
            RenameIndex(table: "dbo.Recipes", name: "IX_Typeofmeals_TypeofmealID", newName: "IX_Typeofmeal_TypeofmealID");
            RenameColumn(table: "dbo.Recipes", name: "Typeofmeals_TypeofmealID", newName: "Typeofmeal_TypeofmealID");
        }
    }
}
