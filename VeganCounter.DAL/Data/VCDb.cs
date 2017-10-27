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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasMany(x=>x.Vegan).WithOptional().HasForeignKey(b => b.CityID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Country>().HasMany(c => c.Vegan).WithOptional().HasForeignKey(b=>b.CountryID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Country>().HasMany(x => x.City).WithOptional().HasForeignKey(b => b.CountryID).WillCascadeOnDelete(false);

        }
    }

