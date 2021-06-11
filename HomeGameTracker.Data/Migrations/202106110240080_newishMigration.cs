namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newishMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BoardGame", newName: "Game");
            DropIndex("dbo.VideoGame", new[] { "StorageId" });
            DropIndex("dbo.CardGame", new[] { "StorageId" });
            DropIndex("dbo.YardGame", new[] { "StorageId" });
            AddColumn("dbo.Game", "NumberOfCards", c => c.String());
            AddColumn("dbo.Game", "ExtraEquipmentUsed", c => c.String());
            AddColumn("dbo.Game", "IsGamblingGame", c => c.Boolean());
            AddColumn("dbo.Game", "AvgPlayTimeInMin", c => c.Int());
            AddColumn("dbo.Game", "ConsoleType", c => c.String());
            AddColumn("dbo.Game", "OnlineGamePlay", c => c.Boolean());
            AddColumn("dbo.Game", "SurfaceType", c => c.String());
            AddColumn("dbo.Game", "BallGame", c => c.Boolean());
            AddColumn("dbo.Game", "AreaOfPlayInFt", c => c.Int());
            AddColumn("dbo.Game", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Game", "AveragePlayTimeMin", c => c.Int());
            AlterColumn("dbo.Game", "GameBoardType", c => c.String());
            DropTable("dbo.VideoGame");
            DropTable("dbo.CardGame");
            DropTable("dbo.YardGame");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.YardGame",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        SurfaceType = c.String(nullable: false),
                        BallGame = c.Boolean(nullable: false),
                        AreaOfPlayInFt = c.Int(nullable: false),
                        GameName = c.String(nullable: false),
                        AgeRating = c.Int(nullable: false),
                        MaxNumberOfPlayers = c.Int(nullable: false),
                        MinNumberOfPlayers = c.Int(nullable: false),
                        PublishYear = c.Int(nullable: false),
                        TeamGame = c.Boolean(nullable: false),
                        Genre = c.String(nullable: false),
                        StorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
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
                        MinNumberOfPlayers = c.Int(nullable: false),
                        PublishYear = c.Int(nullable: false),
                        TeamGame = c.Boolean(nullable: false),
                        Genre = c.String(nullable: false),
                        StorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
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
                .PrimaryKey(t => t.GameId);
            
            AlterColumn("dbo.Game", "GameBoardType", c => c.String(nullable: false));
            AlterColumn("dbo.Game", "AveragePlayTimeMin", c => c.Int(nullable: false));
            DropColumn("dbo.Game", "Discriminator");
            DropColumn("dbo.Game", "AreaOfPlayInFt");
            DropColumn("dbo.Game", "BallGame");
            DropColumn("dbo.Game", "SurfaceType");
            DropColumn("dbo.Game", "OnlineGamePlay");
            DropColumn("dbo.Game", "ConsoleType");
            DropColumn("dbo.Game", "AvgPlayTimeInMin");
            DropColumn("dbo.Game", "IsGamblingGame");
            DropColumn("dbo.Game", "ExtraEquipmentUsed");
            DropColumn("dbo.Game", "NumberOfCards");
            CreateIndex("dbo.YardGame", "StorageId");
            CreateIndex("dbo.CardGame", "StorageId");
            CreateIndex("dbo.VideoGame", "StorageId");
            RenameTable(name: "dbo.Game", newName: "BoardGame");
        }
    }
}
