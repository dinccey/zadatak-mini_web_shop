using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Repository.Proizvodi
{
    public class ProizvodRepository : IProizvodRepository
    {
        private readonly MiniWebShopContext _context;
        public ProizvodRepository(MiniWebShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            var brandovi = _context.Brands;
            return brandovi.ToList();
        }

        public async Task<IEnumerable<Proizvod>> GetAllProizvodAsync()
        {
            var proizvodi = _context.Proizvods;
            return proizvodi.ToList();
        }

        public async Task<Proizvod> GetProizvodByIdAsync(int id)
        {
            var proizvod = await _context.Proizvods
                .FirstOrDefaultAsync(p => p.Id == id);
            return proizvod;
        }
    }
}
