using System.Collections.Generic;
using System.Linq;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories = new();

        public CategoryRepository()
        {
            _categories.Add(new Category { Id = 1, Name = "Fruit", Description = "Vers fruit" });
            _categories.Add(new Category { Id = 2, Name = "Groente", Description = "Verse groente" });
            _categories.Add(new Category { Id = 3, Name = "Zuivel", Description = "Melk, kaas, yoghurt" });
            _categories.Add(new Category { Id = 4, Name = "Vlees", Description = "Vers vlees en gevogelte" });
            _categories.Add(new Category { Id = 5, Name = "Brood", Description = "Brood en bakkerijproducten" });
            _categories.Add(new Category { Id = 6, Name = "Dranken", Description = "Frisdrank, sap, water" });
            _categories.Add(new Category { Id = 7, Name = "Snacks", Description = "Chips, koekjes, snoep" });
            _categories.Add(new Category { Id = 8, Name = "Diepvries", Description = "Diepvriesproducten" });
            _categories.Add(new Category { Id = 9, Name = "Kruiden", Description = "Specerijen en kruiden" });
            _categories.Add(new Category { Id = 10, Name = "Non-food", Description = "Huishoudelijke artikelen" });
        }

        public IEnumerable<Category> GetAll() => _categories;

        public Category? GetById(int id) => _categories.FirstOrDefault(c => c.Id == id);

        public void Add(Category category)
        {
            _categories.Add(category);
        }

        public void Update(Category category)
        {
            var existing = GetById(category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.Description = category.Description;
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}