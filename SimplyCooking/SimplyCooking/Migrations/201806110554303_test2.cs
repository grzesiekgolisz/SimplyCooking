namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "EquipmentV2ID", "dbo.EquipmentV2");
            DropIndex("dbo.Recipes", new[] { "EquipmentV2ID" });
            AlterColumn("dbo.Recipes", "EquipmentV2ID", c => c.Int());
            CreateIndex("dbo.Recipes", "EquipmentV2ID");
            AddForeignKey("dbo.Recipes", "EquipmentV2ID", "dbo.EquipmentV2", "EquipmentV2ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "EquipmentV2ID", "dbo.EquipmentV2");
            DropIndex("dbo.Recipes", new[] { "EquipmentV2ID" });
            AlterColumn("dbo.Recipes", "EquipmentV2ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "EquipmentV2ID");
            AddForeignKey("dbo.Recipes", "EquipmentV2ID", "dbo.EquipmentV2", "EquipmentV2ID", cascadeDelete: true);
        }
    }
}
