using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet5ApplicationDotNet.Areas.Identity.Data;

namespace Projet5ApplicationDotNet.Data;

public class Projet5ApplicationDotNetContext : IdentityDbContext<Projet5ApplicationDotNetUser>
{
    public Projet5ApplicationDotNetContext(DbContextOptions<Projet5ApplicationDotNetContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
