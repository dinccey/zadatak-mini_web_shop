using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Model.Proizvodi
{
    public interface IProizvodRepository
    {
        Task<IEnumerable<Proizvod>> GetAllProizvodAsync();
        Task<Proizvod> GetProizvodByIdAsync(int id);
    }
}
