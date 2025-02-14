using b3.DeveloperEvaluation.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace b3.DeveloperEvaluation.ORM.Mapping;

public class TituloConfiguration : IEntityTypeConfiguration<Titulo>
{
    public void Configure(EntityTypeBuilder<Titulo> builder)
    {
        builder.ToTable("Titulos");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.DtFinal)
            .HasColumnType("timestamp with time zone");

        builder.Property(u => u.NomeTitulo)
            .HasMaxLength(60);

        builder.Property(u => u.Empresa)
            .HasMaxLength(60);

        builder.Property(u => u.Rentabilidade)
            .HasColumnType("numeric(15,2)");
    }
}