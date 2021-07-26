using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;
using Zadatak.MiniWebShop.Service.Narudzbe;

namespace Zadatak.MiniWebShop.Service.Proizvodi
{
    public interface IKosaricaService
    {
        Task<Kosarica> AddItemAsync(AddItemDto dto, Kosarica kosaricaDto);
        Task<Kosarica> RemoveItemAsync(AddItemDto dto, Kosarica kosaricaDto);
        
    }
}
