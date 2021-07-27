using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Zadatak.MiniWebShop.Model.Proizvodi;
using Zadatak.MiniWebShop.Service.Proizvodi;

namespace Zadatak.MiniWebShop.API.Controllers
{
    
    [Route("api/proizvod")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly IProizvodService _proizvodService;

        public ProizvodController(IProizvodService proizvodService)
        {
            _proizvodService = proizvodService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Proizvod>> Get()
        {
            return await _proizvodService.GetAllProizvodAsync();
        }

        [HttpGet, Route("{id}")]
        public async Task<Proizvod> GetById(int id)
        {
            return await _proizvodService.GetProizvodById(id);
        }

    }
}
