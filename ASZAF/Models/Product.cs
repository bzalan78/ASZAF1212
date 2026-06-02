using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASZAF.Models
{
    internal class Product
    {
        public Product()
        {
        }

        public Product(int id, string name, string description, decimal price, int stockQuantity, string category, string brand, double weight, bool isAvailable, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            Category = category;
            Brand = brand;
            Weight = weight;
            IsAvailable = isAvailable;
            CreatedAt = createdAt;
        }


        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public required string Category { get; set; }
        public required string Brand { get; set; }
        public double Weight { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
