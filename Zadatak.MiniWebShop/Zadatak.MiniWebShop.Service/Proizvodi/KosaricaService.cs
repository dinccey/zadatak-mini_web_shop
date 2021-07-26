
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
        
        
        public KosaricaService(KosaricaDomainService kosaricaDomainService)
        {
            _kosaricaDomainService = kosaricaDomainService;
        }
        public async Task<Kosarica> AddItemAsync(AddItemDto dto, Kosarica kosaricaDto)
        {
            return await _kosaricaDomainService.AddItemAsync(dto, kosaricaDto);
            

        }

       

        public async Task<Kosarica> RemoveItemAsync(AddItemDto dto, Kosarica kosaricaDto)
        {
            return await _kosaricaDomainService.RemoveItemAsync(dto, kosaricaDto);
            
        }
    }
}
