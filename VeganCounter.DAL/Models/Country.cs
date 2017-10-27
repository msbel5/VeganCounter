using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganCounter.DAL.Models
{
    public class Country
    {
        public Country()
        {
            this.City = new HashSet<City>();
            this.Vegan = new HashSet<Vegan>();
        }
        public int ID { get; set; }
        [Required]
        public int Name { get; set; }
        public virtual ICollection<City> City { get; set; }
        public virtual ICollection<Vegan> Vegan { get; set; }

    }
}
