using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VeganCounter.BLL.Dtos;
using VeganCounter.BLL.Services;
using VeganCounter.UI.Models;

namespace VeganCounter.UI.Controllers.Api
{
    public class CountriesController : ApiController
    {
        private CountryManager _cm;
        private VeganManager _vm;

        public CountriesController()
        {
            _cm = new CountryManager();
            _vm = new VeganManager();
        }
        // GET /api/Countrys
        public IHttpActionResult GetCountries()
        {


            List<CountryNumbers> countryNumbers = new List<CountryNumbers>();
            var countryDtos = _cm.GetAll();
            foreach (CountryDto country in countryDtos)
            {
                IEnumerable<VeganDto> vegans = _vm.Find(v => v.City.CountryId == country.Id);
                CountryNumbers countryNumber = new CountryNumbers
                {
                    Country = country,
                    NumberOfVegans = vegans.Count()
                };
                countryNumbers.Add(countryNumber);
            }

            return Ok(countryNumbers);
        }


        // GET /api/Countrys/1

        public IHttpActionResult GetCountry(int id)
        {
            var countryDto = _cm.Get(id);
            if (countryDto == null)
                return NotFound();
            return Ok(countryDto);
        }

        // POST /api/Countrys
        [HttpPost]
        public IHttpActionResult CreateCountry(CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_cm.Add(countryDto))
            {
                countryDto.Id = countryDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + countryDto.Id), countryDto);
            }
            return BadRequest();

        }


        // PUT /api/Countrys/1
        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, CountryDto countryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var countryInDb = _cm.Get(id);

            if (countryInDb == null)
                return NotFound();


            var updatedCountryDto = Mapper.Map(countryDto, countryInDb);

            if (_cm.Update(id, updatedCountryDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Countrys/1
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var countryInDb = _cm.Get(id);

            if (countryInDb == null)
                return NotFound();

            if (_cm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
