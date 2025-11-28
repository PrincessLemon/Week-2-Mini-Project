using System;

namespace ProductListApp
{
    // Entry point of my console app :)
    internal class Program
    {
        static void Main(string[] args)
        {
            // I create one ProductManager (reused all the time)
            ProductManager manager = new ProductManager();

            // First input phase: user adds products until they press q
            // (now q works at category / name / price)
            AddProductsFlow(manager);

            // After the first add-phase: show the list + total amount
            manager.PrintAllProducts();

            // This shows a small menu so the user can keep using the app
            while (true)
            {
                // Makes the instruction line yellow like in the example picture
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product - enter: 'p' | To search for a product - enter: 's' | To quit - enter: 'q'");
                Console.ResetColor();

                string choice = Console.ReadLine();

                // I trim + check if user typed q (in any case, lower or upper)
                if (UserTypedQuit(choice))
                {
                    // Here q means: quit the whole program
                    break;
                }

                // Just as in the last project I use OrdinalIgnoreCase so lower and upper case input does not matter
                if (string.Equals(choice?.Trim(), "p", StringComparison.OrdinalIgnoreCase))
                {
                    // User wants to add more products
                    AddProductsFlow(manager);
                    manager.PrintAllProducts();
                }
                else if (string.Equals(choice?.Trim(), "s", StringComparison.OrdinalIgnoreCase))
                {
                    // User wants to search for a product by name
                    Console.Write("Enter a Product Name (or 'q' to cancel search): ");
                    string searchName = Console.ReadLine();

                    // If user types q here, we just skip the search and go back to the menu
                    if (UserTypedQuit(searchName))
                    {
                        Console.WriteLine("Search cancelled.\n");
                        continue;
                    }

                    // Let ProductManager handle trimming / checks
                    manager.SearchAndPrint(searchName);
                }
                else
                {
                    // Very simple error handling for wrong menu choice
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter 'p', 's' or 'q'.");
                    Console.ResetColor();
                }
            }
        }

        // Handles entering products (this is the “follow the steps” part)
        // Now q works on EVERY prompt in this flow. At first it was only during the first part :)
        static void AddProductsFlow(ProductManager manager)
        {
            while (true)
            {
                Console.WriteLine("------------------------------------------------------");

                // Also making this yellow so it stands out
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"q\"");
                Console.ResetColor();

                Console.Write("Enter a Category: ");
                string category = Console.ReadLine();

                // If user types q here: stop adding products and return to the menu
                if (UserTypedQuit(category))
                {
                    Console.WriteLine("Stopped adding products.\n");
                    return;
                }

                // Prevents empty categories (this also handles null)
                if (string.IsNullOrWhiteSpace(category))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Category cannot be empty.");
                    Console.ResetColor();
                    // This goes back to the start of the while loop
                    continue;
                }

                Console.Write("Enter a Product Name: ");
                string name = Console.ReadLine();

                // If user types q here: stop adding products and return to the menu
                if (UserTypedQuit(name))
                {
                    Console.WriteLine("Stopped adding products.\n");
                    return;
                }

                // Same here, do not allow an empty product name
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Product name cannot be empty.");
                    Console.ResetColor();
                    continue;
                }

                decimal price;

                // Loop until user enters a valid price OR q to quit
                while (true)
                {
                    Console.Write("Enter a Price: ");
                    string priceInput = Console.ReadLine();

                    // If user types q here: stop adding products and return to the menu
                    if (UserTypedQuit(priceInput))
                    {
                        Console.WriteLine("Stopped adding products.\n");
                        return;
                    }

                    // I trim here so spaces don't break parsing
                    if (priceInput != null)
                    {
                        priceInput = priceInput.Trim();
                    }

                    // Using decimal.TryParse to prevent a crash if user types letters instead of numbers
                    if (decimal.TryParse(priceInput, out price) && price > 0)
                    {
                        // If price is valid it breaks out of this inner loop
                        break;
                    }

                    // Shows red error if input is invalid
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Price must be a positive number.");
                    Console.ResetColor();
                }

                // Now I have category, name and price, so I create a Product and add it using the manager
                Product product = new Product(category.Trim(), name.Trim(), price);
                manager.AddProduct(product);

                // Green color now for success
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was successfully added!");
                Console.ResetColor();
            }
        }

        // Small helper method so I do not repeat the same q-check everywhere.
        // This also handles trimming and case-insensitivity in one place.
        private static bool UserTypedQuit(string input)
        {
            if (input == null)
            {
                return false;
            }

            input = input.Trim();
            return string.Equals(input, "q", StringComparison.OrdinalIgnoreCase);
        }
    }
}
