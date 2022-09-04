using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using System.Collections.Generic;

namespace ASP.NETCoreIdentityCustom.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
    }
}
