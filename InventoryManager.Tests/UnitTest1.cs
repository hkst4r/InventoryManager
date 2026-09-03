namespace InventoryManager.Tests
{
    public class InventoryTests
    {

        [Fact]
        public void AddToInventory_ValidProduct_AddsProduct()
        {
            Inventory inventory = new Inventory();


            Assert.True(inventory.AddToInventory("testing", 20.12m, 5)); 


            Assert.Equal(1, inventory.Products.Count);

            Assert.Equal("testing", inventory.Products[0].Name);
            Assert.Equal(20.12m, inventory.Products[0].Price);
            Assert.Equal(5, inventory.Products[0].Quantity);
        }

        [Fact]
        public void InvalidNameAddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("", 72m, 2));

            Assert.Equal(0, inventory.Products.Count);
        }
        [Fact]
        public void InvalidPriceAddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("rysten", -22m , 2));

            Assert.Equal(0, inventory.Products.Count);
        }
        [Fact]
        public void InvalidAmountAddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("rysten", 72m, -22));

            Assert.Equal(0, inventory.Products.Count);
        }
        [Fact]
        public void ZeroPriceAddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("rysten",0m, 22));
            Assert.Equal(0, inventory.Products.Count);

        }
        [Fact]
        public void ZeroAmountAddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();
            Assert.False(inventory.AddToInventory("rysten", 1m, 0));
            Assert.Equal(0, inventory.Products.Count);
        }
    }
}