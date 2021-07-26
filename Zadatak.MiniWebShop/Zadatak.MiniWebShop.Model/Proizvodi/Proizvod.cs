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
        public string Naziv { get; private set; }
        public string Opis { get; private set; }
        public decimal Cijena { get; private set; }
        public int Kolicina { get; private set; }
      
        public int Brand_Id { get; private set; }
    }
}
