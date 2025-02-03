using AspDotNetMVC.Data.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetMVC.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Company> Companies { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
