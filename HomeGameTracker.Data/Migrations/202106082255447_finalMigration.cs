namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Game", newName: "BoardGame");
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
                .PrimaryKey(t => t.GameId)
                .Index(t => t.StorageId);
            
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
                .PrimaryKey(t => t.GameId)
                .Index(t => t.StorageId);
            
            AddColumn("dbo.BoardGame", "MaxNumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.BoardGame", "MinNumberOfPlayers", c => c.Int(nullable: false));
            AlterColumn("dbo.BoardGame", "AveragePlayTimeMin", c => c.Int(nullable: false));
            AlterColumn("dbo.BoardGame", "GameBoardType", c => c.String(nullable: false));
            DropColumn("dbo.BoardGame", "NumberOfPlayers");
            DropColumn("dbo.BoardGame", "NumberOfCards");
            DropColumn("dbo.BoardGame", "ExtraEquipmentUsed");
            DropColumn("dbo.BoardGame", "IsGamblingGame");
            DropColumn("dbo.BoardGame", "AvgPlayTimeInMin");
            DropColumn("dbo.BoardGame", "ConsoleType");
            DropColumn("dbo.BoardGame", "OnlineGamePlay");
            DropColumn("dbo.BoardGame", "SurfaceType");
            DropColumn("dbo.BoardGame", "BallGame");
            DropColumn("dbo.BoardGame", "AreaOfPlayInFt");
            DropColumn("dbo.BoardGame", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BoardGame", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.BoardGame", "AreaOfPlayInFt", c => c.Int());
            AddColumn("dbo.BoardGame", "BallGame", c => c.Boolean());
            AddColumn("dbo.BoardGame", "SurfaceType", c => c.String());
            AddColumn("dbo.BoardGame", "OnlineGamePlay", c => c.Boolean());
            AddColumn("dbo.BoardGame", "ConsoleType", c => c.String());
            AddColumn("dbo.BoardGame", "AvgPlayTimeInMin", c => c.Int());
            AddColumn("dbo.BoardGame", "IsGamblingGame", c => c.Boolean());
            AddColumn("dbo.BoardGame", "ExtraEquipmentUsed", c => c.String());
            AddColumn("dbo.BoardGame", "NumberOfCards", c => c.String());
            AddColumn("dbo.BoardGame", "NumberOfPlayers", c => c.Int(nullable: false));
            DropIndex("dbo.YardGame", new[] { "StorageId" });
            DropIndex("dbo.CardGame", new[] { "StorageId" });
            DropIndex("dbo.VideoGame", new[] { "StorageId" });
            AlterColumn("dbo.BoardGame", "GameBoardType", c => c.String());
            AlterColumn("dbo.BoardGame", "AveragePlayTimeMin", c => c.Int());
            DropColumn("dbo.BoardGame", "MinNumberOfPlayers");
            DropColumn("dbo.BoardGame", "MaxNumberOfPlayers");
            DropTable("dbo.YardGame");
            DropTable("dbo.CardGame");
            DropTable("dbo.VideoGame");
            RenameTable(name: "dbo.BoardGame", newName: "Game");
        }
    }
}
