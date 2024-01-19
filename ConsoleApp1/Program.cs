 using System;

namespace ShopConsole
{
    class Program
    {
        /*static CustomerList customerList = new CustomerList();
        static ArticleList articleList = new ArticleList();
        static InvoiceList invoiceList = new InvoiceList();
        static void Main(string[] args)
        {
            // Customer default data
            Customer customer1 = new Customer(1, "Juan", 3216573456);
            Customer customer2 = new Customer(2, "Pepito", 3218764865);
            Customer customer3 = new Customer(3, "Marco", 3146578934);
            Customer customer4 = new Customer(4, "Andres", 3135555567);
            Customer customer5 = new Customer(5, "Sandro", 3203217676);

            //Article default data
            Article article1 = new Article…
[5:43 pm, 18 / 01 / 2024] VINAY Masstech: using System;
            using System.Collections.Generic;
            using System.Linq; */

class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            // Other user details can be added here
        }

        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; } // Added Category property
        }

        class CartItem
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
        }

        class DebitCard
        {
            public string CardNumber { get; set; }
            public string ExpiryDate { get; set; }
            public string CVV { get; set; }
        }

        class ShoppingCart
        {
            public List<CartItem> Items { get; set; } = new List<CartItem>();
        }

        class Program1
        {
            static List<User> users = new List<User>();
            static List<Product> products = new List<Product>();
            static User currentUser;
            static ShoppingCart cart = new ShoppingCart();

            static void Main()
            {
                LoadInitialData(); // Load some initial data for testing

                while (true)
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. View Categories");
                    Console.WriteLine("4. View Cart");
                    Console.WriteLine("5. Checkout");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Register();
                            break;
                        case "2":
                            Login();
                            break;
                        case "3":
                            ViewCategories();
                            break;
                        case "4":
                            ViewCart();
                            break;
                        case "5":
                            Checkout();
                            break;
                        case "6":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }

            static void LoadInitialData()
            {
                // Load initial users
                users.Add(new User { Username = "user1", Password = "password1" });
                users.Add(new User { Username = "user2", Password = "password2" });

                // Load initial products with categories
                products.Add(new Product { Id = 1, Name = "Laptop", Price = 999.99m, Category = "Electronics" });
                products.Add(new Product { Id = 2, Name = "T-shirt", Price = 19.99m, Category = "Clothing" });
                products.Add(new Product { Id = 3, Name = "Apples", Price = 2.49m, Category = "Grocery" });
                products.Add(new Product { Id = 4, Name = "IPhone", Price = 9.49m, Category = "Electronics" });
                products.Add(new Product { Id = 5, Name = "Skirt", Price = 5.49m, Category = "Clothing" });
                products.Add(new Product { Id = 6, Name = "potato", Price = 2.49m, Category = "Grocery" });
                // Add more products and categories as needed
            }

            static void Register()
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                // Validate username
                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("Username cannot be empty or whitespace. Please enter a valid username.");
                    return;
                }

                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                // Validate password
                if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                {
                    Console.WriteLine("Password must be at least 6 characters long and cannot be empty or whitespace. Please enter a valid password.");
                    return;
                }

                // Check if the username is unique
                if (users.Any(u => u.Username == username))
                {
                    Console.WriteLine("Username already exists. Please choose a different username.");
                }
                else
                {
                    // Add the new user
                    users.Add(new User { Username = username, Password = password });
                    Console.WriteLine("Registration successful.");
                }
            }


            static void Login()
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();

                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                // Check if the user exists and the password is correct
                currentUser = users.Find(u => u.Username == username && u.Password == password);

                if (currentUser != null)
                {
                    Console.WriteLine($"Welcome, {currentUser.Username}!");
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            }

            static void ViewCategories()
            {
                Console.WriteLine("Categories:");
                Console.WriteLine("1. Electronics");
                Console.WriteLine("2. Clothing");
                Console.WriteLine("3. Grocery");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("Enter the category number or 4 to go back: ");
                string categoryChoice = Console.ReadLine();

                switch (categoryChoice)
                {
                    case "1":
                        DisplayProductsInCategory("Electronics");
                        break;
                    case "2":
                        DisplayProductsInCategory("Clothing");
                        break;
                    case "3":
                        DisplayProductsInCategory("Grocery");
                        break;
                    case "4":
                        // Returning to the main menu
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            static void DisplayProductsInCategory(string category)
            {
                Console.WriteLine($"{category}:");

                // Filter and display products based on the selected category
                foreach (var product in products.Where(p => p.Category == category))
                {
                    Console.WriteLine($"{product.Id}. {product.Name} - Price: {product.Price:C}");
                }

                // Ask the user if they want to add items to the cart
                Console.Write("Do you want to add items to the cart? (yes/no): ");
                string addToCartChoice = Console.ReadLine().ToLower();

                if (addToCartChoice == "yes")
                {
                    AddToCart();
                }
            }

            static void AddToCart()
            {
                Console.Write("Enter the product ID you want to add to the cart: ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    var selectedProduct = products.Find(p => p.Id == productId);

                    if (selectedProduct != null)
                    {
                        Console.Write("Enter the quantity: ");
                        if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                        {
                            var existingCartItem = cart.Items.Find(item => item.Product.Id == productId);

                            if (existingCartItem != null)
                            {
                                existingCartItem.Quantity += quantity;
                            }
                            else
                            {
                                cart.Items.Add(new CartItem { Product = selectedProduct, Quantity = quantity });
                            }

                            Console.WriteLine($"Added {quantity} {selectedProduct.Name}(s) to the cart.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity. Please enter a valid quantity.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid product ID. Please enter a valid product ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid product ID.");
                }
            }

            static void ViewCart()
            {
                Console.WriteLine("Shopping Cart:");

                foreach (var item in cart.Items)
                {
                    Console.WriteLine($"{item.Product.Name} - Quantity: {item.Quantity} - Price: {item.Product.Price:C}");
                }

                Console.WriteLine($"Total: {CalculateTotal():C}");
            }

            static void Checkout()
            {
                if (currentUser == null)
                {
                    Console.WriteLine("You need to login first.");
                    return;
                }

                // Display cart details and total
                Console.WriteLine("Order Summary:");
                foreach (var item in cart.Items)
                {
                    Console.WriteLine($"{item.Product.Name} - Quantity: {item.Quantity} - Price: {item.Product.Price:C}");
                }
                Console.WriteLine($"Total: {CalculateTotal():C}");

                // Simulate payment (dummy payment)
                Console.Write("Proceed to payment? (yes/no): ");
                string proceedToPayment = Console.ReadLine().ToLower();

                if (proceedToPayment == "yes")
                {
                    ProcessPayment();
                }
                else
                {
                    Console.WriteLine("Payment canceled. Returning to main menu.");
                }
            }

            static void ProcessPayment()
            {
                Console.WriteLine("Enter Debit Card Details:");

                DebitCard debitCard = new DebitCard();

                Console.Write("Card Number: ");
                debitCard.CardNumber = Console.ReadLine();

                Console.Write("Expiry Date (MM/YY): ");
                debitCard.ExpiryDate = Console.ReadLine();

                Console.Write("CVV: ");
                debitCard.CVV = Console.ReadLine();

                if (ValidateDebitCard(debitCard))
                {
                    Console.WriteLine("Processing payment...");
                    Console.WriteLine("Payment successful!");
                    cart.Items.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid debit card details. Payment failed.");
                }
            }

            static bool ValidateDebitCard(DebitCard card)
            {
                // Basic validation for demo purposes
                return !string.IsNullOrEmpty(card.CardNumber) && !string.IsNullOrEmpty(card.ExpiryDate) && !string.IsNullOrEmpty(card.CVV);
            }

            static decimal CalculateTotal()
            {
                decimal total = 0;

                foreach (var item in cart.Items)
                {
                    total += item.Product.Price * item.Quantity;
                }

                return total;
            }
        }