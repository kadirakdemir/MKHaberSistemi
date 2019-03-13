using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    public partial class EmailAyarlari:AudiTableEntity
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public virtual ApplicationUser Kullanici { get; set; }
    }
}
