using AutoMapper;
using VirtualMachineManagement.Core.Dtos;
using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Core.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VirtualMachine, VirtualMachineDTo>().ReverseMap();
            CreateMap<VirtualMachineDTo, VirtualMachine>().ReverseMap();

            CreateMap<Security, SecurityDTo>().ReverseMap();
            CreateMap<SecurityDTo, Security>().ReverseMap();
        }
    }
}
