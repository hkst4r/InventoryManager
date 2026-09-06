using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public class Inventory
    {

        private readonly List<Product> _inventory = new List<Product>();
        public IReadOnlyList<Product> Products => _inventory;

        public bool AddToInventory(string name, decimal price, int amount)
        {


            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter a valid string.");
                return false;
            }

            if(price <= 0)
            {
                Console.WriteLine("Price should be greater than 0.");
                return false;
            }

            if(amount <= 0)
            {
                Console.WriteLine("Amount should be greater than 0.");
                return false;
            }

            _inventory.Add(new Product(name, price, amount));
            return true;
            

            


        }


        public void ViewProducts()
        {
            decimal totalValue = 0;

            foreach (Product i in _inventory)
            {
                Console.WriteLine($"Product: {i.Name}");
                Console.WriteLine($"Price: EUR {i.Price}");
                Console.WriteLine($"Quantity: {i.Quantity}");
                decimal stockValue = i.Price * i.Quantity;
                Console.WriteLine($"Total stock value: EUR {stockValue}\n\n");

                totalValue += stockValue;
                Thread.Sleep(300);


            }

            Console.WriteLine($"\n\nTotal Inventory Value: EUR{totalValue}");
        
        }


        public bool UpdateProductStock(string name, int newQuantity)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter a valid string.");
                return false;
            }

            if (newQuantity <= 0)
            {
                Console.WriteLine("Quantity should be greater than 0.");
                return false;
            }

            foreach (Product p in Products)
            {
                if (p.Name.ToLower() == name.ToLower())
                {
                    p.Quantity = newQuantity;
                    Console.WriteLine($"{name} quantity successfully updated.");
                    return true;

                }

            }

            Console.WriteLine($"{name} not found.");
            return false;



        }

        public bool RemoveProduct(string toRemove)
        {
            
            if (string.IsNullOrWhiteSpace(toRemove))
            {
                Console.WriteLine("Invalid input");
                return false;
            }


            

            Product? productToRemove = null;

            foreach (Product product in _inventory)
            {
                if (product.Name.Equals(toRemove, StringComparison.OrdinalIgnoreCase))
                {
                    productToRemove = product;
                         

                }


            }


            if (productToRemove != null)
            {
                _inventory.Remove(productToRemove);
                Console.WriteLine($"{productToRemove.Name} successfully removed");
                return true;
            }


            else
            {
                Console.WriteLine("Product not found or invalid input");
                return false;

            }

        }

            
    
        


        public Product? MostValuableProduct()
        {
            if(_inventory.Count > 0)
            {

                decimal highestValue = (_inventory[0].Price * _inventory[0].Quantity);
                Product highestValueProduct = _inventory[0];
                foreach (Product prd in _inventory)
                {
                    decimal productValue = (prd.Price * prd.Quantity);
                    if (productValue > highestValue)
                    {
                        highestValue = productValue;
                        highestValueProduct = prd;
                    }

                }

                return highestValueProduct;
            }

            else
            {
                return null;
            }
        
        
        }
    }
}
