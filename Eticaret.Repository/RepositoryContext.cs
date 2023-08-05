using Eticaret.Model;
using Eticaret.Model.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eticaret.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<V_AktifKullanicilar>().HasNoKey();
            modelBuilder.Entity<Kullanici>().Property(d => d.KayitTarih).HasDefaultValue();
        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KategoriAnasayfa> AnasayfaKategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunKategori> UrunKategoriler { get; set; }
        public DbSet<V_AktifKullanicilar> AktifKullanicilar { get; set; }
    }
}
