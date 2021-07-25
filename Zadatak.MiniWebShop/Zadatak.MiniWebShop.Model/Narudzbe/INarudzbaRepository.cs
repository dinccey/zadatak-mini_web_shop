using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public interface INarudzbaRepository
    {
        Task<Narudzba> CreateNarudzbaAsync(Narudzba narudzba);
        Task<int> AddItemAsync(Proizvod proizvod);
    }
}
