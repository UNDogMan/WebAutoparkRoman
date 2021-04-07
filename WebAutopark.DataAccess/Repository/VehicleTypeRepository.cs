using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Repository.Base;
using WebAutopark.DataAccess.Entities;
using Dapper;

namespace WebAutopark.DataAccess.Repository
{
    public class VehicleTypeRepository : RepositoryConnection, IRepository<VehicleType>
    {
        public VehicleTypeRepository(string connectionString) : base(connectionString)
        {

        }

        public Task Create(VehicleType item)
        {
            return connection.ExecuteAsync("insert into VechicleTypes values(@TypeName, @TaxCoefficient)", item);
        }

        public Task Delete(int id)
        {
            return connection.ExecuteAsync("delete VechicleTypes where ID = @ID", new { ID = id });
        }

        public Task<VehicleType> Get(int id)
        {
            return connection.QueryFirstAsync<VehicleType>("select * from VechicleTypes where ID = @ID", new { ID = id });
        }

        public Task<IEnumerable<VehicleType>> GetAll()
        {
            return connection.QueryAsync<VehicleType>("select * from VechicleTypes");
        }

        public Task Update(VehicleType item)
        {
            return connection.ExecuteAsync("update VechicleTypes set TypeName = @TypeName, TaxCoefficient = @TaxCoefficient where ID = @ID", item);
        }
    }
}
