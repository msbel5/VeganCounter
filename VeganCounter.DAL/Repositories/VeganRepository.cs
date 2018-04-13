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
    public class VeganRepository:Repository<Vegan>
    {
        public IEnumerable<Vegan> EagerGetAll()
        {
            VcDbContext eagerDbContext = new VcDbContext();
            return eagerDbContext.Vegans.Include(s => s.City).Include(s=>s.City.Country).ToList();
        }
    }
}
