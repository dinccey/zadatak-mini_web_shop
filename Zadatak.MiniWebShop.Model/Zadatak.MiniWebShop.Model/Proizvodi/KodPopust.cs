namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class KodPopust
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public decimal Discount { get; private set; }
        public bool Used { get; private set; }
    }
}