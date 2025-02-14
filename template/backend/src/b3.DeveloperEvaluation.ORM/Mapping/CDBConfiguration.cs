using b3.DeveloperEvaluation.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace b3.DeveloperEvaluation.ORM.Mapping;

public class CDBConfiguration : IEntityTypeConfiguration<CDB>
{
    public void Configure(EntityTypeBuilder<CDB> builder)
    {
        builder.ToTable("CDBs");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.DtInicial)
            .HasColumnType("timestamp with time zone");

        builder.Property(u => u.VF)
            .IsRequired();

        builder.Property(u => u.VI)
            .IsRequired();

        builder.Property(u => u.CDI)
            .IsRequired();

        builder.Property(u => u.TB)
            .IsRequired();

        builder.Property(u => u.IR)
            .IsRequired();

        builder.HasOne(u => u.Titulo)
                 .WithMany(x => x.CDBs)
                 .HasForeignKey(u => u.TituloId)
                 .OnDelete(DeleteBehavior.ClientNoAction);

    }
}