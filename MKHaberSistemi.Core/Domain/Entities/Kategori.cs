using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    //[Table(name: "Kategori", Schema = "library")]
    public partial class Kategori : AudiTableEntity
    {
        public Kategori()
        {
            Haberler = new HashSet<Haber>();
        }

        public string Ad { get; set; }
        public int? AltID { get; set; }
        public string SeoAd { get; set; }
        public string DugumYoluIdler { get; set; }
        public string DugumYoluMetni { get; set; }
        public string ProfilResimUrl { get; set; }
        public int Diger { get; set; }
        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
