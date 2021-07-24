using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.Model.Proizvodi
{
    public class Kosarica
    {
        public Kosarica()
        {

        }
        private readonly List<Proizvod> _items = new List<Proizvod>();
        public IReadOnlyCollection<Proizvod> Items => _items;
        public void AddItem(Proizvod item)
        {
            if (item.QuantityAvailable == 0)
            {
                throw new NotAvailableException();
            }
            _items.Add(item);
        }
        public void RemoveItem(Proizvod item)
        {
            if (_items.Contains(item)) _items.Remove(item);
        }
    }
}
