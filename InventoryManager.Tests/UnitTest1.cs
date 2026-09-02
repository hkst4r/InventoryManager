namespace InventoryManager.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void AddToInventoryAddsProduct()
        {

            Inventory inventory = new Inventory();

            inventory.AddToInventory("testing", 20.12m, 5);

            Assert.Equal(1, (inventory.Products.Count));

            Assert.Equal("testing", inventory.Products[0].Name);
            Assert.Equal(20.12m, inventory.Products[0].Price);
            Assert.Equal(5, inventory.Products[0].Quantity);


        }
    }
}