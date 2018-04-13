using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VeganCounter.BLL.Dtos;

namespace VeganCounter.UI.Models
{
    public class CountryNumbers
    {
        public CountryDto Country { get; set; }

        public int NumberOfVegans { get; set; }
    }
}