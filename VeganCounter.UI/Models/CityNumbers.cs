using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeganCounter.BLL.Dtos;

namespace VeganCounter.UI.Models
{
    public class CityNumbers
    {
        public CityDto City { get; set; }

        public int NumberOfVegans { get; set; }
    }
}