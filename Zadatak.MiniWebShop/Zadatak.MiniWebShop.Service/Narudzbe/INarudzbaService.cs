using System.Collections.Generic;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Service.Narudzbe
{
    public interface INarudzbaService
    {
        Task CreateNarudzbaAsync(CreateNarudzbaDto dto);
        Task<IEnumerable<NacinPlacanja>> GetAllNacinPlacanjaAsync();
        Task<Narudzba> PreviewNarudzbaAsync(CreateNarudzbaDto dto);


    }
}