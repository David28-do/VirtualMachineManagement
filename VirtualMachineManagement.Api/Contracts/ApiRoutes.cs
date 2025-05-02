namespace VirtualMachineManagement.Api.Contracts
{
    public class ApiRoutes
    {
        public const string Root = "api";

        public static class VirtualMachineRoutes
        {
            public const string GetVirtualMachine = Root + "/virtualMachine";
            public const string GetVirtualMachineById = Root + "/virtualMachine/{id}";
            public const string AddVirtualMachine = Root + "/virtualMachine";
            public const string UpdateVirtualMachine = Root + "/virtualMachine/{id}";
            public const string DeleteVirtualMachine = Root + "/virtualMachine/{id}";

        }
    }
}
