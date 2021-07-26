using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.Repository.Narudzbe
{
    public class NacinPlacanjaConfiguration : IEntityTypeConfiguration<NacinPlacanja>
    {
        public void Configure(EntityTypeBuilder<NacinPlacanja> builder)
        {
            builder.ToTable("Nacin_placanja");
        }
    }
}
