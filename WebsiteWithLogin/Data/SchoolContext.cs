using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteWithLogin.Models;

namespace WebsiteWithLogin.Data
{
    public class SchoolContext : IdentityDbContext<StudentUser>
    {
        public DbSet<StudentUser> Students { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }
    }
}