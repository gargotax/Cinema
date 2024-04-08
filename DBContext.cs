using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cinema
{
    internal class DBContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Realisateur> Realisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = HP\\SQLEXPRESS;Database=cinema; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(f => f.SalleNavigation)
                    .WithMany(s => s.Films)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasForeignKey(f => f.SalleId);

                entity.HasOne(f => f.RealisateurNavigation)
                .WithMany(r => r.FilmsRealises)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(f => f.IdRealisateur);
            }); 
                


        }

    }
}
