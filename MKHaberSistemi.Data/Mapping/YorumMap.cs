using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class YorumMap:BaseEntityMap<Yorum>
    {
        public YorumMap()
        {
            this.ToTable("Yorum", "library");

            this.Property(p => p.Aciklama)
                .HasColumnName("Aciklama")
                .HasColumnOrder(1)
                .IsMaxLength()
                .IsOptional();                  // zorunlu olmayan alan  

            this.Property(p => p.Icerik)
               .HasColumnName("Icerik")
               .HasColumnOrder(2)
               .IsMaxLength()                  // nvarcharmax gibi en uzun yapıyor.
               .IsOptional();

            this.Property(p => p.EklemeTarihi)
               .HasColumnName("EklemeTarihi")
               .HasColumnOrder(3)
               .HasColumnType("datetime2")
               .IsRequired();

            this.Property(p => p.GuncellemeTarihi)
                .HasColumnName("GuncellemeTarihi")
                .HasColumnOrder(4)
                .HasColumnType("datetime2")
                .IsOptional();

            this.Property(p => p.IsActive)
               .HasColumnName("IsActive")
               .HasColumnOrder(5)
               .IsOptional();

            this.Property(p => p.KullaniciID)
                .HasColumnType("nvarchar")
                .HasMaxLength(128);
        }
    }
}
