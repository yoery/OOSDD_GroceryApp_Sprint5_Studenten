﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;

        [ObservableProperty]
        public decimal price;

        public DateOnly ShelfLife { get; set; }

        public Product(int id, string name, int stock, decimal price)
            : this(id, name, stock, price, default) { }

        public Product(int id, string name, int stock, decimal price, DateOnly shelfLife)
            : base(id, name)
        {
            this.stock = stock;
            this.price = price;
            ShelfLife = shelfLife;  
        }

        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad - €{Price}";
        }
    }
}
