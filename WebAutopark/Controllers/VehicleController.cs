using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Models;
using WebAutopark.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IBaseService<VehicleTypeDto> vehicleTypeService;
        private readonly IOrderService orderService;

        public VehicleController(IVehicleService vehicleService, IBaseService<VehicleTypeDto> vehicleTypeService, IOrderService orderService)
        {
            this.vehicleService = vehicleService;
            this.vehicleTypeService = vehicleTypeService;
            this.orderService = orderService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg.CreateMap<VehicleDto, VehicleViewModel>().ReverseMap()));
            var vehicles = mapper.Map<IEnumerable<VehicleViewModel>>(await vehicleService.GetAll());
            foreach(var vehicle in vehicles)
            {
                vehicle.VehicleTypeName = vehicleTypeService.Get(vehicle.VehicleTypeID).Result.TypeName;
            }
            return View(vehicles);
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg.CreateMap<VehicleDto, DetailVehicleViewModel>().ReverseMap()));
            var vehicleDTO = await vehicleService.Get(id);
            var vehicle = mapper.Map<DetailVehicleViewModel>(vehicleDTO);
            vehicle.VehicleTypeName = vehicleTypeService.Get(vehicle.VehicleTypeID).Result.TypeName;
            vehicle.TaxPerMounth = await vehicleService.GetTaxPerMount(vehicleDTO);
            vehicle.MaxMileage = await vehicleService.GetMaxMileage(vehicleDTO);
            vehicle.OrdersID = (await orderService.GetAll()).Where(x => x.VehicleID == id).Select(x => x.ID);
            return View(vehicle);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await vehicleService.Delete(id);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> CreateAsync()
        {
            var types = await vehicleTypeService.GetAll();
            ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(
            [Bind(include: "VehicleTypeID,ModelName,RegistrationNumber,Weight,ManufactureYear,Maileage,Color,TankCapacity,Consumption")] 
            VehicleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new Mapper(
                       new MapperConfiguration(
                           cfg => cfg.CreateMap<VehicleDto, VehicleViewModel>().ReverseMap()));
                    var type = mapper.Map<VehicleDto>(model);
                    await vehicleService.Create(type);
                }
                else
                {
                    var types = await vehicleTypeService.GetAll();
                    ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();

                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var types = await vehicleTypeService.GetAll();
                ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();
                return View(model);
            }
        }
        
        public async Task<ActionResult> EditAsync(int id)
        {
            var types = await vehicleTypeService.GetAll();
            ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();
            var mapper = new Mapper(
                       new MapperConfiguration(
                           cfg => cfg.CreateMap<VehicleDto, VehicleViewModel>().ReverseMap()));
            var model = mapper.Map<VehicleViewModel>(await vehicleService.Get(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(
            [Bind(include: "ID,VehicleTypeID,ModelName,RegistrationNumber,Weight,ManufactureYear,Maileage,Color,TankCapacity,Consumption")]
            VehicleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new Mapper(
                       new MapperConfiguration(
                           cfg => cfg.CreateMap<VehicleDto, VehicleViewModel>().ReverseMap()));
                    var type = mapper.Map<VehicleDto>(model);
                    await vehicleService.Update(type);
                }
                else
                {
                    var types = await vehicleTypeService.GetAll();
                    ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();

                    return View(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                var types = await vehicleTypeService.GetAll();
                ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();
                return View(model);
            }
        }
    }
}
