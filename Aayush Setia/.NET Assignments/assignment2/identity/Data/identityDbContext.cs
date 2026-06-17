using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identity.Data
{
    public class identityDbContext : IdentityDbContext<identityUser>
    {
        public identityDbContext(
            DbContextOptions<identityDbContext> options)
            : base(options)
        {

        }
    }
}