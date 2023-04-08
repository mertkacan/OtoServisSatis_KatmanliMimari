using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Data
{
    public class DatabaseContext : DbContext
    {

        // Sınıfları görmesi için Entities katmanından "Add Project Referance" diyerek Referans alındı.
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        // Veritabanı ayarlarını yapılandırmak için override tab tab yapılarak kodlama yapılır.
        // ConnectionString ifadelerimizi burada belirttik.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =.; database = OtoServisDb; trusted_connection = true");
            base.OnConfiguring(optionsBuilder);
        }

        // SeedData işlemleri yaptık. FluentAPI işlemleri yaptık .
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marka>().Property(x=>x.Adi).HasMaxLength(30).IsRequired();

            modelBuilder.Entity<Rol>()
          .HasData(
         new Rol() { Id = 1, Adi = "Admin" }
         );

            modelBuilder.Entity<Kullanici>()
       .HasData(
      new Kullanici()
      {
          Id = 1,
          Adi = "Admin",
          Soyadi="admin",
          Telefon="0850",
          AktifMi = true,
          Email = "admin@otoservissatis.tc",
          KullaniciAdi = "admin",
          Sifre = "123456",
          Rol = new Rol { Id = 1 },
          RolId = 1
      });
        }
    }
}
