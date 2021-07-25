using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Service.Narudzbe
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

        public async Task<Narudzba> CreateNarudzbaAsync(string cardNumber, string email, int phone, string deliveryAddress, string note)
        {
            var narudzba = new Narudzba(cardNumber, email, phone, deliveryAddress, note);
            return narudzba;
        }
        public async Task<Proizvod> AddItemAsync(int id)
        {
            var item = _proizvodRepository.GetProizvodByIdAsync(id);
            return item.Result;
        }
    }
}
