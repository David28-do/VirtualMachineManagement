using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Infrastructure.Data
{
    public partial class VirtualMachineContext : DbContext
    {
        public VirtualMachineContext()
        {
        }

        public VirtualMachineContext(DbContextOptions<VirtualMachineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<VirtualMachine> VirtualMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }
    
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
