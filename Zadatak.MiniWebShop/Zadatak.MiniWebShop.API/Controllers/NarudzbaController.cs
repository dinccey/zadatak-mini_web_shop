using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;
using Zadatak.MiniWebShop.Service.Narudzbe;
using Zadatak.MiniWebShop.Service.Proizvodi;

namespace Zadatak.MiniWebShop.API.Controllers
{
    [Route("api/narudzba")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        private readonly INarudzbaService _narudzbaService;
        private readonly IKosaricaService _kosaricaService;
        private readonly IProizvodRepository _proizvodRepository;
        private static Kosarica _kosarica;
        public NarudzbaController(INarudzbaService narudzbaService, IKosaricaService kosaricaService, Kosarica kosarica)
        {
            
            _narudzbaService = narudzbaService;
            _kosaricaService = kosaricaService;

            _kosarica = kosarica;
        }

        [HttpGet,Route("kosarica")]
        public async Task<Kosarica> GetKosarica()
        {
            
            Console.WriteLine("GET");
            foreach (var item in _kosarica.Items)
            {
                Console.WriteLine("YES");
                Console.WriteLine(item.Naziv);
            }
            return _kosarica;
        }

        [HttpPost, Route("kosarica/add")]
        public async Task KosaricaAdd([FromBody] AddItemDto dto)
        {
            _kosarica = await _kosaricaService.AddItemAsync(dto, _kosarica);
            
            foreach (var item in _kosarica.Items)
            {
                Console.WriteLine("YES");
                Console.WriteLine(item.Naziv);
            }

        }
        [HttpPost, Route("kosarica/remove")]
        public async Task KosaricaRemove([FromBody] AddItemDto dto)
        {
            _kosarica = await _kosaricaService.RemoveItemAsync(dto, _kosarica);
            foreach (var item in _kosarica.Items)
            {
                Console.WriteLine("REMOVE");
                Console.WriteLine(item.Naziv);
            }
        }


    }
}
