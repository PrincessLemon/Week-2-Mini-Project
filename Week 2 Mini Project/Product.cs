using System;

namespace ProductListApp
{
    // This class represents ONE product.
    public class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }
        
        // Learnt that decimal is better for money than dobule :) 
        // although pretty sure that double would be fine anyway since it wont handle thaaaaat large number :D:D 
        public decimal Price { get; set; }  

        // Construuuctor! 
        // runs when I write: new Product
        public Product(string category, string name, decimal price)
        {
            Category = category;
            Name = name;
            Price = price;
        }
    }
}
