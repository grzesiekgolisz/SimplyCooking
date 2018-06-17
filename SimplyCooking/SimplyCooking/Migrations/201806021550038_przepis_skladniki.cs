namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class przepis_skladniki : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Components", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Components");
        }
    }
}
