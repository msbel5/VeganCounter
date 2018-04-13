using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using VeganCounter.BLL.Dtos;
using VeganCounter.BLL.Services;

namespace VeganCounter.UI.Controllers.Api
{
    public class VegansController : ApiController
    {
        private VeganManager _vm;

        public VegansController()
        {
            _vm = new VeganManager();
        }
        // GET /api/vegans
        public IHttpActionResult GetVegans()
        {
            var veganDtos = _vm.EagerGetAll();

            return Ok(veganDtos);
        }



        // GET /api/vegans/1

        public IHttpActionResult GetVegan(int id)
        {
            var veganDto = _vm.Get(id);
            if (veganDto == null)
                return NotFound();
            return Ok(veganDto);
        }

        // POST /api/vegans
        [HttpPost]
        public IHttpActionResult CreateVegan(VeganDto veganDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            if (_vm.Add(veganDto))
            {
                veganDto.Id = veganDto.Id;

                return Created(new Uri(Request.RequestUri + "/" + veganDto.Id), veganDto);
            }
            return BadRequest();

        }


        // PUT /api/vegans/1
        [HttpPut]
        public IHttpActionResult UpdateVegan(int id, VeganDto veganDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var veganInDb = _vm.Get(id);

            if (veganInDb == null)
                return NotFound();


            var updatedVeganDto = Mapper.Map(veganDto, veganInDb);

            if (_vm.Update(id, updatedVeganDto))
            {
                return Ok();
            }
            return NotFound();
        }

        //DELETE /api/vegans/1
        [HttpDelete]
        public IHttpActionResult DeleteVegan(int id)
        {
            var veganInDb = _vm.Get(id);

            if (veganInDb == null)
                return NotFound();

            if (_vm.Remove(id))
            {
                return Ok();
            }
            return NotFound();

        }
    }
}
