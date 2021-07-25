
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Infrastructure.Domain;
using Zadatak.MiniWebShop.Model.Proizvodi;
using Zadatak.MiniWebShop.Service.Narudzbe;

namespace Zadatak.MiniWebShop.Service.Proizvodi
{
    public class KosaricaService : IKosaricaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProizvodRepository _proizvodRepository;
        private readonly KosaricaDomainService _kosaricaDomainService;
        public KosaricaService()
        {

        }
        public Task AddItemAsync(AddItemDto dto)
        {
            throw new NotImplementedException();
        }

        public Task GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemAsync(AddItemDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
