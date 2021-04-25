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

namespace WebAutopark.Models
{
    public class PartController : Controller
    {
        private readonly IBaseService<PartDto> partService;
        private readonly IMapper mapper;

        public PartController(IBaseService<PartDto> partService, IMapper mapper)
        {
            this.partService = partService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var parts = mapper.Map<IEnumerable<PartViewModel>>(await partService.GetAll());
            return View(parts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await partService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(include: "PartName")]
            PartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var part = mapper.Map<PartDto>(model);
                await partService.Create(part);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(include: "ID,PartName")]
            PartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var part = mapper.Map<PartDto>(model);
                await partService.Update(part);
            }
            return RedirectToAction("Index");
        }
    }
}
