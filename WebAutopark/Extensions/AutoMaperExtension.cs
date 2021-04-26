using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.Models;

namespace WebAutopark.Extensions
{
    public static class AutoMaperExtension
    {
        public static void AddMapperForViewModels(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<PartDto, PartViewModel>().ReverseMap();
                cfg.CreateMap<VehicleDto, VehicleViewModel>().ReverseMap();
                cfg.CreateMap<VehicleDto, DetailVehicleViewModel>().ReverseMap();
                cfg.CreateMap<VehicleTypeDto, VehicleTypeViewModel>().ReverseMap();
                cfg.CreateMap<OrderDto, OrderDetailViewModel>().ReverseMap();
                cfg.CreateMap<PartDto, OrderedPartViewModel>().ReverseMap();
                cfg.CreateMap<DetaildOrderPartDto, OrderedPartViewModel>().ReverseMap();
                cfg.CreateMap<DetaildOrderDto, OrderDetailViewModel>().ReverseMap();
            });
        }
    }
}
