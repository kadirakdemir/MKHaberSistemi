using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
   // [Table(name:"Resim", Schema = "library")]
    public partial class Resim : AudiTableEntity
    {
        public string Ad { get; set; }
        public string IcerikTipi { get; set; }
        public int IcerikUzunlugu { get; set; }
        public string RsmUrlOrjinal { get; set; }
        public string RsmUrlBuyuk { get; set; }
        public string RsmUrlOrta { get; set; }
        public string RsmKucuk { get; set; }
        public int GaleriID { get; set; }
        public virtual Galeri Galeri { get; set; }
    }
}
