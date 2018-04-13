using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeganCounter.DAL.Data;
using VeganCounter.DAL.Models;

namespace VeganCounter.DAL.Repositories
{
    public class CityRepository:Repository<City>
    {
        public City Get(string name)
        {
            VcDbContext dbContext = new VcDbContext();
            return dbContext.Cities.FirstOrDefault(n => n.Name == name);
        }

        public IEnumerable<City> EagerGetAll()
        {
            VcDbContext eagerDbContext = new VcDbContext();
            return eagerDbContext.Cities.Include(s => s.Country).ToList();
        }
    }
}
