using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities;
using WebAutopark.DataAccess.Repository.Base;

namespace WebAutopark.DataAccess.Repository
{
    public class VehicleRepository : RepositoryBase, IRepository<Vehicle>
    {
        public VehicleRepository(IConnectionProvider connectionProvider) : base(connectionProvider)
        {
        }

        public Task Create(Vehicle item)
        {
            return connection.ExecuteAsync("insert Vehicles " +
                "values(@VehicleTypeID, " +
                "@ModelName, " +
                "@RegistrationNumber, " +
                "@Weight, " +
                "@ManufactureYear, " +
                "@Maileage, " +
                "@Color, " +
                "@TankCapacity)", item);
        }

        public Task Delete(int id)
        {
            return connection.ExecuteAsync("delete VechicleTypes where ID = @ID", new { ID = id });
        }

        public Task<Vehicle> Get(int id)
        {
            return connection.QueryFirstAsync<Vehicle>("select * from Vehicles where ID = @ID", new { ID = id });
        }

        public Task<IEnumerable<Vehicle>> GetAll()
        {
            return connection.QueryAsync<Vehicle>("select * from Vehicles");
        }

        public Task Update(Vehicle item)
        {
            return connection.ExecuteAsync("update Vehicles set Vehicles = @VehicleTypeID, " +
                "ModelName = @ModelName, " +
                "RegistrationNumber = @RegistrationNumber, " +
                "Weight = @Weight, " +
                "ManufactureYear = @ManufactureYear, " +
                "Maileage = @Maileage, " +
                "Color = @Color, " +
                "TankCapacity = @TankCapacity " +
                "where ID = @ID", item);
        }
    }
}
