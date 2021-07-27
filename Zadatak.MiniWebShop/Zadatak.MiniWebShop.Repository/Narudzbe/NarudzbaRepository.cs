using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Repository.Narudzbe
{
    public class NarudzbaRepository : INarudzbaRepository
    {
        private readonly MiniWebShopContext _context;
        public NarudzbaRepository(MiniWebShopContext context, Kosarica kosarica)
        {
            _context = context;
            _kosarica = kosarica;
        }

        private Kosarica _kosarica;
        

        public async Task<Narudzba> CreateNarudzbaAsync(Narudzba narudzba)
        {

            _context.Narudzbas.Add(narudzba);
            if(narudzba.Popust != null)
            {
                narudzba.Popust.Iskoristen = 1;
                _context.PopustKodovis
                    .Update(narudzba.Popust);
            }

            await _context.SaveChangesAsync();

            
            NarudzbaProizvodi narudzbaProizvodi = new NarudzbaProizvodi();
            narudzbaProizvodi.Narudzbaid = narudzba.Id;
            foreach (var item in narudzba.Items)
            {
                item.Kolicina = item.Kolicina - 1;
                narudzbaProizvodi.Proizvodid = item.Id;
                _context.NarudzbaProizvodis.Add(narudzbaProizvodi);
                _context.Proizvods.Update(item);
                _context.SaveChanges();
            }

            
            return narudzba;
        }

        public async Task<IEnumerable<NacinPlacanja>> GetAllNacinPlacanjaAsync()
        {
            IEnumerable<NacinPlacanja> nacinPlacanjas = _context.NacinPlacanjas;
            return  nacinPlacanjas.ToList();
        }

        public async Task<PopustKodovi> GetPopustIdAsync(string discountCode)
        {

            var popust = from p in _context.PopustKodovis where
                         p.Iskoristen != 0 && p.Kod == discountCode
                         select p;

            return popust.FirstOrDefault();
        }
    }
}
