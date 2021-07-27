
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
        public async Task AddItemAsync(AddItemDto dto)
        {
            await _kosaricaDomainService.AddItemAsync(dto);
            

        }

       

        public async Task RemoveItemAsync(AddItemDto dto)
        {
            await _kosaricaDomainService.RemoveItemAsync(dto);
            
        }
    }
}
