using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMachineManagement.Core.Entities;

namespace VirtualMachineManagement.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
           .HasColumnName("UsuId");

            builder.Property(e => e.UsuNombre)
                    .IsRequired()
                    .HasColumnName("UsuNombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);


            builder.Property(e => e.UsuPass)
                .IsRequired()
                .HasColumnName("UsuPass")
                .HasMaxLength(20)
                .IsUnicode(false);

            
        }
    }
}
