using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MKHaberSistemi.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser<string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public virtual EmailAyarlari EmailAyarlari { get; set; }
        public virtual ICollection<Haber> Haberler { get; set; }
        public virtual ICollection<Yorum> Yorumlar { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
