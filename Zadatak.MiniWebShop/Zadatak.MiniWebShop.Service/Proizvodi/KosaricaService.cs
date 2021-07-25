
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Infrastructure.Domain;
using Zadatak.MiniWebShop.Model.Proizvodi;
using Zadatak.MiniWebShop.Service.Proizvodi;

namespace Zadatak.MiniWebShop.Service.Proizvodi
{
    public class KosaricaService : IKosaricaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProizvodRepository _proizvodRepository;
        private readonly KosaricaDomainService _kosaricaDomainService;
        private Kosarica kosarica;
        
        public KosaricaService()
        {

        }
        public async Task AddItemAsync(AddItemDto dto, Kosarica kosaricaDto)
        {
            kosarica = await _kosaricaDomainService.AddItemAsync(dto, kosaricaDto);
            
        }

        public async Task CreateKosarica()
        {
            kosarica = await _kosaricaDomainService.CreateKosaricaAsync();
        }

        public async Task RemoveItemAsync(AddItemDto dto, Kosarica kosaricaDto)
        {
            kosarica = await _kosaricaDomainService.RemoveItemAsync(dto, kosaricaDto);
        }
    }
}
