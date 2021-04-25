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
        private readonly IMapper mapper;

        public VehicleController(IVehicleService vehicleService, IBaseService<VehicleTypeDto> vehicleTypeService, IOrderService orderService, IMapper mapper)
        {
            this.vehicleService = vehicleService;
            this.vehicleTypeService = vehicleTypeService;
            this.orderService = orderService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = mapper.Map<IEnumerable<VehicleViewModel>>(await vehicleService.GetAll());
            foreach(var vehicle in vehicles)
            {
                vehicle.VehicleTypeName = (await vehicleTypeService.Get(vehicle.VehicleTypeID)).TypeName;
            }
            return View(vehicles);
        }

        public async Task<IActionResult> Details(int id)
        {
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
        public async Task<IActionResult> Delete(int id)
        {
            await vehicleService.Delete(id);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Create()
        {
            var types = await vehicleTypeService.GetAll();
            ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(include: "VehicleTypeID,ModelName,RegistrationNumber,Weight,ManufactureYear,Maileage,Color,TankCapacity,Consumption")] 
            VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
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
        
        public async Task<ActionResult> Edit(int id)
        {
            var types = await vehicleTypeService.GetAll();
            ViewData["TypesSelectListItems"] = types.Select(x => new SelectListItem(x.TypeName, x.ID.ToString())).ToList();
            var model = mapper.Map<VehicleViewModel>(await vehicleService.Get(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(include: "ID,VehicleTypeID,ModelName,RegistrationNumber,Weight,ManufactureYear,Maileage,Color,TankCapacity,Consumption")]
            VehicleViewModel model)
        {
            if (ModelState.IsValid)
            {
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
    }
}
