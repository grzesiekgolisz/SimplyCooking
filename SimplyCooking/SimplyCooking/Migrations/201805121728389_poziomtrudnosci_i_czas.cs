namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poziomtrudnosci_i_czas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Time", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "DifficultyLevel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "DifficultyLevel");
            DropColumn("dbo.Recipes", "Time");
        }
    }
}
