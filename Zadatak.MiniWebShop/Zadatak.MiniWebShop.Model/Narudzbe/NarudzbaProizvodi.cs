using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class NarudzbaProizvodi
    {
        public int Id { get; set; }
        public int? Narudzbaid { get; set; }
        public int? Proizvodid { get; set; }
        [ForeignKey("NarudzbaId")]
        public virtual Narudzba Narudzba { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
