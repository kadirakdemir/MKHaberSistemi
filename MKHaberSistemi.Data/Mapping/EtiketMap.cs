using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class EtiketMap : BaseEntityMap<Etiket>
    {
        public EtiketMap()
        {
            // Alanlar
            this.ToTable("Etiket", "library");
            this.Property(e => e.Ad).HasColumnName("Ad")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(e => e.SeoAd)
                .HasColumnName("SeoAd")
                .HasMaxLength(50)
                .IsOptional();

            this.Property(p => p.EklemeTarihi)
             .HasColumnName("EklemeTarihi")
             .HasColumnType("datetime2")
             .IsRequired();

            this.Property(p => p.GuncellemeTarihi)
                .HasColumnName("GuncellemeTarihi")
                .HasColumnType("datetime2")
                .IsOptional();

            //this.HasMany<Haber>(h => h.Haberler)
            //  .WithMany(e => e.Etiketler)
            //  .Map(he => he.ToTable("HaberEtiket", "library")    // many to many çoka çok ilişki 
            //  .MapRightKey("Haber_ID")
            //  .MapLeftKey("Etiket_ID"));

        }
    }
}
