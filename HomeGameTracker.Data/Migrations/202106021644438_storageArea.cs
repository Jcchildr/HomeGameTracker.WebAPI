namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storageArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "NumberOfPlayers", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "PublishYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Game", "Genre", c => c.String(nullable: false));
            DropColumn("dbo.Game", "Format");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Format", c => c.String());
            AlterColumn("dbo.Game", "Genre", c => c.String());
            DropColumn("dbo.Game", "PublishYear");
            DropColumn("dbo.Game", "NumberOfPlayers");
        }
    }
}
