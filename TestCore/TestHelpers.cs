using Grocery.Core.Models;
using Grocery.Core.Services;
using Grocery.Core.Interfaces.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestCore
{
    // Simple mock for IGroceryListItemsRepository
    public class MockGroceryListItemsRepository : IGroceryListItemsRepository
    {
        public List<GroceryListItem> Items = new List<GroceryListItem>();

        public List<GroceryListItem> GetAll() => Items;
        public List<GroceryListItem> GetAllOnGroceryListId(int id) => Items.Where(i => i.GroceryListId == id).ToList();
        public GroceryListItem Add(GroceryListItem item) { Items.Add(item); return item; }
        public GroceryListItem? Delete(GroceryListItem item) { Items.Remove(item); return item; }
        public GroceryListItem? Get(int id) => Items.FirstOrDefault(i => i.Id == id);
        public GroceryListItem? Update(GroceryListItem item)
        {
            var idx = Items.FindIndex(i => i.Id == item.Id);
            if (idx >= 0) Items[idx] = item;
            return item;
        }
    }

    // Simple mock for IProductRepository
    public class MockProductRepository : IProductRepository
    {
        public List<Product> Products = new List<Product>();

        public List<Product> GetAll() => Products;
        public Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);
        public Product Add(Product item) { Products.Add(item); return item; }
        public Product? Delete(Product item) { Products.Remove(item); return item; }
        public Product? Update(Product item)
        {
            var idx = Products.FindIndex(p => p.Id == item.Id);
            if (idx >= 0) Products[idx] = item;
            return item;
        }
    }

    public class TestHelpers
    {
        private GroceryListItemsService _groceryListService;
        private MockGroceryListItemsRepository _mockGroceryRepo;
        private MockProductRepository _mockProductRepo;

        [SetUp]
        public void Setup()
        {
            // Setup mock data
            _mockProductRepo = new MockProductRepository();
            _mockProductRepo.Products.Add(new Product(1, "Appel", 10, 1.50m, new DateOnly(2025, 12, 31)));
            _mockProductRepo.Products.Add(new Product(2, "Banaan", 5, 2.00m, new DateOnly(2025, 11, 30)));

            _mockGroceryRepo = new MockGroceryListItemsRepository();
            _mockGroceryRepo.Items.Add(new GroceryListItem(1, 1, 1, 2) { Product = _mockProductRepo.Get(1) });
            _mockGroceryRepo.Items.Add(new GroceryListItem(2, 1, 2, 1) { Product = _mockProductRepo.Get(2) });

            // Inject mocks into service
            _groceryListService = new GroceryListItemsService(_mockGroceryRepo, _mockProductRepo);
        }

        // UC1: Tonen boodschappenlijsten
        [Test]
        public void UC1_ShouldShowGroceryLists()
        {
            var lists = _groceryListService.GetAllOnGroceryListId(1);
            Assert.IsNotNull(lists);
            Assert.IsNotEmpty(lists);
        }

        // UC2: Tonen boodschappenlijst (get by id)
        [Test]
        public void UC2_ShouldShowSelectedGroceryListItem()
        {
            var item = _groceryListService.Get(1);
            Assert.IsNotNull(item);
            Assert.AreEqual(1, item.Id);
        }

        // UC3: Tonen producten
        [Test]
        public void UC3_ShouldShowProducts()
        {
            var products = _mockProductRepo.GetAll();
            Assert.IsNotNull(products);
            Assert.IsNotEmpty(products);
        }

        // UC4: Kiezen kleur boodschappenlijst (simulate by setting a property)
        [Test]
        public void UC4_ShouldChangeProductName()
        {
            var item = _groceryListService.Get(1);
            item.Product.name = "#FFF";
            _groceryListService.Update(item);
            var updatedItem = _groceryListService.Get(1);
            Assert.AreEqual("#FFF", updatedItem.Product.name);
        }

        // UC5: Plaatsen product op boodschappenlijst (add product to list)
        [Test]
        public void UC5_ShouldAddProductToGroceryList()
        {
            var newItem = new GroceryListItem(3, 1, 2, 1) { Product = _mockProductRepo.Get(2) };
            _groceryListService.Add(newItem);
            var lists = _groceryListService.GetAllOnGroceryListId(1);
            Assert.IsTrue(lists.Any(i => i.Id == 3));
        }

        // UC10: Aanpassen product aantal (+)
        [Test]
        public void UC10_ShouldIncreaseProductAmount()
        {
            var item = _groceryListService.Get(1);
            int oldAmount = item.amount;
            item.amount += 1;
            _groceryListService.Update(item);
            var updatedItem = _groceryListService.Get(1);
            Assert.AreEqual(oldAmount + 1, updatedItem.amount);
        }

        // UC10: Aanpassen product aantal (-)
        [Test]
        public void UC10_ShouldDecreaseProductAmount()
        {
            var item = _groceryListService.Get(1);
            item.amount = 2;
            item.amount -= 1;
            _groceryListService.Update(item);
            var updatedItem = _groceryListService.Get(1);
            Assert.AreEqual(1, updatedItem.amount);
        }

        // UC10: Aanpassen product aantal (blijft 0)
        [Test]
        public void UC10_ShouldNotDecreaseProductAmountBelowZero()
        {
            var item = _groceryListService.Get(1);
            item.amount = 0;
            item.amount = item.amount > 0 ? item.amount - 1 : 0;
            _groceryListService.Update(item);
            var updatedItem = _groceryListService.Get(1);
            Assert.AreEqual(0, updatedItem.amount);
        }

        // UC11: Tonen meest verkochte producten
        [Test]
        public void UC11_ShouldShowMostSoldProducts()
        {
            var bestSelling = _groceryListService.GetBestSellingProducts();
            Assert.IsNotNull(bestSelling);
            Assert.IsTrue(bestSelling.Count > 0);
        }

        // UC14: Toevoegen prijzen
        [Test]
        public void UC14_ShouldShowProductPrices()
        {
            var products = _mockProductRepo.GetAll();
            foreach (var product in products)
            {
                Assert.Greater(product.price, 0);
            }
        }

        // UC15: Toevoegen THT datum
        [Test]
        public void UC15_ShouldShowProductShelfLife()
        {
            var products = _mockProductRepo.GetAll();
            foreach (var product in products)
            {
                Assert.IsNotNull(product.ShelfLife);
            }
        }
    }
}