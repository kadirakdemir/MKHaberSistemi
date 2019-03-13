using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class HaberTipMap:BaseEntityMap<HaberTip>
    {
        public HaberTipMap()
        {
            this.ToTable("HaberTip", "library");

            this.HasMany<Haber>(ht => ht.Haberler)
                .WithRequired(h => h.HaberTip)
                .HasForeignKey(h => h.HaberTipID);

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
