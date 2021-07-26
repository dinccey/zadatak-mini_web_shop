using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Proizvodi;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class Narudzba
    {
        private readonly List<Proizvod> _items = new List<Proizvod>();

        public Narudzba()
        {

        }
        public Narudzba(string cardNumber, string email, int phone, string deliveryAddress, string note, int discount_id)
        {
            Datum = DateTime.Now;
            Broj_Kartice = cardNumber;
            Email = email;
            Broj_Mobitela = phone;
            Adresa_Dostave = deliveryAddress;
            Napomena = note;
            Kod_Za_Popust_Id = discount_id;
        }
        public int Id { get; private set; }
        public DateTime Datum { get; private set; }
        public decimal Ukupna_Cijena_Bez_P { get; private set; }
        public decimal Ukupna_Cijena_S_P { get; private set; }
        public int Kod_Za_Popust_Id { get; private set; }
        public int Nacin_Placanja_Id { get; private set; }
        public string Broj_Kartice { get; private set; }
        public string Email { get; private set; }
        public int Broj_Mobitela { get; private set; }
        public string Adresa_Dostave { get; private set; }
        public string Napomena { get; private set; }

        public IReadOnlyCollection<Proizvod> Items => _items;

        public void AddItem(Proizvod item)
        {
            if(item.Kolicina == 0)
            {
                throw new NotAvailableException();
            }
            _items.Add(item);
        }

    }
}
