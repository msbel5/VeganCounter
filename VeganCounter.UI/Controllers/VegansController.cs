using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using AutoMapper;
using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Model;
using MaxMind.GeoIP2.Responses;
using VeganCounter.BLL.Dtos;
using VeganCounter.BLL.Services;
using VeganCounter.UI.ViewModels;

namespace VeganCounter.UI.Controllers
{
    public class VegansController : Controller
    {
        private VeganManager _vm;
        private CityManager _cim;
        private CountryManager _com;


        public VegansController()
        {
            _vm = new VeganManager();
            _cim = new CityManager();
            _com = new CountryManager();
        }

        // GET: Vegans
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var vegan = _vm.Get(id);
            if (vegan == null)
                return HttpNotFound();
            return View(vegan);
        }

        public ActionResult New()
        {
            var viewModel = new VeganFormViewModel
            {
                Vegan = new VeganDto()
            };
            return View("VeganForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VeganDto vegan)
        {
            using (var reader = new DatabaseReader(AppDomain.CurrentDomain.BaseDirectory + "/App_Data/GeoLite2-City.mmdb"))
            {
                var ipAddress = HttpContext.Request.UserHostAddress;
                CityResponse location = reader.City(ipAddress);
                
                if (_cim.Get(location.City.ToString()) != null)
                {
                    vegan.CityId = _cim.Get(location.City.ToString()).Id;
                }
                else
                {
                    CityDto newCity = new CityDto()
                    {
                        Name = location.City.ToString()
                    };

                    if (_com.Get(location.Country.ToString()) != null)
                    {

                        newCity.CountryId = _com.Get(location.Country.ToString()).Id;
                    }
                    else
                    {
                        CountryDto newCountry = new CountryDto
                        {
                            Name = location.Country.ToString()
                        };
                        _com.Add(newCountry);
                        newCity.CountryId = _com.Get(newCountry.Name).Id;
                    }


                    _cim.Add(newCity);
                    vegan.CityId = _cim.Get(newCity.Name).Id;
                }
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new VeganFormViewModel()
                {
                    Vegan = vegan
                };
                return View("VeganForm", viewModel);
            }


            if (vegan.Id == 0)
            {
                if (!_vm.Find(v => v.Email == vegan.Email).Any())
                {
                    _vm.Add(vegan);
                }
                else
                {
                    var viewModel = new VeganFormViewModel()
                    {
                        Vegan = vegan
                    };
                    ModelState.AddModelError("", "Email already exist.");
                    return View("VeganForm", viewModel);
                }
            }
            else
            {
                int veganId = Convert.ToInt32(vegan.Id);
                var veganInDb = _vm.Get(veganId);
                var updateVeganDto = Mapper.Map(vegan, veganInDb);
                _vm.Update(veganId, updateVeganDto);
            }
            return RedirectToAction("Index", "Vegans");
        }

        public ActionResult Edit(int id)
        {
            var vegan = _vm.Get(id);
            if (vegan == null)
                return HttpNotFound();

            var viewModel = new VeganFormViewModel()
            {
                Vegan = vegan
            };
            return View("VeganForm", viewModel);
        }

    }
}