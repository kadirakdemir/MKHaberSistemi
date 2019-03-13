using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class HaberPozisyonMap:BaseEntityMap<HaberPozisyon>
    {
        public HaberPozisyonMap()
        {
            this.ToTable("HaberPozisyon", "library");

            this.HasMany<Haber>(hp => hp.Haberler)
                .WithRequired(h => h.HaberPozisyon)
                .HasForeignKey(h => h.HaberPozisyonID);

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
