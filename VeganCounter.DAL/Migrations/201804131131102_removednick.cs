namespace VeganCounter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednick : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vegans", "Nick");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vegans", "Nick", c => c.String(nullable: false));
        }
    }
}
