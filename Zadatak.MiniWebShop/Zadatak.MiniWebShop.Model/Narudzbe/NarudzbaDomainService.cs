using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class NarudzbaDomainService
    {
        private readonly INarudzbaRepository _narudzbaRepository;
        private readonly IProizvodRepository _proizvodRepository;
        public NarudzbaDomainService(INarudzbaRepository narudzbaRepository, IProizvodRepository proizvodRepository)
        {
            _narudzbaRepository = narudzbaRepository;
            _proizvodRepository = proizvodRepository;
        }

        public async Task<Narudzba> CreateNarudzbaAsync(string cardNumber, string email, int phone, string deliveryAddress, string note, int discountId)
        {
            var narudzba = new Narudzba(cardNumber, email, phone, deliveryAddress, note, discountId);
            return narudzba;
        }
        public async Task<Proizvod> AddItemAsync(int id)
        {
            var item = _proizvodRepository.GetProizvodByIdAsync(id);
            return item.Result;
        }

        public async Task<KodPopust> GetDiscountIdAsync(int discountCodeId)
        {
            var kodPopust = _narudzbaRepository.GetPopustIdAsync(discountCodeId);
            return kodPopust.Result;
        }
        public async Task<IEnumerable<NacinPlacanja>> GetNacinPlacanjasAsync()
        {
            IEnumerable<NacinPlacanja> nacinPlacanjas = await _narudzbaRepository.GetAllNacinPlacanjaAsync();
            return nacinPlacanjas;
        }
    }
}
