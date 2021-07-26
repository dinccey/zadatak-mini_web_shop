using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Model.Proizvodi
{
    public class KosaricaDomainService
    {

        private readonly IProizvodRepository _proizvodRepository;
        public KosaricaDomainService(IProizvodRepository proizvodRepository)
        {
            _proizvodRepository = proizvodRepository;
        }



        public async Task<Kosarica> AddItemAsync(AddItemDto dto, Kosarica kosarica)
        {
            var proizvod = await _proizvodRepository.GetProizvodByIdAsync(dto.Id);
            kosarica.AddItem(proizvod);
            return kosarica;
        }
        public async Task<Kosarica> RemoveItemAsync(AddItemDto dto, Kosarica kosarica)
        {
            var proizvod = await _proizvodRepository.GetProizvodByIdAsync(dto.Id);
            kosarica.RemoveItem(proizvod);

            return kosarica;
        }

    }
}
