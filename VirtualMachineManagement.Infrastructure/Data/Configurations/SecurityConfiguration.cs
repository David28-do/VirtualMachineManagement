using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMachineManagement.Core.Entities;
using VirtualMachineManagement.Core.Enumerations;

namespace VirtualMachineManagement.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Seguridad");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
            .HasColumnName("IdSeguridad");

            builder.Property(e => e.User)
            .HasColumnName("Usuario")
             .IsRequired()
           .HasMaxLength(50)
           .IsUnicode(false);

            builder.Property(e => e.UserName)
            .HasColumnName("NombreUsuario")
             .IsRequired()
           .HasMaxLength(100)
           .IsUnicode(false);

            builder.Property(e => e.Password)
           .HasColumnName("Contrasena")
           .IsRequired()
           .HasMaxLength(200)
           .IsUnicode(false);

            builder.Property(e => e.Role)
                 .HasColumnName("Rol")
                .IsRequired()
                .HasMaxLength(15)
                .HasConversion(
                x => x.ToString(),
                x => (RoleType)Enum.Parse(typeof(RoleType), x)
                );
        }
    }
}
