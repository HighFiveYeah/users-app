using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Microsoft.EntityFrameworkCore;
using UserApi.Entities;

namespace UserApi.DataAccess
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly Func<DbContext> _contextFactory;

        public GenericRepository(IComponentContext scope)
        {
            _contextFactory = scope.Resolve<DbContext>;
        }

        public async Task Create(T model)
        {
            _contextFactory().Set<T>().Attach(model);
            await _contextFactory().SaveChangesAsync();
        }

        public async Task Update(T model)
        {
            _contextFactory().Set<T>().Update(model);
            await _contextFactory().SaveChangesAsync();
        }

        public async Task Delete(Guid guid)
        {
            var entity = await _contextFactory().Set<T>().FindAsync(guid);
            _contextFactory().Set<T>().Remove(entity);
            await _contextFactory().SaveChangesAsync();
        }

        public IEnumerable<T> GetAll() => _contextFactory().Set<T>();
    }
}