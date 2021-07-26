using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Service.Proizvodi
{
    public interface IProizvodService
    {
        Task<IEnumerable<Proizvod>> GetAllProizvodAsync();
        Task<Proizvod> GetProizvodById(int id);
    }
}
