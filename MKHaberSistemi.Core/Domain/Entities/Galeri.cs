using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
  //  [Table(name: "Resimler", Schema = "library")]
    public partial class Galeri : AudiTableEntity
    {
        public Galeri()
        {
            Resimler = new HashSet<Resim>();
        }
        public string Ad { get; set; }
        public int? HaberID { get; set; }
        public string SeoAd { get; set; }
        public string ProfilResimUrl { get; set; }
        public virtual Haber Haber { get; set; }
        public ICollection<Resim> Resimler { get; set; }
    }
}
