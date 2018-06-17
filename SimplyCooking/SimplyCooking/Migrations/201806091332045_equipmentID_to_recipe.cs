namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class equipmentID_to_recipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "EquipmentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "EquipmentID");
        }
    }
}
