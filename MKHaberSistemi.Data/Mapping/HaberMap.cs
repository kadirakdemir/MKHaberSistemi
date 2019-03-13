using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class HaberMap:BaseEntityMap<Haber>
    {
     
        public HaberMap()
        {
            this.ToTable("Haber", "library");   // tablo ismi ve şeması ismi

            // Alanlar
            //this.Property(p=>p.ID)
            //    .HasColumnName("ID")
            //    .HasColumnOrder(0)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // otomatik arttırma

            this.Property(p => p.Baslik)        // ilgili alana özellikler tanımlama metodu
                .HasColumnName("Baslik")        // kolon başlık ismi
                .HasMaxLength(250)              // kolon karakter uzunluğu
                .HasColumnOrder(1)              // kolon sırası
                .IsRequired();                  // zorunlu alan

            this.Property(p => p.SeoBaslik)
               .HasColumnName("SeoBaslik")
               .HasMaxLength(250)
               .HasColumnOrder(2)
               .IsOptional();                   // zorunlu olmayan alan

            this.Property(p => p.Aciklama)
                .HasColumnName("Aciklama")
                .HasColumnOrder(3)
                .IsMaxLength()
                .IsOptional();                  // zorunlu olmayan alan           

            this.Property(p => p.Icerik)
                .HasColumnName("Icerik")
                .HasColumnOrder(4)
                .IsMaxLength()                  // nvarcharmax gibi en uzun yapıyor.
                .IsOptional();

            this.Property(p => p.EtiketAdlari)
                .HasColumnName("EtiketAdlari")
                .HasColumnOrder(15)
                .IsMaxLength()
                .IsOptional();

            this.Property(p => p.YayinlamaTarihi)
                .HasColumnName("YayinlamaTarihi")
                .HasColumnOrder(12)
                .HasColumnType("datetime2")         // tarih yazılma biçimi 
                .IsOptional();


            this.Property(p => p.EklemeTarihi)
                .HasColumnName("EklemeTarihi")
                .HasColumnOrder(13)
                .HasColumnType("datetime2")
                .IsRequired();

            this.Property(p => p.GuncellemeTarihi)
                .HasColumnName("GuncellemeTarihi")
                .HasColumnOrder(14)
                .HasColumnType("datetime2")
                .IsOptional();

            this.Property(p => p.Kaynak)
                .HasColumnName("Kaynak")
                .HasColumnOrder(11)
                .IsMaxLength()
                .IsOptional();

            this.Property(p => p.OkumaSayisi)
                .HasColumnName("OkunmaSayisi")
                .HasColumnOrder(9)
                .HasColumnType("int")
                .IsOptional();

            this.Property(p => p.YorumSayisi)
                .HasColumnName("YorumSayisi")
                .HasColumnOrder(10)
                .HasColumnType("int")
                .IsOptional();

            this.Property(p => p.YayinlayanKullaniciId)
                .HasColumnOrder(5)
                .HasColumnType("nvarchar")
                .HasColumnName("YayinlayanKullaniciId")
                .IsOptional()
                .HasMaxLength(128);

            this.Property(p => p.YazarId)
                .HasColumnName("YazarId")
                .HasColumnOrder(6)
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();

            this.Property(p => p.IsYayinlandiMi)
                .HasColumnName("IsYayinlandiMi")
                .HasColumnOrder(7)
                .IsOptional();

            this.Property(p => p.IsActive)
                .HasColumnName("IsActive")
                .HasColumnOrder(8)
                .IsOptional();

            this.Property(p => p.KullaniciID)
                .HasColumnType("nvarchar")
                .HasMaxLength(128);

            this.HasMany<Etiket>(h => h.Etiketler)
                .WithMany(e => e.Haberler)
                .Map(he => he.ToTable("HaberEtiket", "library")    // many to many çoka çok ilişki 
                .MapRightKey("Etiket_ID")
                .MapLeftKey("Haber_ID"));

            //this.HasMany<Yorum>(h => h.Yorumlar)
            //    .WithRequired(y => y.Haber)
            //    .HasForeignKey(y => y.HaberID);         // one to many bire çok ilişki

            this.HasMany<Galeri>(h => h.Galeri)
                .WithOptional(r => r.Haber)
                .HasForeignKey(r => r.HaberID);
        }
    }
}
