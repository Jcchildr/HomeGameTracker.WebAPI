namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInitialMigrationWithMinPlayers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Game", newName: "CardGame");
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
                        MinNumberOfPlayers = c.Int(nullable: false),
                        PublishYear = c.Int(nullable: false),
                        TeamGame = c.Boolean(nullable: false),
                        Genre = c.String(nullable: false),
                        StorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .Index(t => t.StorageId);
            
            AddColumn("dbo.CardGame", "MaxNumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.CardGame", "MinNumberOfPlayers", c => c.Int(nullable: false));
            AlterColumn("dbo.CardGame", "NumberOfCards", c => c.String(nullable: false));
            AlterColumn("dbo.CardGame", "ExtraEquipmentUsed", c => c.String(nullable: false));
            AlterColumn("dbo.CardGame", "IsGamblingGame", c => c.Boolean(nullable: false));
            AlterColumn("dbo.CardGame", "AvgPlayTimeInMin", c => c.Int(nullable: false));
            DropColumn("dbo.CardGame", "NumberOfPlayers");
            DropColumn("dbo.CardGame", "AveragePlayTimeMin");
            DropColumn("dbo.CardGame", "GameBoardType");
            DropColumn("dbo.CardGame", "ConsoleType");
            DropColumn("dbo.CardGame", "OnlineGamePlay");
            DropColumn("dbo.CardGame", "SurfaceType");
            DropColumn("dbo.CardGame", "BallGame");
            DropColumn("dbo.CardGame", "AreaOfPlayInFt");
            DropColumn("dbo.CardGame", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CardGame", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.CardGame", "AreaOfPlayInFt", c => c.Int());
            AddColumn("dbo.CardGame", "BallGame", c => c.Boolean());
            AddColumn("dbo.CardGame", "SurfaceType", c => c.String());
            AddColumn("dbo.CardGame", "OnlineGamePlay", c => c.Boolean());
            AddColumn("dbo.CardGame", "ConsoleType", c => c.String());
            AddColumn("dbo.CardGame", "GameBoardType", c => c.String());
            AddColumn("dbo.CardGame", "AveragePlayTimeMin", c => c.Int());
            AddColumn("dbo.CardGame", "NumberOfPlayers", c => c.Int(nullable: false));
            DropIndex("dbo.VideoGame", new[] { "StorageId" });
            AlterColumn("dbo.CardGame", "AvgPlayTimeInMin", c => c.Int());
            AlterColumn("dbo.CardGame", "IsGamblingGame", c => c.Boolean());
            AlterColumn("dbo.CardGame", "ExtraEquipmentUsed", c => c.String());
            AlterColumn("dbo.CardGame", "NumberOfCards", c => c.String());
            DropColumn("dbo.CardGame", "MinNumberOfPlayers");
            DropColumn("dbo.CardGame", "MaxNumberOfPlayers");
            DropTable("dbo.VideoGame");
            RenameTable(name: "dbo.CardGame", newName: "Game");
        }
    }
}
