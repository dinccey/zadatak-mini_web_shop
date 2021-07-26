namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    public class KodPopust
    {
        public int Id { get; private set; }
        public string Kod { get; private set; }
        public decimal Popust { get; private set; }
        public bool Iskoristen { get; private set; }
    }
}