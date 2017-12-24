namespace VeganCounter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NickAddedToVegan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vegans", "Nick", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vegans", "Nick");
        }
    }
}
