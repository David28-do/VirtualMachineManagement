using Microsoft.EntityFrameworkCore;
using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Interfaces;
using VirtualMachineManagement.Infrastructure.Data;

namespace VirtualMachineManagement.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(VirtualMachineContext contex) : base(contex) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User && x.Password == login.Password);
        }
    }
}