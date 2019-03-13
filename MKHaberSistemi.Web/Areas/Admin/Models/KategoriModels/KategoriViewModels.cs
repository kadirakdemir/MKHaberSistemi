using MKHaberSistemi.Core.Domain.Entities;
using MKHaberSistemi.Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MKHaberSistemi.Web.Areas.Admin.Models.KategoriModels
{
    public class EditKategoriModel : BaseViewModel
    {
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Kategori Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Kategori Resim")]
        public HttpPostedFileBase ProfilRsm { get; set; }

        public string ProfileResimUrl { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Sıra")]
        public int Diger { get; set; }

        [Display(Name = "Üst Kategori")]
        public int? AltID { get; set; }

        public virtual IEnumerable<Kategori> Kategoriler { get; set; }
    }

    public class DetayKategoriModel : BaseViewModel
    {

        [Display(Name = "Kategori Adı")]
        public string Ad { get; set; }

        [Display(Name = "Kategori Resmi")]
        public string ProfileResimUrl { get; set; }

        [Display(Name = "Seo Adı")]
        public int SeoAd { get; set; }

        [Display(Name = "Sıra")]
        public int Diger { get; set; }

        [Display(Name = "Üst Kategori")]
        public string UstKategori { get; set; }

        public virtual IEnumerable<Kategori> Kategoriler { get; set; }
    }
}