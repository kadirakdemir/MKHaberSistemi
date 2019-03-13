using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    //[Table(name: "HaberPozisyon", Schema = "library")]
    public partial class HaberPozisyon : AudiTableEntity
    {
        public HaberPozisyon()
        {
            Haberler = new HashSet<Haber>();
        }
        public int PozisyonId { get; set; }
        public string Ad { get; set; }
        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
