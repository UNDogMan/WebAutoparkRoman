using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Models;


namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IBaseService<VehicleTypeDto> vehicleTypeService;
        private readonly IMapper mapper;

        public VehicleTypeController(IBaseService<VehicleTypeDto> vehicleTypeService, IMapper mapper)
        {
            this.vehicleTypeService = vehicleTypeService;
            this.mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var types = mapper.Map<IEnumerable<VehicleTypeViewModel>>(await vehicleTypeService.GetAll());
            return View(types);
        }

        public async Task<ActionResult> Details(int id)
        {
            var type = mapper.Map<VehicleTypeViewModel>(await vehicleTypeService.Get(id));
            return View(type);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(include: "TypeName,TaxCoefficient")]VehicleTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var type = mapper.Map<VehicleTypeDto>(model);
                await vehicleTypeService.Create(type);
            }
            else
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var type = mapper.Map<VehicleTypeViewModel>(await vehicleTypeService.Get(id));
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(include: "ID,TypeName,TaxCoefficient")] VehicleTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var type = mapper.Map<VehicleTypeDto>(model);
                await vehicleTypeService.Update(type);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            await vehicleTypeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
