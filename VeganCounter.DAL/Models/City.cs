using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganCounter.DAL.Models
{
    public class City
    {
        public City()
        {
            this.Vegan = new HashSet<Vegan>();
        }
        public int ID { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Vegan> Vegan { get; set; }
    }
}
