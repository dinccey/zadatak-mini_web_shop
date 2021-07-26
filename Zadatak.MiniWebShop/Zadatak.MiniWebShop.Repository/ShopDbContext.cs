using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Repository
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options): base(options)
        {

        }

        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Brand> Brandovi { get; set; }
        public DbSet<KodPopust> Kodovi { get; set; }
        public DbSet<NarudzbaProizvodi> Narudzba_Proizvodi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
        }
    }
}