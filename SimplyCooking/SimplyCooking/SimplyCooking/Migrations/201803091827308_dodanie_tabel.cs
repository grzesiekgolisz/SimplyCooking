namespace SimplyCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_tabel : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        TypeofdishesID = c.Int(nullable: false),
                        TypeofmealsID = c.Int(nullable: false),
                        Typeofdish_TypeofdishID = c.Int(),
                        Typeofmeal_TypeofmealID = c.Int(),
                    })
                .PrimaryKey(t => t.RecipeID)
                .ForeignKey("dbo.Typeofdishes", t => t.Typeofdish_TypeofdishID)
                .ForeignKey("dbo.Typeofmeals", t => t.Typeofmeal_TypeofmealID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.Typeofdish_TypeofdishID)
                .Index(t => t.Typeofmeal_TypeofmealID);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComponentID)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentID = c.Int(nullable: false, identity: true),
                        Equipmentname = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentID);
            
            CreateTable(
                "dbo.Typeofdishes",
                c => new
                    {
                        TypeofdishID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TypeofdishID);
            
            CreateTable(
                "dbo.Typeofmeals",
                c => new
                    {
                        TypeofmealID = c.Int(nullable: false, identity: true),
                        Mealstype = c.String(),
                    })
                .PrimaryKey(t => t.TypeofmealID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ProductComponents",
                c => new
                    {
                        Product_ProductID = c.Int(nullable: false),
                        Component_ComponentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductID, t.Component_ComponentID })
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Components", t => t.Component_ComponentID, cascadeDelete: true)
                .Index(t => t.Product_ProductID)
                .Index(t => t.Component_ComponentID);
            
            CreateTable(
                "dbo.EquipmentRecipes",
                c => new
                    {
                        Equipment_EquipmentID = c.Int(nullable: false),
                        Recipe_RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipment_EquipmentID, t.Recipe_RecipeID })
                .ForeignKey("dbo.Equipments", t => t.Equipment_EquipmentID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeID, cascadeDelete: true)
                .Index(t => t.Equipment_EquipmentID)
                .Index(t => t.Recipe_RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recipes", "Typeofmeal_TypeofmealID", "dbo.Typeofmeals");
            DropForeignKey("dbo.Recipes", "Typeofdish_TypeofdishID", "dbo.Typeofdishes");
            DropForeignKey("dbo.EquipmentRecipes", "Recipe_RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.EquipmentRecipes", "Equipment_EquipmentID", "dbo.Equipments");
            DropForeignKey("dbo.Components", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.ProductComponents", "Component_ComponentID", "dbo.Components");
            DropForeignKey("dbo.ProductComponents", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Comments", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.EquipmentRecipes", new[] { "Recipe_RecipeID" });
            DropIndex("dbo.EquipmentRecipes", new[] { "Equipment_EquipmentID" });
            DropIndex("dbo.ProductComponents", new[] { "Component_ComponentID" });
            DropIndex("dbo.ProductComponents", new[] { "Product_ProductID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Components", new[] { "RecipeID" });
            DropIndex("dbo.Recipes", new[] { "Typeofmeal_TypeofmealID" });
            DropIndex("dbo.Recipes", new[] { "Typeofdish_TypeofdishID" });
            DropIndex("dbo.Recipes", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "RecipeID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropTable("dbo.EquipmentRecipes");
            DropTable("dbo.ProductComponents");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Typeofmeals");
            DropTable("dbo.Typeofdishes");
            DropTable("dbo.Equipments");
            DropTable("dbo.Products");
            DropTable("dbo.Components");
            DropTable("dbo.Recipes");
            DropTable("dbo.Comments");
        }
    }
}
