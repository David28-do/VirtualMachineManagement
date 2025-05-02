using VirtualMachineManagement.Core.Enumerations;

namespace VirtualMachineManagement.Core.Dtos
{
    public class SecurityDTo
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
