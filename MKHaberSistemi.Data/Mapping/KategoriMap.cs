using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class KategoriMap:BaseEntityMap<Kategori>
    {
        public KategoriMap()
        {
            this.ToTable("Kategori", "library");

            this.HasMany<Haber>(k => k.Haberler)
                .WithRequired(h => h.Kategori)
                .HasForeignKey(h => h.KategoriID);

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
