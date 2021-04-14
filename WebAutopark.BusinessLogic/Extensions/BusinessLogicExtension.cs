using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.DTO;
using WebAutopark.BusinessLogic.Services;
using WebAutopark.BusinessLogic.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace WebAutopark.BusinessLogic.Extensions
{
    public static class BusinessLogicExtension
    {
        public static void AddBusinessLogin(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<OrderDTO>, OrderService>();
            services.AddScoped<IBaseService<PartDTO>, PartService>();
            services.AddScoped<IBaseService<OrderPartDTO>, OrderPartService>();
            services.AddScoped<IBaseService<VehicleTypeDTO>, VehicleTypeServise>();
            services.AddScoped<IVehicleService, VehicleService>();
        }
    }
}
