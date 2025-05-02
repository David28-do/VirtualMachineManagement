using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<VirtualMachine> VirtualMachineRepository { get; }
        ISecurityRepository SecurityRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
