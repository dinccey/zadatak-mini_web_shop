using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class Narudzba
    {
        [NotMapped]
        private readonly List<Proizvod> _items = new List<Proizvod>();


        public Narudzba(string cardNumber, string email, int phone, string deliveryAddress, string note, PopustKodovi discount)
        {
            Datum = DateTime.Now;
            BrojKartice = cardNumber;
            Email = email;
            BrojMobitela = phone;
            AdresaDostave = deliveryAddress;
            Napomena = note;
            KodZaPopust = discount;
        }
        public Narudzba()
        {
            NarudzbaProizvodis = new HashSet<NarudzbaProizvodi>();
        }

        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public decimal? UkupnaCijenaBezP { get; set; }
        public decimal? UkupnaCijenaSP { get; set; }
        public int? KodZaPopustId { get; set; }
        public int? NacinPlacanjaId { get; set; }
        public string BrojKartice { get; set; }
        public string Email { get; set; }
        public int? BrojMobitela { get; set; }
        public string AdresaDostave { get; set; }
        public string Napomena { get; set; }

        public virtual PopustKodovi KodZaPopust { get; set; }
        public virtual NacinPlacanja NacinPlacanja { get; set; }
        public virtual ICollection<NarudzbaProizvodi> NarudzbaProizvodis { get; set; }
        public virtual ICollection<Proizvod> Proizvods { get; set; }

        [NotMapped]
        public IReadOnlyCollection<Proizvod> Items => _items;

        public void AddItem(Proizvod item)
        {
            if (item.Kolicina == 0)
            {
                throw new NotAvailableException();
            }
            _items.Add(item);
        }

    }
}
