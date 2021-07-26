using System.Collections.Generic;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class PopustKodovi
    {
        public PopustKodovi()
        {
            Narudzbas = new HashSet<Narudzba>();
        }

        public int Id { get; set; }
        public string Kod { get; set; }
        public decimal? Popust { get; set; }
        public byte? Iskoristen { get; set; }

        public virtual ICollection<Narudzba> Narudzbas { get; set; }
    }
}