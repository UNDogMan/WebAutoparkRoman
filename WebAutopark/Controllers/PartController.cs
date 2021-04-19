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

        public PartController(IBaseService<PartDto> partService)
        {
            this.partService = partService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg.CreateMap<PartDto, PartViewModel>().ReverseMap()));
            var parts = mapper.Map<IEnumerable<PartViewModel>>(await partService.GetAll());
            return View(parts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await partService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(
            [Bind(include: "PartName")]
            PartViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new Mapper(
                       new MapperConfiguration(
                           cfg => cfg.CreateMap<PartViewModel, PartDto>().ReverseMap()));
                    var part = mapper.Map<PartDto>(model);
                    await partService.Create(part);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(
            [Bind(include: "ID,PartName")]
            PartViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new Mapper(
                       new MapperConfiguration(
                           cfg => cfg.CreateMap<PartViewModel, PartDto>().ReverseMap()));
                    var part = mapper.Map<PartDto>(model);
                    await partService.Update(part);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
