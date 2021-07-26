using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Repository
{
    public partial class MiniWebShopContext : DbContext
    {
        public MiniWebShopContext()
        {
        }

        public MiniWebShopContext(DbContextOptions<MiniWebShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<NacinPlacanja> NacinPlacanjas { get; set; }
        public virtual DbSet<Narudzba> Narudzbas { get; set; }
        public virtual DbSet<NarudzbaProizvodi> NarudzbaProizvodis { get; set; }
        public virtual DbSet<PopustKodovi> PopustKodovis { get; set; }
        public virtual DbSet<Proizvod> Proizvods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=MiniWebShop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("BRAND");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("NAZIV")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<NacinPlacanja>(entity =>
            {
                entity.ToTable("NACIN_PLACANJA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAZIV");
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.ToTable("NARUDZBA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdresaDostave)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ADRESA_DOSTAVE");

                entity.Property(e => e.BrojKartice)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BROJ_KARTICE");

                entity.Property(e => e.BrojMobitela).HasColumnName("BROJ_MOBITELA");

                entity.Property(e => e.Datum)
                    .HasColumnType("datetime")
                    .HasColumnName("DATUM");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.KodZaPopustId).HasColumnName("KOD_ZA_POPUST_ID");

                entity.Property(e => e.NacinPlacanjaId).HasColumnName("NACIN_PLACANJA_ID");

                entity.Property(e => e.Napomena)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NAPOMENA");

                entity.Property(e => e.UkupnaCijenaBezP)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("UKUPNA_CIJENA_BEZ_P");

                entity.Property(e => e.UkupnaCijenaSP)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("UKUPNA_CIJENA_S_P");

                entity.HasOne(d => d.KodZaPopust)
                    .WithMany(p => p.Narudzbas)
                    .HasForeignKey(d => d.KodZaPopustId)
                    .HasConstraintName("FK_NARUDZBA_POPUST_KODOVI");

                entity.HasOne(d => d.NacinPlacanja)
                    .WithMany(p => p.Narudzbas)
                    .HasForeignKey(d => d.NacinPlacanjaId)
                    .HasConstraintName("FK_NARUDZBA_NACIN_PLACANJA");
            });

            modelBuilder.Entity<NarudzbaProizvodi>(entity =>
            {
                entity.ToTable("NARUDZBA_PROIZVODI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Narudzbaid).HasColumnName("NARUDZBAID");

                entity.Property(e => e.Proizvodid).HasColumnName("PROIZVODID");

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.NarudzbaProizvodis)
                    .HasForeignKey(d => d.Narudzbaid)
                    .HasConstraintName("FK_NARUDZBA_PROIZVODI_NARUDZBA");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.NarudzbaProizvodis)
                    .HasForeignKey(d => d.Proizvodid)
                    .HasConstraintName("FK_NARUDZBA_PROIZVODI_PROIZVOD");
            });

            modelBuilder.Entity<PopustKodovi>(entity =>
            {
                entity.ToTable("POPUST_KODOVI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Iskoristen).HasColumnName("ISKORISTEN");

                entity.Property(e => e.Kod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KOD");

                entity.Property(e => e.Popust)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("POPUST");
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.ToTable("PROIZVOD");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandId).HasColumnName("BRAND_ID");

                entity.Property(e => e.Cijena)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cijena");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.NarudzbaId).HasColumnName("NARUDZBA_ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("naziv")
                    .IsFixedLength(true);

                entity.Property(e => e.Opis)
                    .HasMaxLength(100)
                    .HasColumnName("opis")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Proizvods)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_PROIZVOD_BRAND");

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.Proizvods)
                    .HasForeignKey(d => d.NarudzbaId)
                    .HasConstraintName("FK_PROIZVOD_NARUDZBA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}