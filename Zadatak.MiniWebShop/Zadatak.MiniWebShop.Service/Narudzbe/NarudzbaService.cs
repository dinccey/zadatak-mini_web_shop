//using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop;
using Zadatak.MiniWebShop.Infrastructure.Domain;
using Zadatak.MiniWebShop.Model.Narudzbe;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Service.Narudzbe
{
    public class NarudzbaService : INarudzbaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INarudzbaRepository _narudzbaRepository;
        private readonly IProizvodRepository _proizvodRepository;
        private readonly NarudzbaDomainService _narudzbaDomainService;

        public NarudzbaService(IUnitOfWork unitOfWork, INarudzbaRepository narudzbaRepository, NarudzbaDomainService narudzbaDomainService, IProizvodRepository proizvodRepository)
        {
            _unitOfWork = unitOfWork;
            _narudzbaRepository = narudzbaRepository;
            _proizvodRepository = proizvodRepository;
            _narudzbaDomainService = narudzbaDomainService;
        }
        public async Task CreateNarudzbaAsync(CreateNarudzbaDto dto)
        {
            var narudzba = await _narudzbaDomainService.CreateNarudzbaAsync(dto.CardNumber, dto.Email, dto.Phone, dto.DeliveryAddress, dto.Note);
            await _narudzbaRepository.CreateNarudzbaAsync(narudzba);
            await _unitOfWork.CommitAsync();
        }
        public async Task AddItemAsync(AddItemDto dto)
        {
            var proizvod = await _narudzbaDomainService.AddItemAsync(dto.Id);
            await _narudzbaRepository.AddItemAsync(proizvod);
            await _unitOfWork.CommitAsync();
        }
    }
}
