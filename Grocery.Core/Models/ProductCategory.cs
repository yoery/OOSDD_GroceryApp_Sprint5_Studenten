namespace Grocery.Core.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public ProductCategory() { }

        public ProductCategory(int id, int productId, int categoryId)
        {
            Id = id;
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}