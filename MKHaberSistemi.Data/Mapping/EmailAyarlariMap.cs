using MKHaberSistemi.Core.Domain.Entities;

namespace MKHaberSistemi.Data.Mapping
{
    public class EmailAyarlariMap:BaseEntityMap<EmailAyarlari>
    {
        public EmailAyarlariMap()
        {
            this.ToTable("EmailAyarlari", "library");
            
           
        }
    }
}
