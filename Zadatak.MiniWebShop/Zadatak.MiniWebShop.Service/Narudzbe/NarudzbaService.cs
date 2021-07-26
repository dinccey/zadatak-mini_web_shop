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
        private readonly Kosarica _kosarica;
        private readonly NarudzbaDomainService _narudzbaDomainService;



        public NarudzbaService(IUnitOfWork unitOfWork, INarudzbaRepository narudzbaRepository, NarudzbaDomainService narudzbaDomainService, Kosarica kosarica)
        {
            _unitOfWork = unitOfWork;
            _narudzbaRepository = narudzbaRepository;
            _kosarica = kosarica;
            _narudzbaDomainService = narudzbaDomainService;
        }
        public async Task CreateNarudzbaAsync(CreateNarudzbaDto dto)
        {
            var narudzba = NarudzbaLogic(dto);

            await _narudzbaRepository.CreateNarudzbaAsync(narudzba.Result);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Narudzba> PreviewNarudzbaAsync(CreateNarudzbaDto dto)
        {
            var narudzba = NarudzbaLogic(dto);
            await _unitOfWork.CommitAsync();
            return narudzba.Result;
        }

        public async Task<IEnumerable<NacinPlacanja>> GetAllNacinPlacanjaAsync()
        {
            IEnumerable<NacinPlacanja> nacinPlacanjas = await _narudzbaDomainService.GetNacinPlacanjasAsync();
            return nacinPlacanjas;
        }

        private async Task<Narudzba> NarudzbaLogic(CreateNarudzbaDto dto)
        {
            Narudzba narudzba;
            var discount = await _narudzbaDomainService.GetDiscountIdAsync(dto.DiscountCode);
            if (dto.PaymentMethodId == 1)
            {
                narudzba = await _narudzbaDomainService.CreateNarudzbaAsync(dto.CardNumber, dto.Email, dto.Phone, dto.DeliveryAddress, dto.Note, discount);
            }
            else
            {
                narudzba = await _narudzbaDomainService.CreateNarudzbaAsync(dto.Email, dto.Phone, dto.DeliveryAddress, dto.Note, discount);
            }

            narudzba.UkupnaCijenaBezP = 0;
            foreach (var item in _kosarica.Items)
            {
                narudzba.AddItem(item);
                narudzba.UkupnaCijenaBezP *= item.Cijena;
            }

            if (dto.DiscountCode != null)
            {
                var popust = _narudzbaDomainService.GetDiscountIdAsync(dto.DiscountCode);
                if (popust.Result != null)
                {
                    narudzba.UkupnaCijenaBezP = Decimal.Multiply((decimal)narudzba.UkupnaCijenaBezP, 1 - (decimal)popust.Result.Popust);
                    narudzba.Popust = await popust;
                }
            }
            narudzba.UkupnaCijenaSP = Decimal.Multiply((decimal)narudzba.UkupnaCijenaBezP, (decimal)1.25);

            return narudzba;
        }

        
    }
}
