namespace VeganCounter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Vegans", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Vegans", "CountryID", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropIndex("dbo.Vegans", new[] { "CountryID" });
            DropIndex("dbo.Vegans", new[] { "CityID" });
            AddColumn("dbo.Vegans", "Country", c => c.String(nullable: false));
            AddColumn("dbo.Vegans", "City", c => c.String(nullable: false));
            DropColumn("dbo.Vegans", "CountryID");
            DropColumn("dbo.Vegans", "CityID");
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Vegans", "CityID", c => c.Int(nullable: false));
            AddColumn("dbo.Vegans", "CountryID", c => c.Int(nullable: false));
            DropColumn("dbo.Vegans", "City");
            DropColumn("dbo.Vegans", "Country");
            CreateIndex("dbo.Vegans", "CityID");
            CreateIndex("dbo.Vegans", "CountryID");
            CreateIndex("dbo.Cities", "CountryID");
            AddForeignKey("dbo.Vegans", "CountryID", "dbo.Countries", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Vegans", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Cities", "CountryID", "dbo.Countries", "ID");
        }
    }
}
