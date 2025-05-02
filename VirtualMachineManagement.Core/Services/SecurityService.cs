using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Interfaces;

namespace VirtualMachineManagement.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public SecurityService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _UnitOfWork.SecurityRepository.GetLoginByCredentials(login);
        }

        public async Task RegisterUser(Security security)
        {
            await _UnitOfWork.SecurityRepository.Add(security);
            await _UnitOfWork.SaveChangesAsync();
        }
    }
}
