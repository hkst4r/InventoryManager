using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    internal class Product
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        



        public Product(string Name, decimal Price, int Quantity)
        {
            name = Name;
            price = Price;
            quantity = Quantity;
        }
    }
}
