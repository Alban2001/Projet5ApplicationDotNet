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
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasNoKey();
        }
    }
}
