using Microsoft.EntityFrameworkCore;
using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Interfaces;
using VirtualMachineManagement.Infrastructure.Data;

namespace VirtualMachineManagement.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly VirtualMachineContext _context;
        protected DbSet<T> _entities;

        public BaseRepository(VirtualMachineContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
       
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T Entity)
        {
            await _entities.AddAsync(Entity);
        }
        public void Update(T Entity)
        {
            _entities.Update(Entity);
        }
        public async Task Delete(int id)
        {
            T Entity = await GetById(id);
            _entities.Remove(Entity);
        }


    }
}