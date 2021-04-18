using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Repository.Base;
using WebAutopark.DataAccess.Repository;
using WebAutopark.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace WebAutopark.DataAccess.Extensions
{
    public static class DataAccessExtension
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IConnectionProvider, ConnectionProvider>(provider => new ConnectionProvider(connectionString));
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IRepository<Part>, PartRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<OrderPart>, OrderPartRepository>();
        }
    }
}
