namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_equipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentV2",
                c => new
                    {
                        EquipmentV2ID = c.Int(nullable: false, identity: true),
                        Equipmentname = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentV2ID);
            Sql("INSERT INTO [dbo].[EquipmentV2] (Equipmentname) VALUES ('Piekarnik')");
            AddColumn("dbo.Recipes", "EquipmentV2ID", c => c.Int(nullable: false));
            Sql("UPDATE [dbo].[Recipes] SET EquipmentV2ID = 1 WHERE EquipmentV2ID IS NULL or EquipmentV2ID = 0");
            CreateIndex("dbo.Recipes", "EquipmentV2ID");
            AddForeignKey("dbo.Recipes", "EquipmentV2ID", "dbo.EquipmentV2", "EquipmentV2ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "EquipmentV2ID", "dbo.EquipmentV2");
            DropIndex("dbo.Recipes", new[] { "EquipmentV2ID" });
            DropColumn("dbo.Recipes", "EquipmentV2ID");
            DropTable("dbo.EquipmentV2");
        }
    }
}
