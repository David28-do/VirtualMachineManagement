using System.ComponentModel.DataAnnotations;

namespace VirtualMachineManagement.Core.Dtos
{
    public class VirtualMachineDTo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Core { get; set; }
        public string Ram { get; set; }
        public string Disk { get; set; }
        public string Os { get; set; }
        public bool Status { get; set; }
    }
}
