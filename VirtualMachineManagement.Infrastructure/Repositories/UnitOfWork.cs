using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Interfaces;
using VirtualMachineManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMachineManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VirtualMachineContext _context;
        private readonly IRepository<VirtualMachine> _VirtualMachine;
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(VirtualMachineContext context)
        {
            _context = context;
        }
        public IRepository<VirtualMachine> VirtualMachineRepository => _VirtualMachine ?? new BaseRepository<VirtualMachine>(_context);

        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
