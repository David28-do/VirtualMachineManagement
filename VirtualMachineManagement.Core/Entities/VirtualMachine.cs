namespace VirtualMachineManagement.Core.Entities
{
    public partial class VirtualMachine : BaseEntity
    {
        public string Name { get; set; }
        public string Core { get; set; }
        public string Ram { get; set; }
        public string Disk { get; set; }
        public string Os { get; set; }
        public bool Status { get; set; }

    }
}
