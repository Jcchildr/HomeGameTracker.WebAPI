namespace HomeGameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StorageArea", "GameType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StorageArea", "GameType");
        }
    }
}
