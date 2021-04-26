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
        private readonly IMapper mapper;

        public OrderController(IOrderService orderService,
            IVehicleService vehicleService,
            IBaseService<PartDto> partService,
            IBaseService<OrderPartDto> orderPartService,
            IMapper mapper)
        {
            this.orderService = orderService;
            this.vehicleService = vehicleService;
            this.partService = partService;
            this.orderPartService = orderPartService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = mapper.Map<IEnumerable<OrderDetailViewModel>>(await orderService.GetAllWithIncludes());
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await orderService.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = mapper.Map<OrderDetailViewModel>(await orderService.GetWithIncludes(id));
            return View(order);
        }

        public async Task<ActionResult> Create()
        {
            var vehicles = await vehicleService.GetAll();
            ViewData["VehicleSelectListItems"] = vehicles.Select(x => new SelectListItem(x.ModelName, x.ID.ToString())).ToList();
            var parts = await partService.GetAll();
            ViewData["PartsListItems"] = parts.Select(x => new SelectListItem(x.PartName, x.ID.ToString())).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind("VehicleID")]
            CreationOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var partsCount = int.Parse(HttpContext.Request.Form["PartsCount"]);
                var parts = Enumerable.Range(1, partsCount)
                    .Where(x => HttpContext.Request.Form["PartID" + x.ToString()].Count > 0)
                    .Select(x => new OrderPartDto
                    {
                        OrderID = 0,
                        PartID = int.Parse(HttpContext.Request.Form["PartID" + x.ToString()]),
                        PartCount = int.Parse(HttpContext.Request.Form["PartCount" + x.ToString()])
                    });
                await orderService.CreateForParts(model.VehicleID, parts);
            }
            else
            {
                return RedirectToAction("Create");
            }
            return RedirectToAction("Index");
        }
    }
}
