using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Infrastructure.Domain;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Service.Proizvodi
{
    public class ProizvodService : IProizvodService
    {
        private readonly ProizvodDomainService _proizvodDomainService;
        //private readonly IUnitOfWork _unitOfWork;
        public ProizvodService(ProizvodDomainService proizvodDomainService)
        {
            _proizvodDomainService = proizvodDomainService;
        }
        public async Task<IEnumerable<Proizvod>> GetAllProizvodAsync()
        {
            IEnumerable<Proizvod> proizvods = await _proizvodDomainService.GetAllProizvodAsync();
            return proizvods;
        }

        public async Task<Proizvod> GetProizvodById(int id)
        {
            var proizvod = await _proizvodDomainService.GetProizvodByIdAsync(id);
            return proizvod;
        }
    }
}
