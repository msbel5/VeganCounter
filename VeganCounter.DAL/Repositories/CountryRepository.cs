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
    public class CountryRepository:Repository<Country>
    {
        public Country Get(string name)
        {
            VcDbContext dbContext = new VcDbContext();
            return dbContext.Countries.FirstOrDefault(n => n.Name == name);
        }
    }
}
