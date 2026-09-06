namespace InventoryManager.Tests
{
    public class InventoryTests
    {

        [Fact]
        public void AddToInventory_ValidProduct_AddsProduct()
        {
            Inventory inventory = new Inventory();


            Assert.True(inventory.AddToInventory("testing", 20.12m, 5)); 


            Assert.Single(inventory.Products);

            Assert.Equal("testing", inventory.Products[0].Name);
            Assert.Equal(20.12m, inventory.Products[0].Price);
            Assert.Equal(5, inventory.Products[0].Quantity);
        }

        [Fact]
        public void InvalidName_AddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("", 72m, 2));

            Assert.Empty(inventory.Products);
        }
        [Fact]
        public void InvalidPrice_AddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("rysten", -22m , 2));

            Assert.Empty(inventory.Products);
        }
        [Fact]
        public void InvalidAmount_AddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("rysten", 72m, -22));

            Assert.Empty(inventory.Products);
        }
        [Fact]
        public void ZeroPrice_AddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();

            Assert.False(inventory.AddToInventory("rysten",0m, 22));
            Assert.Empty(inventory.Products);

        }
        [Fact]
        public void ZeroAmount_AddToInventory_DoesNotAddProduct()
        {
            Inventory inventory = new Inventory();
            Assert.False(inventory.AddToInventory("rysten", 1m, 0));
            Assert.Empty(inventory.Products);
        }


        [Fact]
        public void ValidAmount_UpdateProductStock_ChangesQuantity()
        {
            Inventory inventory = new Inventory();
            inventory.AddToInventory("rysten", 2.2m, 2);
            Assert.True(inventory.UpdateProductStock("rysten", 3));
            Assert.Equal(3, inventory.Products[0].Quantity);
        }

        [Fact]

        public void ProductNonExistent_UpdateProductStock_ReturnsFalse()
        {
            Inventory inventory = new Inventory();
            Assert.False(inventory.UpdateProductStock("rysten",2));
        }

        [Fact]

        public void EmptyProductName_UpdateProductStock_ReturnsFalse()
        {
            Inventory inventory = new Inventory();
            Assert.False(inventory.UpdateProductStock("", 2));
        }

        [Fact]

        public void Quantity0OrLess_UpdateProductStock_ReturnsFalse()
        {
            Inventory inventory = new Inventory();
            inventory.AddToInventory("rysten", 2, 2);
            Assert.False(inventory.UpdateProductStock("rysten", 0));
            Assert.False(inventory.UpdateProductStock("rysten", -2));

            Assert.Equal(2, inventory.Products[0].Quantity);
        }
    }
}