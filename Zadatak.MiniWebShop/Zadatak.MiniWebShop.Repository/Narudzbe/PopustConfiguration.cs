using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.Repository.Narudzbe
{
    public class PopustConfiguration : IEntityTypeConfiguration<KodPopust>
    {
        public void Configure(EntityTypeBuilder<KodPopust> builder)
        {
            builder.ToTable("Popust_kodovi");
        }
    }
}
