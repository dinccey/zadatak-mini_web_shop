using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Model.Proizvodi
{
    public class Proizvod
    {
      
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityAvailable { get; private set; }
        public int QuantityDesired { get; private set; }
        public Brand Brand { get; private set; }
    }
}
