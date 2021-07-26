using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.Model.Proizvodi
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            NarudzbaProizvodis = new HashSet<NarudzbaProizvodi>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal? Cijena { get; set; }
        public int? Kolicina { get; set; }
        public int? BrandId { get; set; }
        public int? NarudzbaId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Narudzba Narudzba { get; set; }
        public virtual ICollection<NarudzbaProizvodi> NarudzbaProizvodis { get; set; }
    }
}
