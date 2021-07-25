using Zadatak.MiniWebShop.Model.Proizvodi;
using Zadatak.MiniWebShop.Service.Narudzbe;

namespace Zadatak.MiniWebShop.Service.Proizvodi
{
    internal class KosaricaDomainService
    {
        private readonly IProizvodRepository _proizvodRepository;
        public KosaricaDomainService(IProizvodRepository proizvodRepository)
        {
            _proizvodRepository = proizvodRepository;
        }

        public async Task<Proizvod> AddItemAsync(AddItemDto dto)
        {

        }
        public async Task<Proizvod> RemoveItemAsync(AddItemDto dto)
        {

        }
        public async Task<Kosarica> GetKosarica()
        {

        }
    }
}