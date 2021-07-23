using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class Narudzba
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public decimal PriceTotalTaxed { get; private set; }
        public decimal PriceTotal { get; private set; }
        public KodPopust DiscountCode { get; private set; }
        public NacinPlacanja PaymentMethod { get; private set; }
    }
}
