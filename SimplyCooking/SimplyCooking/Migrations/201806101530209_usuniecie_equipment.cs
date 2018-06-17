namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuniecie_equipment : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Equipments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        Equipmentname = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentID);
            
        }
    }
}
