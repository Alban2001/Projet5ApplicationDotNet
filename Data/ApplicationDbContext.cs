using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Projet5ApplicationDotNet.Models;
using System.Reflection.Metadata;

namespace Projet5ApplicationDotNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<ModeleVoiture> ModelesVoiture { get; set; }
        public DbSet<Reparation> Reparations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasNoKey();

            modelBuilder.Entity<Reparation>()
                .HasOne(e => e.UneVoiture)
                .WithMany(e => e.ListeReparation)
                .IsRequired(true);

            modelBuilder.Entity<Voiture>()
                .HasOne(e => e.UnModeleVoiture)
                .WithMany(e => e.ListeVoiture)
                .IsRequired(false);
        }
    }
}
