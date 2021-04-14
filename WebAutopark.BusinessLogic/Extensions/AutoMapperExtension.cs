using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper.Execution;
using WebAutopark.DataAccess.Entities;
using WebAutopark.BusinessLogic.DTO;

namespace WebAutopark.BusinessLogic.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>().ReverseMap();
                cfg.CreateMap<Part, PartDTO>().ReverseMap();
                cfg.CreateMap<OrderPart, OrderPartDTO>().ReverseMap();
                cfg.CreateMap<VehicleType, VehicleTypeDTO>().ReverseMap();
                cfg.CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            });
        }
    }
}
