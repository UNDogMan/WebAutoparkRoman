using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Dto;
using WebAutopark.BusinessLogic.Services;
using WebAutopark.BusinessLogic.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace WebAutopark.BusinessLogic.Extensions
{
    public static class BusinessLogicExtension
    {
        public static void AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IBaseService<OrderDto>, OrderService>();
            services.AddScoped<IBaseService<PartDto>, PartService>();
            services.AddScoped<IBaseService<OrderPartDto>, OrderPartService>();
            services.AddScoped<IBaseService<VehicleTypeDto>, VehicleTypeServise>();
            services.AddScoped<IVehicleService, VehicleService>();
        }
    }
}
