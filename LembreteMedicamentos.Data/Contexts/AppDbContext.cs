using LembreteMedicamentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LembreteMedicamentos.Domain.Entities;

namespace LembreteMedicamentos.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Idoso> Idosos { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Lembrete> Lembretes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Idoso>()
                .HasMany(i => i.Lembretes)
                .WithOne(l => l.Idoso)
                .HasForeignKey(l => l.IdosoId);

            modelBuilder.Entity<Medicamento>()
                .HasMany<Lembrete>()
                .WithOne(l => l.Medicamento)
                .HasForeignKey(l => l.MedicamentoId);
        }
    }
}


