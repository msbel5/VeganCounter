using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VeganCounter.BLL.Dtos;
using VeganCounter.DAL.Models;

namespace VeganCounter.BLL.Configurations
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Vegan, VeganDto>();
            CreateMap<VeganDto, Vegan>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
