using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Projet5ApplicationDotNet.Areas.Identity.Data;
using Projet5ApplicationDotNet.Models;
using System.Reflection.Metadata;

namespace Projet5ApplicationDotNet.Data
{
    public class ApplicationDbContext : IdentityDbContext<Projet5ApplicationDotNetUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Reparation> Reparations { get; set; }
        public DbSet<Marque> Marques { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey }); 

                entity.HasOne<Projet5ApplicationDotNetUser>()
                      .WithMany()
                      .HasForeignKey(l => l.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade); 
            });
            modelBuilder.Entity<IdentityUserRole<string>>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId }); 
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name }); 

                entity.HasOne<Projet5ApplicationDotNetUser>()
                      .WithMany()
                      .HasForeignKey(t => t.UserId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
