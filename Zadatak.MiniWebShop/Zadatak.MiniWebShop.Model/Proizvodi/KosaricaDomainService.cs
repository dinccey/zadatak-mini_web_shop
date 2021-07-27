using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Model.Proizvodi
{
    public class KosaricaDomainService
    {

        private readonly IProizvodRepository _proizvodRepository;
        private Kosarica _kosarica;
        public KosaricaDomainService(IProizvodRepository proizvodRepository,Kosarica kosarica)
        {
            _proizvodRepository = proizvodRepository;
            _kosarica = kosarica;
        }



        public async Task AddItemAsync(AddItemDto dto)
        {
            var proizvod = await _proizvodRepository.GetProizvodByIdAsync(dto.Id);
            _kosarica.AddItem(proizvod);
            
        }
        public async Task RemoveItemAsync(AddItemDto dto)
        {
            var proizvod = await _proizvodRepository.GetProizvodByIdAsync(dto.Id);
            _kosarica.RemoveItem(proizvod);

           
        }

    }
}
