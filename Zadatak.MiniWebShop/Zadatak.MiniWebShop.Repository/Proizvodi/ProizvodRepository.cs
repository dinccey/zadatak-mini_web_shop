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
        private readonly ShopDbContext _context;
        public ProizvodRepository(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
        {
            var brandovi = _context.Brandovi;
            return brandovi.ToList();
        }

        public async Task<IEnumerable<Proizvod>> GetAllProizvodAsync()
        {
            var proizvodi = _context.Proizvodi;
            return proizvodi.ToList();
        }

        public async Task<Proizvod> GetProizvodByIdAsync(int id)
        {
            var proizvod = await _context.Proizvodi
                .FirstOrDefaultAsync(p => p.Brand_Id == id);
            return proizvod;
        }
    }
}
