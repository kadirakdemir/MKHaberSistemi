using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
   // [Table(name: "Yorumlar", Schema = "library")]
    public partial class Yorum : AudiTableEntity
    {
        public string Icerik { get; set; }
        public string KullaniciID { get; set; }       
        public int HaberID { get; set; }
        public virtual ApplicationUser Kullanici { get; set; }
        public virtual Haber Haber { get; set; }
    }
}
