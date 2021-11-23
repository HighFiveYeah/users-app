using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserApi
{
    public interface IRepository<T> where T : class
    {
        Task Create(T model);
        Task Update(T model);
        Task Delete(Guid guid);
        IEnumerable<T> GetAll();
    }
}