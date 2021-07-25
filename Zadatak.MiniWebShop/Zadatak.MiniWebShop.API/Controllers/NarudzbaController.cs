using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Service.Narudzbe;

namespace Zadatak.MiniWebShop.API.Controllers
{
    [Route("api/[narudzba]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        private readonly INarudzbaService _narudzbaService;

        public NarudzbaController(INarudzbaService narudzbaService)
        {
            _narudzbaService = narudzbaService;
        }


    }
}
