using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductListApp
{
    // This class manages the list of products and printing/searching.
    // Moved it out of Program.cs to keep the "main" class cleaner
    public class ProductManager
    {
        // using List because I wanna be able to add as many product I want
        private readonly List<Product> products = new List<Product>();

        // It is public here but read-only so code outside cant replace the list. (just trying things out :))
        public IReadOnlyList<Product> Products => products;

        // this method is simple to add product to the internal list
        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        // This method prints ALL products, sorted by price, (shows total amount at bottom.)
        public void PrintAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products have been added yet.");
                return;
            }

            // Here I use LINQ OrderBy to sort the list by Price (ascending).
            var sorted = products
                .OrderBy(prod => prod.Price)   // prod is the variable name I choose
                .ToList();

            // Here I use LINQ Sum to add all prices together.
            decimal total = sorted.Sum(prod => prod.Price);

            Console.WriteLine("------------------------------------------------------");
            // HEADER CHANGED: capital C and green like in example screenshot
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category\tProduct\t\tPrice");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------");

            foreach (var prod in sorted)
            {
                // \t is a tab character. I use two tabs for nicer alignment. (even if I noticed that it does not align very well, will have to check up how to do it )
                Console.WriteLine($"{prod.Category}\t{prod.Name}\t\t{prod.Price}");
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"\t\tTotal amount:\t{total}");
            Console.WriteLine("------------------------------------------------------");
        }

        // This method uses LINQ to search for products whose name
        // contains the search term. It prints only matches.
        public void SearchAndPrint(string searchTerm)
        {
            // Check for null or empty first
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("You did not enter a product name to search for.");
                return;
            }

            // Now I can safely trim because I know it's not null or whitespace
            searchTerm = searchTerm.Trim();

            // Here I use LINQ Where to filter the list by name.
            // I add OrderBy again so the search result is also sorted by price.
            var matches = products
                .Where(prod => prod.Name != null &&
                               prod.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .OrderBy(prod => prod.Price)
                .ToList();

            // Any() is another LINQ method. It checks if there are any matches.
            if (!matches.Any())
            {
                Console.WriteLine("No products matched your search.");
                return;
            }

            Console.WriteLine("------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category\tProduct\t\tPrice");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------");

            decimal total = 0;

            foreach (var prod in matches)
            {
                // For search results I want to highlight the whole line in green.
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{prod.Category}\t{prod.Name}\t\t{prod.Price}");
                Console.ResetColor();

                total += prod.Price;
            }

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"\t\tTotal amount:\t{total}");
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
