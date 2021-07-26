using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Service.Narudzbe
{
    public interface INarudzbaService
    {
        Task CreateNarudzbaAsync(CreateNarudzbaDto dto);
        Task SetKosarica(Kosarica kosarica);
    }
}