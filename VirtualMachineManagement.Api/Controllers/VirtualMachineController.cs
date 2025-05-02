using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualMachineManagement.Api.Responses;
using VirtualMachineManagement.Core.Dtos;
using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Enumerations;
using VirtualMachineManagement.Core.Interfaces;
using static VirtualMachineManagement.Api.Contracts.ApiRoutes;

namespace VirtualMachineManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class VirtualMachineController : ControllerBase
    {
        private readonly IVirtualMachineService _virtualMachineService;
        private readonly IMapper _mapper;
        public VirtualMachineController(IVirtualMachineService virtualMachineService, IMapper mapper) 
        {
            _virtualMachineService = virtualMachineService;
            _mapper = mapper;
        }

        [Authorize(Roles = $"{nameof(RoleType.Administrador)},{nameof(RoleType.Developer)}")]
        [HttpGet]
        [Route(VirtualMachineRoutes.GetVirtualMachine)]
        public async Task<IActionResult> GetVirtualMachines()
        {
            var virtualMachines = await _virtualMachineService.GetVirtualMachines();
            var virtualMachinesDtos = _mapper.Map<IEnumerable<VirtualMachineDTo>>(virtualMachines);
            var response = new ApiResponse<IEnumerable<VirtualMachineDTo>>(virtualMachinesDtos);
            return Ok(response);
        }

        [Authorize(Roles = $"{nameof(RoleType.Administrador)},{nameof(RoleType.Developer)}")]
        [HttpGet]
        [Route(VirtualMachineRoutes.GetVirtualMachineById)]
        public async Task<IActionResult> GetVirtualMachine(int id)
        {
            var virtualMachine = await _virtualMachineService.GetVirtualMachine(id);
            var virtualMachineDto = _mapper.Map<VirtualMachineDTo>(virtualMachine);
            var response = new ApiResponse<VirtualMachineDTo>(virtualMachineDto);
            return Ok(response);
        }

        [Authorize(Roles = $"{nameof(RoleType.Administrador)}")]
        [HttpPost]
        [Route(VirtualMachineRoutes.AddVirtualMachine)] 
        public async Task<IActionResult> AddVirtualMachine(VirtualMachineDTo VirtualMachineDTo)
        {
            var virtualMachine = _mapper.Map<VirtualMachine>(VirtualMachineDTo);
            await _virtualMachineService.InsertVirtualMachine(virtualMachine);
            var virtualMachineDto = _mapper.Map<VirtualMachineDTo>(virtualMachine);

            var response = new ApiResponse<VirtualMachineDTo>(virtualMachineDto);

            return Ok(response);
        }

        [Authorize(Roles = $"{nameof(RoleType.Administrador)}")]
        [HttpPut]
        [Route(VirtualMachineRoutes.UpdateVirtualMachine)]
        public async Task<IActionResult> UpdateVirtualMachine(int id, VirtualMachineDTo VirtualMachineDTo)
        {
            var virtualMachine = _mapper.Map<VirtualMachine>(VirtualMachineDTo);
            virtualMachine.Id = id;
            var result = await _virtualMachineService.UpdateVirtualMachine(virtualMachine);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [Authorize(Roles = $"{nameof(RoleType.Administrador)}")]
        [HttpDelete]
        [Route(VirtualMachineRoutes.DeleteVirtualMachine)]
        public async Task<IActionResult> DeleteVirtualMachine(int id)
        {
            var result = await _virtualMachineService.DeleteVirtualMachine(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
