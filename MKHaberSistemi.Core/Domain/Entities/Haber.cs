using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    //[Table(name: "Haber", Schema = "library")]
    public partial class Haber : AudiTableEntity
    {
        public Haber()
        {
            Etiketler = new HashSet<Etiket>();
            Galeri = new HashSet<Galeri>();
            Yorumlar = new HashSet<Yorum>();
        }
        public string Baslik { get; set; }
        public string SeoBaslik { get; set; }
        public string Icerik { get; set; }
        public string EtiketAdlari { get; set; }
        public DateTime? YayinlamaTarihi { get; set; }
        public string YayinlayanKullaniciId { get; set; }
        public string YazarId { get; set; }
        public int OkumaSayisi { get; set; }
        public int YorumSayisi { get; set; }
        public string Kaynak { get; set; }
        public bool IsYayinlandiMi { get; set; }
        public string ProfilRsmUrl { get; set; }
        public string ProfilRsmUrlBuyuk { get; set; }
        public string ProfilRsmUrlOrta { get; set; }
        public string ProfilRsmUrlKucuk { get; set; }
        public int KategoriID { get; set; }
        public int HaberTipID { get; set; }
        public int HaberPozisyonID { get; set; }
        public string KullaniciID { get; set; }
        public virtual  ApplicationUser Kullanici { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual HaberTip HaberTip { get; set; }
        public virtual HaberPozisyon HaberPozisyon { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
        public virtual ICollection<Etiket> Etiketler { get; set; }
        public virtual ICollection<Galeri> Galeri { get; set; }
    }
}
