using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Service.Narudzbe
{
    public interface INarudzbaService
    {
        Task CreateNarudzbaAsync(CreateNarudzbaDto dto);
    }
}