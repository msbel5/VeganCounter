namespace VeganCounter.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCityAndCountryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vegans", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vegans", "CityId");
            AddForeignKey("dbo.Vegans", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            DropColumn("dbo.Vegans", "Country");
            DropColumn("dbo.Vegans", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vegans", "City", c => c.String(nullable: false));
            AddColumn("dbo.Vegans", "Country", c => c.String(nullable: false));
            DropForeignKey("dbo.Vegans", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Vegans", new[] { "CityId" });
            DropColumn("dbo.Vegans", "CityId");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
        }
    }
}
