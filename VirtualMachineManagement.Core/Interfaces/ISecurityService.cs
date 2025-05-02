using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
        Task RegisterUser(Security security);
    }
}
