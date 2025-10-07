namespace Grocery.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public Category() { }

        public Category(int id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}