using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper.Execution;
using WebAutopark.DataAccess.Entities;
using WebAutopark.BusinessLogic.Dto;

namespace WebAutopark.BusinessLogic.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddMapperForDto(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Order, OrderDto>().ReverseMap();
                cfg.CreateMap<Part, PartDto>().ReverseMap();
                cfg.CreateMap<OrderPart, OrderPartDto>().ReverseMap();
                cfg.CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
                cfg.CreateMap<Vehicle, VehicleDto>().ReverseMap();
            });
        }
    }
}
