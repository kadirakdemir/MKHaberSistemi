using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MKHaberSistemi.Web.Areas.Admin.Models.HaberModels
{
    public class EditHaberViewModel:BaseViewModel
    {

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Kategori Adı")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "İçerik")]
        [DataType(DataType.MultilineText)]
        public string Icerik { get; set; }

       // [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Profil Resim")]
        public HttpPostedFileBase ProfilRsm { get; set; }

        public string ProfileResimUrl { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        public string Kaynak { get; set; }           

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Yayinlandi Durumu")]
        public bool IsYayinlandiMi { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Kategori")]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Haber Tipi")]
        public int HaberTipiID { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Haber Pozisyonu")]
        public int HaberPozisyonuID { get; set; }   

        [Display(Name = "Yazar")]
        public string YazarId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Etiketler")]
        public int[] SecilenEtiketId { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Resimler")]
        public int[] SecilenResimlerId { get; set; }

        public string GuncelleyenKullaniciId { get; set; }

        public virtual IEnumerable<Kategori> Kategoriler { get; set; }
        public virtual IEnumerable<Galeri> Resimler { get; set; }
        public virtual IEnumerable<Etiket> Etiketler { get; set; }
        public virtual IEnumerable<ApplicationUser> Yazarlar { get; set; }
        public virtual IEnumerable<HaberTip> HaberTipleri { get; set; }
        public virtual IQueryable<ApplicationUser> Kullanicilar { get; set; }
        public virtual IEnumerable<HaberPozisyon> HaberPozisyonlar { get; set; }
    }

    public class DetailHaberViewModel : BaseViewModel
    {

       
        [Display(Name = "Kategori Adı")]
        public string Baslik { get; set; }
      
        [Display(Name = "İçerik")]
        [DataType(DataType.MultilineText)]
        public string Icerik { get; set; }

        
        [Display(Name = "Profil Resim")]
        public HttpPostedFileBase ProfilRsm { get; set; }
        public string ProfileResimUrl { get; set; }

        public string Kaynak { get; set; }

        [Display(Name = "Değiştirilme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime YayınlanmaTarihi { get; set; }

        [Display(Name = "Ekleme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EklemeTarihi { get; set; }

        [Display(Name = "Değiştirilme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GuncellemeTarihi { get; set; }

        [Display(Name = "Yayinlandi Durumu")]
        public bool IsYayinlandiMi { get; set; }

        [Display(Name = "Okunma Sayısı")]
        public int OkunmaSayisi { get; set; }

        [Display(Name = "Yorum Sayısı")]
        public int YorumSayisi { get; set; }

        [Display(Name = "Kategori")]
        public int KategoriID { get; set; }

        [Display(Name = "Haber Tipi")]
        public int HaberTipiID { get; set; }

        [Display(Name = "Haber Pozisyonu")]
        public int HaberPozisyonuID { get; set; }

        [Display(Name = "Yazar")]
        public string YazarId { get; set; }

     
        [Display(Name = "Etiketler")]
        public int[] SecilenEtiketId { get; set; }

        [Display(Name = "Resimler")]
        public int[] SecilenResimlerId { get; set; }

        public string GuncelleyenKullaniciId { get; set; }

        public virtual IEnumerable<Kategori> Kategoriler { get; set; }
        public virtual IEnumerable<Galeri> Resimler { get; set; }
        public virtual IEnumerable<Etiket> Etiketler { get; set; }
        public virtual IEnumerable<ApplicationUser> Yazarlar { get; set; }
        public virtual IEnumerable<HaberTip> HaberTipleri { get; set; }
        public virtual IQueryable<ApplicationUser> Kullanicilar { get; set; }
        public virtual IEnumerable<HaberPozisyon> HaberPozisyonlar { get; set; }
    }
}