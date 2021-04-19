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
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IVehicleService vehicleService;
        private readonly IBaseService<PartDto> partService;
        private readonly IBaseService<OrderPartDto> orderPartService;

        public OrderController(IOrderService orderService, IVehicleService vehicleService, IBaseService<PartDto> partService, IBaseService<OrderPartDto> orderPartService)
        {
            this.orderService = orderService;
            this.vehicleService = vehicleService;
            this.partService = partService;
            this.orderPartService = orderPartService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var orders = (await orderService.GetAll())
                .Select(x => new OrderViewModel { 
                    ID = x.ID,
                    VehicleModel = vehicleService.Get(x.VehicleID).Result.ModelName}).ToList();
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await orderService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DetailsAsync(int id)
        {
            var order = new OrderDetailViewModel
            {
                ID = id,
                VehicleModel = vehicleService.Get(
                    orderService.Get(id).Result.VehicleID).Result.ModelName 
            };
            order.Parts = (await orderPartService.GetAll()).Where(x => x.OrderID == id).Join(
                await partService.GetAll(),
                x => x.PartID,
                y => y.ID,
                (x, y) => new OrderedPartViewModel { 
                    PartID = y.ID,
                    PartName = y.PartName,
                    PartCount = x.PartCount
                });
            return View(order);
        }
        public async Task<ActionResult> CreateAsync()
        {
            var vehicles = await vehicleService.GetAll();
            ViewData["VehicleSelectListItems"] = vehicles.Select(x => new SelectListItem(x.ModelName, x.ID.ToString())).ToList();
            var parts = await partService.GetAll();
            ViewData["PartsListItems"] = parts.Select(x => new SelectListItem(x.PartName, x.ID.ToString())).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(
            [Bind("VehicleID")]
            CreationOrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int orderID = await orderService.CreateWithID(new OrderDto { VehicleID = model.VehicleID });
                    var partsCount = int.Parse(HttpContext.Request.Form["PartsCount"]);
                    foreach(var x in Enumerable.Range(1, partsCount)){
                        if (HttpContext.Request.Form["PartID" + x.ToString()].Count > 0)
                        {
                            int partId = int.Parse(HttpContext.Request.Form["PartID" + x.ToString()]);
                            int partCount = int.Parse(HttpContext.Request.Form["PartCount" + x.ToString()]);
                            orderPartService.Create(new OrderPartDto
                            {
                                OrderID = orderID,
                                PartID = partId,
                                PartCount = partCount
                            }).Wait();
                        }
                    };
                }
                else
                {
                    return RedirectToAction("Create");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }
    }
}
