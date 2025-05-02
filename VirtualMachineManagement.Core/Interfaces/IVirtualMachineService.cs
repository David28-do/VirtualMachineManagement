using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Core.Interfaces
{
    public interface IVirtualMachineService
    {
        Task<IEnumerable<VirtualMachine>> GetVirtualMachines();
        Task<VirtualMachine> GetVirtualMachine(int id);
        Task InsertVirtualMachine(VirtualMachine virtualMachine);
        Task<bool> UpdateVirtualMachine(VirtualMachine virtualMachine);
        Task<bool> DeleteVirtualMachine(int id);
    }
}
