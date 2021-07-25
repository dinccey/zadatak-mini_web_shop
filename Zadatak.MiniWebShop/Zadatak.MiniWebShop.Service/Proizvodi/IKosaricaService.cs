using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Service.Narudzbe;

namespace Zadatak.MiniWebShop.Service.Proizvodi
{
    public interface IKosaricaService
    {
        Task AddItemAsync(AddItemDto dto);
        Task RemoveItemAsync(AddItemDto dto);
        Task GetAllItemsAsync();
    }
}
