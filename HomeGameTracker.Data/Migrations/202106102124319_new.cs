namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "MaxNumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "MinNumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "AveragePlayTimeMin", c => c.Int());
            AddColumn("dbo.Game", "GameBoardType", c => c.String());
            AddColumn("dbo.Game", "SurfaceType", c => c.String());
            AddColumn("dbo.Game", "BallGame", c => c.Boolean());
            AddColumn("dbo.Game", "AreaOfPlayInFt", c => c.Int());
            AddColumn("dbo.StorageArea", "GameType", c => c.String(nullable: false));
            DropColumn("dbo.Game", "NumberOfPlayers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "NumberOfPlayers", c => c.Int(nullable: false));
            DropColumn("dbo.StorageArea", "GameType");
            DropColumn("dbo.Game", "AreaOfPlayInFt");
            DropColumn("dbo.Game", "BallGame");
            DropColumn("dbo.Game", "SurfaceType");
            DropColumn("dbo.Game", "GameBoardType");
            DropColumn("dbo.Game", "AveragePlayTimeMin");
            DropColumn("dbo.Game", "MinNumberOfPlayers");
            DropColumn("dbo.Game", "MaxNumberOfPlayers");
        }
    }
}
