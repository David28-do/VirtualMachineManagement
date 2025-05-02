using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T Entity);
        void Update(T Entity);
        Task Delete(int id);
    }
}