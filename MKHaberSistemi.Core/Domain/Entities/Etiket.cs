using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    //[Table(name: "Etiket", Schema = "library")]
    public partial class Etiket : AudiTableEntity
    {
        public Etiket()
        {
            Haberler = new HashSet<Haber>();
        }
        public string Ad { get; set; }
        public string SeoAd { get; set; }
        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
