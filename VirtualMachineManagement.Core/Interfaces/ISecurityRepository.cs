using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}