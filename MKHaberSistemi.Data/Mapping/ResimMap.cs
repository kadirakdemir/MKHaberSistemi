using MKHaberSistemi.Core.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MKHaberSistemi.Data.Mapping
{
    public class ResimMap : EntityTypeConfiguration<Resim>
    {
        public ResimMap()
        {
            this.ToTable("Resim", "library");

            this.Property(p => p.EklemeTarihi)
             .HasColumnName("EklemeTarihi")
             .HasColumnType("datetime2")
             .IsRequired();

            this.Property(p => p.GuncellemeTarihi)
                .HasColumnName("GuncellemeTarihi")
                .HasColumnType("datetime2")
                .IsOptional();
        }
    }
}
