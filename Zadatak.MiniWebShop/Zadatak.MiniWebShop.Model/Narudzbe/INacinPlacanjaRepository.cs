using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public interface INacinPlacanjaRepository
    {
        Task<IEnumerable<NacinPlacanja>> GetAllNacinPlacanjaAsync();
        Task<NacinPlacanja> GetNacinPlacanjaByIdAsync(int id);
    }
}
