using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using VeganCounter.BLL.Dtos;
using VeganCounter.BLL.Services;
using VeganCounter.UI.ViewModels;

namespace VeganCounter.UI.Controllers
{
    public class VegansController : Controller
    {
        private VeganManager _vm;

        public VegansController()
        {
            _vm = new VeganManager();
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
                _vm.Add(vegan);
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