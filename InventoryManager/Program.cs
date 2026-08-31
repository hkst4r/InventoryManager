
namespace InventoryManager {
    public class Program
    {
        
        public static void Main()
        {
            Inventory manager = new Inventory();
            while (true)
            {
                Console.WriteLine("---Menu--- \n");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product Stock");
                Console.WriteLine("4. Remove Product");
                Console.WriteLine("5. View Most Valuable Product");
                

                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "1":

                        manager.AddToInventory();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadLine();
                        break;


                    case "2":
                        manager.ViewProducts();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadLine();
                        break;

                    case "3":
                        manager.UpdateProductStock();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadLine();
                        break;

                    case "4":
                        manager.RemoveProduct();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadLine();
                        break;


                    case "5":
                        manager.MostValuableProduct();
                        Console.WriteLine("Press any key to return back to menu");
                        Console.ReadLine();
                        break;


                    default:

                        Console.WriteLine("Enter a valid input between 1 and 5");
                        break;


                            


                        
                }
             

            }
            
        } 
    }
}
