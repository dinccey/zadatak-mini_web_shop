using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.Repository.Narudzbe
{
    public class NarudzbaConfiguration : IEntityTypeConfiguration<Narudzba>
    {
        public void Configure(EntityTypeBuilder<Narudzba> builder)
        {
            builder.ToTable("Narudzba");
        }
    }
}
