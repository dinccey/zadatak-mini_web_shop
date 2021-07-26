using System;
using System.Collections.Generic;
using Zadatak.MiniWebShop.Model.Narudzbe;

namespace Zadatak.MiniWebShop.Service.Narudzbe
{
    public class CreateNarudzbaDto
    {
        public List<Model.Proizvodi.Proizvod> Items { get; set; }
        public DateTime Date { get;  set; }
        public decimal PriceTotalTaxed { get;  set; }
        public decimal PriceTotal { get;  set; }
        public int DiscountCodeId { get;  set; }
        public int PaymentMethodId { get;  set; }
        public string CardNumber { get;  set; }
        public string Email { get;  set; }
        public int Phone { get;  set; }
        public string DeliveryAddress { get; set; }
        public string Note { get; set; }

        public string DiscountCode { get; set; }
    }
}