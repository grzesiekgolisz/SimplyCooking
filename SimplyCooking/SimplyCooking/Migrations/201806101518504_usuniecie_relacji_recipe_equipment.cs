namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuniecie_relacji_recipe_equipment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentRecipes", "Equipment_EquipmentID", "dbo.Equipments");
            DropForeignKey("dbo.EquipmentRecipes", "Recipe_RecipeID", "dbo.Recipes");
            DropIndex("dbo.EquipmentRecipes", new[] { "Equipment_EquipmentID" });
            DropIndex("dbo.EquipmentRecipes", new[] { "Recipe_RecipeID" });
            DropColumn("dbo.Recipes", "EquipmentID");
            DropTable("dbo.EquipmentRecipes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EquipmentRecipes",
                c => new
                    {
                        Equipment_EquipmentID = c.Int(nullable: false),
                        Recipe_RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipment_EquipmentID, t.Recipe_RecipeID });
            
            AddColumn("dbo.Recipes", "EquipmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.EquipmentRecipes", "Recipe_RecipeID");
            CreateIndex("dbo.EquipmentRecipes", "Equipment_EquipmentID");
            AddForeignKey("dbo.EquipmentRecipes", "Recipe_RecipeID", "dbo.Recipes", "RecipeID", cascadeDelete: true);
            AddForeignKey("dbo.EquipmentRecipes", "Equipment_EquipmentID", "dbo.Equipments", "EquipmentID", cascadeDelete: true);
        }
    }
}
