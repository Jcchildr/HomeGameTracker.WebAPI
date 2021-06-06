namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardGame",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        NumberOfCards = c.String(nullable: false),
                        ExtraEquipmentUsed = c.String(nullable: false),
                        IsGamblingGame = c.Boolean(nullable: false),
                        AvgPlayTimeInMin = c.Int(nullable: false),
                        GameName = c.String(nullable: false),
                        AgeRating = c.Int(nullable: false),
                        MaxNumberOfPlayers = c.Int(nullable: false),
                        PublishYear = c.Int(nullable: false),
                        TeamGame = c.Boolean(nullable: false),
                        Genre = c.String(nullable: false),
                        StorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.StorageArea", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.StorageArea",
                c => new
                    {
                        StorageAreaId = c.Int(nullable: false, identity: true),
                        NameOfStorageArea = c.String(nullable: false),
                        GameType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StorageAreaId);
            
            CreateTable(
                "dbo.VideoGame",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        ConsoleType = c.String(nullable: false),
                        OnlineGamePlay = c.Boolean(nullable: false),
                        GameName = c.String(nullable: false),
                        AgeRating = c.Int(nullable: false),
                        MaxNumberOfPlayers = c.Int(nullable: false),
                        PublishYear = c.Int(nullable: false),
                        TeamGame = c.Boolean(nullable: false),
                        Genre = c.String(nullable: false),
                        StorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.StorageArea", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CardGame", "StorageId", "dbo.StorageArea");
            DropForeignKey("dbo.VideoGame", "StorageId", "dbo.StorageArea");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.VideoGame", new[] { "StorageId" });
            DropIndex("dbo.CardGame", new[] { "StorageId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.VideoGame");
            DropTable("dbo.StorageArea");
            DropTable("dbo.CardGame");
        }
    }
}
