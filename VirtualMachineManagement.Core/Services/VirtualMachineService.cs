using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Interfaces;

namespace VirtualMachineManagement.Core.Services
{
    public class VirtualMachineService : IVirtualMachineService
    {
        private readonly IUnitOfWork _UnitOfWork;

        public VirtualMachineService(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<VirtualMachine> GetVirtualMachine(int id)
        {
            return await _UnitOfWork.VirtualMachineRepository.GetById(id);
        }
        public async Task<IEnumerable<VirtualMachine>> GetVirtualMachines()
        {
            return _UnitOfWork.VirtualMachineRepository.GetAll();
        }

        public async Task InsertVirtualMachine(VirtualMachine virtualMachine)
        {
            await _UnitOfWork.VirtualMachineRepository.Add(virtualMachine);
            await _UnitOfWork.SaveChangesAsync();

        }

        public async Task<bool> UpdateVirtualMachine(VirtualMachine virtualMachine)
        {
            _UnitOfWork.VirtualMachineRepository.Update(virtualMachine);
            await _UnitOfWork.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteVirtualMachine(int id)
        {
            await _UnitOfWork.VirtualMachineRepository.Delete(id);
            await _UnitOfWork.SaveChangesAsync();
            return true;
        }

    }
}