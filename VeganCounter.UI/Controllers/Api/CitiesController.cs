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
    public class CitiesController : ApiController
    {
        private CityManager _cm;
        private VeganManager _vm;

        public CitiesController()
        {
            _cm = new CityManager();
            _vm = new VeganManager();
        }
        // GET /api/Citys
        public IHttpActionResult GetCities()
        {
            List<CityNumbers> cityNumbers = new List<CityNumbers>();
            var cityDtos = _cm.EagerGetAll();
            foreach (CityDto city in cityDtos)
            {
                IEnumerable<VeganDto> vegans = _vm.Find(v => v.CityId == city.Id);
                CityNumbers cityNumber = new CityNumbers
                {
                    City = city,
                    NumberOfVegans = vegans.Count()
                };
                cityNumbers.Add(cityNumber);
            }

            return Ok(cityNumbers);
        }



        // GET /api/Citys/1

        public IHttpActionResult GetCity(int id)
        {
            var cityDto = _cm.Get(id);
            if (cityDto == null)
                return NotFound();
            return Ok(cityDto);
        }

        // POST /api/Citys
        [HttpPost]
        public IHttpActionResult CreateCity(CityDto cityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (_cm.Add(cityDto))
            {
                cityDto.Id = cityDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + cityDto.Id), cityDto);
            }
            return BadRequest();

        }


        // PUT /api/Citys/1
        [HttpPut]
        public IHttpActionResult UpdateCity(int id, CityDto cityDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cityInDb = _cm.Get(id);

            if (cityInDb == null)
                return NotFound();


            var updatedCityDto = Mapper.Map(cityDto, cityInDb);

            if (_cm.Update(id, updatedCityDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/Citys/1
        [HttpDelete]
        public IHttpActionResult DeleteCity(int id)
        {
            var cityInDb = _cm.Get(id);

            if (cityInDb == null)
                return NotFound();

            if (_cm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
