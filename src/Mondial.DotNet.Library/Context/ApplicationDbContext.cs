using System;
using Mondial.DotNet.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Mondial.DotNet.Library.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Collection des objets du modèle
        public DbSet<Contract> ContractCollection { get; set; }
        public DbSet<Player> PlayerCollection { get; set; }
        public DbSet<Team> TeamCollection { get; set; }

        // Constructeur avec signature obligatoire
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Préciser les tables et relations du modèle
            modelBuilder.Entity<Team>().ToTable(nameof(Team));
            modelBuilder.Entity<Player>().ToTable(nameof(Player));
            // Relation Contract & Player
            modelBuilder.Entity<Contract>()
                .ToTable(nameof(Contract))
                .HasOne(c => c.Signatory)
                .WithMany(p => p.ContractCollection)
                .HasForeignKey(c => c.SignatoryId)
                .OnDelete(DeleteBehavior.SetNull);
            // Relation Contract & Team
            modelBuilder.Entity<Contract>()
                .ToTable(nameof(Contract))
                .HasOne(c => c.Employer)
                .WithMany(t => t.ContractCollection)
                .HasForeignKey(c => c.EmployerId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}