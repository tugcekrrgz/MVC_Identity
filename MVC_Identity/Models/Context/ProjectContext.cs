using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_Identity.Models.Entity;

namespace MVC_Identity.Models.Context
{
    public class ProjectContext:IdentityDbContext<AppUser>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)//dependdency injection
        {

        }
    }
}
