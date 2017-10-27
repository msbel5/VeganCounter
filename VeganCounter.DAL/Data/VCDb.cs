namespace VeganCounter.DAL.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using VeganCounter.DAL.Models;

    public class VCDbContext : DbContext
    {
        // Your context has been configured to use a 'VCDb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'VeganCounter.DAL.Data.VCDb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'VCDb' 
        // connection string in the application configuration file.
        public VCDbContext()
            : base("name=VCDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<VCDbContext>());
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Vegan> Vegans { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
    

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
