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

        public Narudzba(string cardNumber, string email, int phone, string deliveryAddress, string note)
        {
            Date = DateTime.Now;
            CardNumber = cardNumber;
            Email = email;
            Phone = phone;
            DeliveryAddress = deliveryAddress;
            Note = note;
        }
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public decimal PriceTotalTaxed { get; private set; }
        public decimal PriceTotal { get; private set; }
        public KodPopust DiscountCode { get; private set; }
        public NacinPlacanja PaymentMethod { get; private set; }
        public string CardNumber { get; private set; }
        public string Email { get; private set; }
        public int Phone { get; private set; }
        public string DeliveryAddress { get; private set; }
        public string Note { get; private set; }

        public IReadOnlyCollection<Proizvod> Items => _items;

        public void AddItem(Proizvod item)
        {
            if(item.QuantityAvailable == 0)
            {
                throw new NotAvailableException();
            }
            _items.Add(item);
        }

    }
}
