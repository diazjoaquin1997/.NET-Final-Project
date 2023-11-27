using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("id_usuario");

            builder.Property(t => t.Name)
                .HasColumnName("Nombre");

            builder.Property(t => t.RolId)
                .IsRequired()
                .HasColumnName("id_rol");
        }
    }
}
