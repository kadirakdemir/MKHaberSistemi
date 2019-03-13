using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Web.Infrastructure.Models
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Aciklama { get; set; }

        [Display(Name = "Durum")]
        public bool IsActive { get; set; }
    }
}
