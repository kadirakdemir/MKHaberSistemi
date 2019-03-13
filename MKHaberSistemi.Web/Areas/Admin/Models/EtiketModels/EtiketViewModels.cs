using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MKHaberSistemi.Web.Areas.Admin.Models
{
    public class EditEtiketViewModel:BaseViewModel
    {
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        public string Ad { get; set; }

        public virtual IEnumerable<Etiket> Etiketler { get; set; } 
    }

    public class DetayEtiketViewModel:BaseViewModel
    {
        [Display(Name = "Açıklama")]       
        public string Ad { get; set; }       

        [Display(Name = "Seo Adı")]
        public string SeoAd { get; set; }

        [Display(Name ="Ekleme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EklemeTarihi { get; set; }

        [Display(Name = "Değiştirilme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GuncellemeTarihi { get; set; }

        [Display(Name ="Toplam Etiket Sayısı")]
        public int ToplamEtiket { get; set; }

        [Display(Name = "Kullanılan haber sayısı")]
        public int HaberSayisi { get; set; }
    }
}