using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.Repository.Narudzbe
{
    public class NarudzbaProizvodiConfiguration : IEntityTypeConfiguration<NarudzbaProizvodi>
    {
        public void Configure(EntityTypeBuilder<NarudzbaProizvodi> builder)
        {
            builder.ToTable("Narudzba_proizvodi");
        }
    }
}
