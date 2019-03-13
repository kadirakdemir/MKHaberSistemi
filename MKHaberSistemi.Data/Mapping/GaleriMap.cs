using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class GaleriMap:BaseEntityMap<Galeri>
    {
        public GaleriMap()
        {
            this.ToTable("Galeri", "library");

            this.Property(p => p.Aciklama)
               .HasColumnName("Aciklama")
               .HasColumnOrder(3)
               .HasColumnType("nvarchar(max)")
               .IsOptional();                  // zorunlu olmayan alan  

            this.Property(p => p.Ad)
               .HasColumnName("Ad")
               .HasColumnOrder(1)
               .IsMaxLength()                  // nvarcharmax gibi en uzun yapıyor.
               .IsOptional();

            this.Property(p => p.SeoAd)
               .HasColumnName("SeoAd")
               .HasColumnOrder(2)
               .IsMaxLength()                  // nvarcharmax gibi en uzun yapıyor.
               .IsOptional();

            this.Property(p => p.EklemeTarihi)
               .HasColumnName("EklemeTarihi")
               .HasColumnOrder(4)
               .HasColumnType("datetime2")
               .IsRequired();

            this.Property(p => p.GuncellemeTarihi)
                .HasColumnName("GuncellemeTarihi")
                .HasColumnOrder(5)
                .HasColumnType("datetime2")
                .IsOptional();

            this.Property(p => p.IsActive)
               .HasColumnName("IsActive")
               .HasColumnOrder(6)
               .IsOptional();

            this.HasMany<Resim>(rl => rl.Resimler)
                .WithRequired(r => r.Galeri)
                .HasForeignKey(r => r.GaleriID);
        }
    }
}
