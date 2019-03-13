namespace MKHaberSistemi.Data.DataContext.App5
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class son1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "library.HaberPozisyon",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PozisyonId = c.Int(nullable: false),
                        Ad = c.String(),
                        Aciklama = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "library.Haber",
                c => new
                    {
                        Baslik = c.String(nullable: false, maxLength: 250),
                        SeoBaslik = c.String(maxLength: 250),
                        Aciklama = c.String(),
                        Icerik = c.String(),
                        YayinlayanKullaniciId = c.String(maxLength: 128),
                        YazarId = c.String(maxLength: 128),
                        IsYayinlandiMi = c.Boolean(),
                        IsActive = c.Boolean(),
                        OkunmaSayisi = c.Int(),
                        YorumSayisi = c.Int(),
                        Kaynak = c.String(),
                        YayinlamaTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EtiketAdlari = c.String(),
                        ID = c.Int(nullable: false, identity: true),
                        ProfilRsmUrl = c.String(),
                        ProfilRsmUrlBuyuk = c.String(),
                        ProfilRsmUrlOrta = c.String(),
                        ProfilRsmUrlKucuk = c.String(),
                        KategoriID = c.Int(nullable: false),
                        HaberTipID = c.Int(nullable: false),
                        HaberPozisyonID = c.Int(nullable: false),
                        KullaniciID = c.String(nullable: false, maxLength: 128),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("library.HaberTip", t => t.HaberTipID, cascadeDelete: true)
                .ForeignKey("library.Kategori", t => t.KategoriID, cascadeDelete: true)
                .ForeignKey("identity.Kullanici", t => t.KullaniciID, cascadeDelete: true)
                .ForeignKey("library.HaberPozisyon", t => t.HaberPozisyonID, cascadeDelete: true)
                .Index(t => t.KategoriID)
                .Index(t => t.HaberTipID)
                .Index(t => t.HaberPozisyonID)
                .Index(t => t.KullaniciID);
            
            CreateTable(
                "library.Etiket",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 256),
                        SeoAd = c.String(maxLength: 50),
                        Aciklama = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "library.Galeri",
                c => new
                    {
                        Ad = c.String(),
                        SeoAd = c.String(),
                        Aciklama = c.String(),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                        ID = c.Int(nullable: false, identity: true),
                        HaberID = c.Int(),
                        ProfilResimUrl = c.String(),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("library.Haber", t => t.HaberID)
                .Index(t => t.HaberID);
            
            CreateTable(
                "library.Resim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        IcerikTipi = c.String(),
                        IcerikUzunlugu = c.Int(nullable: false),
                        RsmUrlOrjinal = c.String(),
                        RsmUrlBuyuk = c.String(),
                        RsmUrlOrta = c.String(),
                        RsmKucuk = c.String(),
                        GaleriID = c.Int(nullable: false),
                        Aciklama = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("library.Galeri", t => t.GaleriID, cascadeDelete: true)
                .Index(t => t.GaleriID);
            
            CreateTable(
                "library.HaberTip",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipId = c.Int(nullable: false),
                        Ad = c.String(),
                        Aciklama = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "library.Kategori",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        AltID = c.Int(),
                        SeoAd = c.String(),
                        DugumYoluIdler = c.String(),
                        DugumYoluMetni = c.String(),
                        ProfilResimUrl = c.String(),
                        Diger = c.Int(nullable: false),
                        Aciklama = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "identity.Kullanici",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        SurName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "identity.KullaniciHak",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("identity.Kullanici", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "library.EmailAyarlari",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Email = c.String(),
                        Host = c.String(),
                        Port = c.Int(nullable: false),
                        Aciklama = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        EklemeTarihi = c.DateTime(nullable: false),
                        GuncellemeTarihi = c.DateTime(nullable: false),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                        Kullanici_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("identity.Kullanici", t => t.Kullanici_Id)
                .Index(t => t.Kullanici_Id);
            
            CreateTable(
                "identity.KullaniciOturum",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("identity.Kullanici", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "identity.KullaniciRol",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("identity.Kullanici", t => t.UserId, cascadeDelete: true)
                .ForeignKey("identity.Rol", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "library.Yorum",
                c => new
                    {
                        Aciklama = c.String(),
                        Icerik = c.String(),
                        EklemeTarihi = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        GuncellemeTarihi = c.DateTime(precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(),
                        ID = c.Int(nullable: false, identity: true),
                        KullaniciID = c.String(maxLength: 128),
                        HaberID = c.Int(nullable: false),
                        EkleyenKullaniciId = c.String(),
                        GuncelleyenKullaniciId = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("library.Haber", t => t.HaberID, cascadeDelete: true)
                .ForeignKey("identity.Kullanici", t => t.KullaniciID)
                .Index(t => t.KullaniciID)
                .Index(t => t.HaberID);
            
            CreateTable(
                "identity.Rol",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "library.HaberEtiket",
                c => new
                    {
                        Haber_ID = c.Int(nullable: false),
                        Etiket_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Haber_ID, t.Etiket_ID })
                .ForeignKey("library.Haber", t => t.Haber_ID, cascadeDelete: true)
                .ForeignKey("library.Etiket", t => t.Etiket_ID, cascadeDelete: true)
                .Index(t => t.Haber_ID)
                .Index(t => t.Etiket_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("identity.KullaniciRol", "RoleId", "identity.Rol");
            DropForeignKey("library.Haber", "HaberPozisyonID", "library.HaberPozisyon");
            DropForeignKey("library.Yorum", "KullaniciID", "identity.Kullanici");
            DropForeignKey("library.Yorum", "HaberID", "library.Haber");
            DropForeignKey("identity.KullaniciRol", "UserId", "identity.Kullanici");
            DropForeignKey("identity.KullaniciOturum", "UserId", "identity.Kullanici");
            DropForeignKey("library.Haber", "KullaniciID", "identity.Kullanici");
            DropForeignKey("library.EmailAyarlari", "Kullanici_Id", "identity.Kullanici");
            DropForeignKey("identity.KullaniciHak", "UserId", "identity.Kullanici");
            DropForeignKey("library.Haber", "KategoriID", "library.Kategori");
            DropForeignKey("library.Haber", "HaberTipID", "library.HaberTip");
            DropForeignKey("library.Galeri", "HaberID", "library.Haber");
            DropForeignKey("library.Resim", "GaleriID", "library.Galeri");
            DropForeignKey("library.HaberEtiket", "Etiket_ID", "library.Etiket");
            DropForeignKey("library.HaberEtiket", "Haber_ID", "library.Haber");
            DropIndex("library.HaberEtiket", new[] { "Etiket_ID" });
            DropIndex("library.HaberEtiket", new[] { "Haber_ID" });
            DropIndex("identity.Rol", "RoleNameIndex");
            DropIndex("library.Yorum", new[] { "HaberID" });
            DropIndex("library.Yorum", new[] { "KullaniciID" });
            DropIndex("identity.KullaniciRol", new[] { "RoleId" });
            DropIndex("identity.KullaniciRol", new[] { "UserId" });
            DropIndex("identity.KullaniciOturum", new[] { "UserId" });
            DropIndex("library.EmailAyarlari", new[] { "Kullanici_Id" });
            DropIndex("identity.KullaniciHak", new[] { "UserId" });
            DropIndex("identity.Kullanici", "UserNameIndex");
            DropIndex("library.Resim", new[] { "GaleriID" });
            DropIndex("library.Galeri", new[] { "HaberID" });
            DropIndex("library.Haber", new[] { "KullaniciID" });
            DropIndex("library.Haber", new[] { "HaberPozisyonID" });
            DropIndex("library.Haber", new[] { "HaberTipID" });
            DropIndex("library.Haber", new[] { "KategoriID" });
            DropTable("library.HaberEtiket");
            DropTable("identity.Rol");
            DropTable("library.Yorum");
            DropTable("identity.KullaniciRol");
            DropTable("identity.KullaniciOturum");
            DropTable("library.EmailAyarlari");
            DropTable("identity.KullaniciHak");
            DropTable("identity.Kullanici");
            DropTable("library.Kategori");
            DropTable("library.HaberTip");
            DropTable("library.Resim");
            DropTable("library.Galeri");
            DropTable("library.Etiket");
            DropTable("library.Haber");
            DropTable("library.HaberPozisyon");
        }
    }
}
