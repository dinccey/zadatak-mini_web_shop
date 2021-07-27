using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;
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
            
            
            return _kosarica;
        }

        [HttpPost, Route("kosarica/add")]
        public async Task KosaricaAdd(int id)
        {
            AddItemDto dto = new AddItemDto();
            dto.Id = id;
            await _kosaricaService.AddItemAsync(dto);
            
            

        }
        [HttpPost, Route("kosarica/remove")]
        public async Task KosaricaRemove(int id)
        {
            AddItemDto dto = new AddItemDto();
            dto.Id = id;
            _kosarica.RemoveItem(id);
            await _kosaricaService.RemoveItemAsync(dto);
            
        }

        [HttpPost, Route("nova_narudzba")]
        public async Task<OkResult> NarudzbaCreate([FromBody] CreateNarudzbaDto dto)
        {
            await _narudzbaService.CreateNarudzbaAsync(dto);
            return Ok();
        }
        [HttpGet,Route("nacin_placanja")]
        public async Task<IEnumerable<Model.Narudzbe.NacinPlacanja>> GetNacinPlacanja()
        {
            return await _narudzbaService.GetAllNacinPlacanjaAsync();
        }
        [HttpPost,Route("preview")]
        public async Task<Narudzba> PreviewNarudzba([FromBody]CreateNarudzbaDto dto)
        {
            return await _narudzbaService.PreviewNarudzbaAsync(dto);
            
        }

    }
}
