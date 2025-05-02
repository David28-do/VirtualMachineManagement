using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Infrastructure.Data.Configurations
{
    public class VirtualMachineConfiguration : IEntityTypeConfiguration<VirtualMachine>
    {
        public void Configure(EntityTypeBuilder<VirtualMachine> builder)
        {
            builder.ToTable("VIRTUALMACHINE");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
         .HasColumnName("Id");

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasMaxLength(50)
                   .IsUnicode(false);

            builder.Property(e => e.Core)
                  .IsRequired()
                  .HasColumnName("Core")
                  .HasMaxLength(50)
                  .IsUnicode(false);

            builder.Property(e => e.Ram)
                  .IsRequired()
                  .HasColumnName("Ram")
                  .HasMaxLength(50)
                  .IsUnicode(false);

            builder.Property(e => e.Disk)
                  .IsRequired()
                  .HasColumnName("Disk")
                  .HasMaxLength(50)
                  .IsUnicode(false);

            builder.Property(e => e.Os)
               .IsRequired()
               .HasColumnName("Os")
               .HasMaxLength(50)
               .IsUnicode(false);

            builder.Property(e => e.Status)
              .IsRequired()
              .HasColumnName("Status")
              .HasMaxLength(50)
              .IsUnicode(false);

        }
    }
}
