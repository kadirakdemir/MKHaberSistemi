using MKHaberSistemi.Web.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MKHaberSistemi.Web.Areas.Admin.Models.GaleriModels
{
    public class EditGaleriViewModel:BaseViewModel
    {
        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Galeri Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir!")]
        [Display(Name = "Kategori Resim")]
        public HttpPostedFileBase ProfilRsm { get; set; }
        public string ProfileResimUrl { get; set; }
    }

    public class EditGaleriResimViewModel : BaseViewModel
    {
        public int GaleriId { get; set; }
        public string Ad { get; set; }
        public string ResimUrl { get; set; }
    }
}