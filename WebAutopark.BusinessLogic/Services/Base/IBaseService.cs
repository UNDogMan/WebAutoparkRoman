using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
