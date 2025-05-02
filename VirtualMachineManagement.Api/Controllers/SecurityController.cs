using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualMachineManagement.Api.Responses;
using VirtualMachineManagement.Core.Dtos;
using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Enumerations;
using VirtualMachineManagement.Core.Interfaces;

namespace VirtualMachineManagement.Api.Controllers
{
    [Authorize(Roles = nameof(RoleType.Administrador))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(SecurityDTo securityDTo)
        {
            var security = _mapper.Map<Security>(securityDTo);
            await _securityService.RegisterUser(security);
            securityDTo = _mapper.Map<SecurityDTo>(security);

            var response = new ApiResponse<SecurityDTo>(securityDTo);

            return Ok(response);
        }
    }
}

