using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backendgema.Models
{
    public class Koneksi:DbContext
    {
        public DbSet<JenisLokasi> JenisLokasis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VON2FNC; database=GemaWBP; integrated security=SSPI");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JenisLokasi>(e =>
            {
                e.HasKey(x => x.Jenis_Lokasi);
                e.Property(x => x.Keterangan).IsRequired();
            });

        }

    }
}
