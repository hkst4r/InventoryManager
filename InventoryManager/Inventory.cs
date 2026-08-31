using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    internal class Inventory
    {

        public List<Product> _inventory = new List<Product>();

        public void AddToInventory()
        {
            Console.Write("Name: ");
            string Name = Console.ReadLine()??"";
            if (string.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Please enter a valid string");
                return;
            }

            Console.Write("Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal Price) == false)
            {
                Console.WriteLine("Please enter a valid decimal");
                return;
            }

            Console.Write("Amount: ");
            if (int.TryParse(Console.ReadLine(), out int Amount))
            {
                _inventory.Add(new Product(Name, Price, Amount));
            }

            


        }


        public void ViewProducts()
        {
            Console.WriteLine("---Inventory---\n\n");
            decimal totalValue = 0;

            foreach (Product i in _inventory)
            {
                Console.WriteLine($"Product: {i.Name}");
                Console.WriteLine($"Price: EUR{i.Price}");
                Console.WriteLine($"Quantity: {i.Quantity}");
                decimal stockValue = i.Price * i.Quantity;
                Console.WriteLine($"Total stock value: {stockValue}\n\n");

                totalValue += stockValue;

            }

            Console.WriteLine($"\n\nTotal Inventory Value: EUR{totalValue}");
        
        }


        public void UpdateProductStock()
        {

            Console.Write("Enter product name:");
            string productToUpdate = Console.ReadLine()??"";

            foreach(Product p in _inventory)
            {
                if (p.Name.ToLower() == productToUpdate.ToLower())
                {
                    Console.WriteLine($"Current quantity for {p.Name}: {p.Quantity}");
                    Console.Write("Enter new quantity: ");


                    if (int.TryParse(Console.ReadLine(), out int updateQuantity) && updateQuantity >= 0)
                    {
                        p.Quantity = updateQuantity;
                        Console.WriteLine("Quantity updated successfully");
                        
                    }

                    else
                    {
                        Console.WriteLine("Quantity is invalid");
                    }


                    return;

                }
            }

            Console.WriteLine("Product not found");
            return;

  

        }

        public void RemoveProduct()
        {
            int count = 1;
            Console.WriteLine("--- Product List ---\n");
            foreach(Product i in _inventory)
            {
                Console.WriteLine($"{count}. {i.Name}");
                count += 1;
            }



            Console.Write("\n\nEnter the product name you want to remove:");
            string toRemove = Console.ReadLine() ?? "";

            Product? productToRemove = null;

            foreach (Product product in _inventory)
            {
                if (product.Name.Equals(toRemove, StringComparison.OrdinalIgnoreCase))
                {
                    productToRemove = product;
                    break;                    

                }


            }


            if (productToRemove != null)
            {
                _inventory.Remove(productToRemove);
            }


            else
            {
                Console.WriteLine("Product not found or invalid input");

            }

        }

            
    
        


        public void mostValuableProduct()
        {
            decimal HighestValue = _inventory[0].Price;

            foreach (Product inv in _inventory)
            {
                if (inv.Price > HighestValue)
                {
                    HighestValue = inv.Price;
                }
            }
        
        
        }
    }
}
