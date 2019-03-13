using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    public partial class AudiTableEntity:BaseEntity
    {
        public string Aciklama { get; set; }
        public bool IsActive { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public string EkleyenKullaniciId { get; set; }
        public string GuncelleyenKullaniciId { get; set; }
    }
}
