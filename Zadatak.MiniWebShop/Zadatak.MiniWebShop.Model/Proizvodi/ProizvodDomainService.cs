using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Model.Proizvodi
{
    public class ProizvodDomainService
    {
        private readonly IProizvodRepository _proizvodRepository;
        public ProizvodDomainService(IProizvodRepository proizvodRepository)
        {
            _proizvodRepository = proizvodRepository;
        }

        public async Task<Proizvod> GetProizvodByIdAsync(int id)
        {
            var item = _proizvodRepository.GetProizvodByIdAsync(id);
            return item.Result;
        }
        public async Task<IEnumerable<Proizvod>> GetAllProizvodAsync()
        {
            IEnumerable<Proizvod> proizvods = await _proizvodRepository.GetAllProizvodAsync();
            return proizvods;
        }
    }
}
