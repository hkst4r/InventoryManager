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

            Assert.False(inventory.AddToInventory("rysten", -22m, 2));

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

            Assert.False(inventory.AddToInventory("rysten", 0m, 22));
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
            Assert.False(inventory.UpdateProductStock("rysten", 2));
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
    



    [Fact]

        public void ValidInput_RemoveProduct_ReturnsTrue()
        {
            Inventory inventory = new Inventory();
            inventory.AddToInventory("rysten", 2, 2);
            inventory.AddToInventory("computer", 1, 22);

            Assert.True(inventory.RemoveProduct("rysten"));
            Assert.Single(inventory.Products);
            Assert.Equal("computer", inventory.Products[0].Name);
        }

        [Fact]

        public void InvalidInput_RemoveProduct_ReturnsFalse()
        {
            Inventory inventory = new Inventory();
            inventory.AddToInventory("rysten", 2, 2);
            Assert.False(inventory.RemoveProduct("john"));
            Assert.Single(inventory.Products);
        }

        [Fact]
        public void CaseInsensitive_RemoveProduct()
        {
            Inventory inventory = new Inventory();
            inventory.AddToInventory("rysten", 2, 2);
            Assert.True(inventory.RemoveProduct("RYSTEN"));
            Assert.Empty(inventory.Products);
        }

        [Fact]

        public void MostValuableProduct_ReturnsCorrectProduct()
        {
            Inventory inventory = new Inventory();
            inventory.AddToInventory("Product1", 100, 5);
            inventory.AddToInventory("Product2", 200, 4);
            inventory.AddToInventory("Product3", 300, 3);
            inventory.AddToInventory("Product4", 400, 2);
            inventory.AddToInventory("Product5", 500, 1);


            Product? result = inventory.MostValuableProduct();
            Assert.NotNull(result);
            Assert.Equal("Product3", result.Name);
        }

        [Fact]
        public void MostValuableProduct_ReturnsNullIfListEmpty()
        {
            Inventory inventory = new Inventory();
            Assert.Null(inventory.MostValuableProduct());
        }






    }
}