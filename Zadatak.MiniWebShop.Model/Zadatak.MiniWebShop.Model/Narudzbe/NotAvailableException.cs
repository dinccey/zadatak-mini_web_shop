using System;
using System.Runtime.Serialization;

namespace Zadatak.MiniWebShop.Model.Narudzbe
{
    [Serializable]
    internal class NotAvailableException : Exception
    {
    

        public NotAvailableException() : base("Product not available anymore.")
        {
        }
        public string Code { get; private set; }
        
    }
}