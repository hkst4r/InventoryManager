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
                Console.WriteLine("6. Exit");
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
                        manager.ViewProducts();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;

                    case "3":
                        manager.UpdateProductStock();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;

                    case "4":
                        manager.RemoveProduct();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;


                    case "5":
                        manager.MostValuableProduct();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadKey(true);
                        break;


                    case "6":
                            Console.WriteLine("Exitting...");
                            Thread.Sleep(1000);
                            return;


                    default:

                        Console.WriteLine("Enter a valid input between 1 and 6. ");
                        break;


                            


                        
                }

               
             

            }
            
        } 
    }
}
