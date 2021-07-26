using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Repository.Narudzbe
{
    public class NarudzbaRepository : INarudzbaRepository
    {
        private Kosarica _kosarica;
        public Task<int> AddItemAsync(Proizvod proizvod)
        {
            throw new NotImplementedException();
        }

        public async Task<Narudzba> CreateNarudzbaAsync(Narudzba narudzba, Kosarica kosarica)
        {
            _kosarica = kosarica;

            return narudzba;
        }

        public Task<IEnumerable<NacinPlacanja>> GetAllNacinPlacanjaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PopustKodovi> GetPopustIdAsync(int discountCodeId)
        {
            throw new NotImplementedException();
        }
    }
}
