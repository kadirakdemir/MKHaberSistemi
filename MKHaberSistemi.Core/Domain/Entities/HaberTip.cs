using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    //[Table(name: "HaberTip", Schema = "library")]
    public partial class HaberTip : AudiTableEntity
    {
        public HaberTip()
        {
            Haberler = new HashSet<Haber>();
        }
        public int TipId { get; set; }
        public string Ad { get; set; }
        public virtual ICollection<Haber> Haberler { get; set; }
    }
}
