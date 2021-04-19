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

        public VehicleTypeController(IBaseService<VehicleTypeDto> vehicleTypeService)
        {
            this.vehicleTypeService = vehicleTypeService;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg.CreateMap<VehicleTypeDto, VehicleTypeViewModel>().ReverseMap()));
            var types = mapper.Map<IEnumerable<VehicleTypeViewModel>>(await vehicleTypeService.GetAll());
            return View(types);
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {
            var mapper = new Mapper(
                   new MapperConfiguration(
                       cfg => cfg.CreateMap<VehicleTypeDto, VehicleTypeViewModel>().ReverseMap()));
            var type = mapper.Map<VehicleTypeViewModel>(await vehicleTypeService.Get(id));
            return View(type);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(include: "TypeName,TaxCoefficient")]VehicleTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new Mapper(
                       new MapperConfiguration(
                           cfg => cfg.CreateMap<VehicleTypeDto, VehicleTypeViewModel>().ReverseMap()));
                    var type = mapper.Map<VehicleTypeDto>(model);
                    await vehicleTypeService.Create(type);
                }
                else
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> EditAsync(int id)
        {
            var mapper = new Mapper(
                   new MapperConfiguration(
                       cfg => cfg.CreateMap<VehicleTypeDto, VehicleTypeViewModel>().ReverseMap()));
            var type = mapper.Map<VehicleTypeViewModel>(await vehicleTypeService.Get(id));
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(include: "ID,TypeName,TaxCoefficient")] VehicleTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new Mapper(
                          new MapperConfiguration(
                              cfg => cfg.CreateMap<VehicleTypeDto, VehicleTypeViewModel>().ReverseMap()));
                    var type = mapper.Map<VehicleTypeDto>(model);
                    await vehicleTypeService.Update(type);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await vehicleTypeService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
