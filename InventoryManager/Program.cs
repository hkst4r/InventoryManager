namespace InventoryManager {
    public class Program
    {
        
        public static void Main()
        {
            Inventory manager = new Inventory();
            while (true)
            {
                Console.WriteLine("\n---Menu--- \n");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product Stock");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. View Most Valuable Product");
                Console.WriteLine("6. View Products Under a Certain Stock Threshold");
                Console.WriteLine("7. View Products In Descending Order");
                Console.WriteLine("8. View Product Names");
                Console.WriteLine("9. Exit");
                Console.Write("\n\nEnter selection: ");



                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "1":
                        Console.WriteLine("---Adding a product---\n");
                        Console.Write("Name: ");
                        string name = Console.ReadLine() ?? "";


                        Console.Write("Price: ");
                        string priceInput = Console.ReadLine() ?? "";
                        if (decimal.TryParse(priceInput, out decimal price) == false)
                        {
                            Console.WriteLine("Price requires a valid decimal.");
                            break;
                        }

                        Console.Write("Amount: ");
                        string amountInput = Console.ReadLine() ?? "";


                        if (int.TryParse(amountInput, out int amount))
                        {
                            manager.AddToInventory(name, price, amount);
                        }

                        else
                        {
                            Console.WriteLine("Amount must be an integer.");
                            break;
                        }


                        //Console.WriteLine("press any key to return back to menu");
                        //Console.ReadKey(true);

                        break;


                    case "2":
                        Console.WriteLine("---Inventory---\n\n");
                        manager.ViewProducts();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;

                    case "3":
                        Console.WriteLine("---Updating Products---");

                        Console.WriteLine("\n---Current Products---\n");
                        manager.ViewProducts();

                        Console.Write("\nEnter product name to update: ");
                        string productToUpdate = Console.ReadLine() ?? "";

                        Console.Write("Enter new quantity: ");
                        string quantity = Console.ReadLine() ?? "";


                        
                        if (!int.TryParse(quantity, out int updateQuantity))
                        {
                            Console.WriteLine("Quantity is invalid, please enter a valid integer");
                            break;
                        }

                        manager.UpdateProductStock(productToUpdate, updateQuantity);
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;

                    case "4":
                        Console.WriteLine("---Inventory---");
                        manager.ViewProducts();

                        Console.Write("\n\nEnter the product name you want to remove:");
                        string toRemove = Console.ReadLine() ?? "";
                        manager.RemoveProduct(toRemove);
                        
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;


                    case "5":
                        Console.WriteLine("---Most valuable product---");
                        Product? highestValue = manager.MostValuableProduct();
                        if (highestValue != null)
                        {
                            Console.WriteLine($"\nMost valuable product: {highestValue.Name} with a total value of EUR {highestValue.Price*highestValue.Quantity}");
                        }

                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;

                    case "6":
                        if (manager.Products.Count == 0)
                        {
                            Console.WriteLine("List is empty");
                            break;

                        }

                        Console.Write("Enter threshold: ");

                        if (!int.TryParse(Console.ReadLine(), out int thres))
                        {
                            Console.WriteLine("Enter a valid integer.");
                            break;
                        }


                        List <Product> lowStockProducts = manager.GetLowStockProducts(thres);
                        Console.WriteLine($"---Products with a stock less than {thres}. --- ");
                        foreach (Product p in lowStockProducts)
                        {
                            Console.WriteLine($"{p.Name} - Quantity: {p.Quantity}");

                        }

                        break;

                    case "7":
                        if (manager.Products.Count == 0)
                        {
                            Console.WriteLine("List is empty");
                            break;
                        }


                        else
                        {
                            Console.WriteLine("---Products in Descending Order---");
                            List<Product> sortedProducts = manager.GetProductsByValue();
                            foreach (Product n in sortedProducts)
                            {
                                Console.WriteLine(n.Name);
                            }
                            break;
                        }
                        


                    case "8":

                            Console.WriteLine("---Product Names---");
                            List<string> productNames = manager.GetProductNames();
                            foreach (string n in productNames)
                        {
                            Console.WriteLine(n);
                        }
                            break;


                    case "9":
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(1000);
                        return;


                    default:

                        Console.WriteLine("Enter a valid input between 1 and 9. ");
                        break;


                            


                        
                }

               
             

            }
            
        } 
    }
}
