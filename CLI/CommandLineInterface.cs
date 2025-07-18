using System;
using EFCore.Business;
using EFCore.Models;

namespace EFCore.CLI
{
    public class CommandLineInterface
    {
        private readonly ProductService _productService;

        public CommandLineInterface(ProductService productService)
        {
            _productService = productService;
        }

        public void ProcessCommand(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            var command = args[0].ToLower();

            try
            {
                switch (command)
                {
                    case "--help":
                    case "-h":
                        ShowHelp();
                        break;
                    case "list":
                        ListProducts();
                        break;
                    case "get":
                        if (args.Length < 2)
                            throw new ArgumentException("Product ID is required");
                        GetProduct(int.Parse(args[1]));
                        break;
                    case "add":
                        if (args.Length < 4)
                            throw new ArgumentException("Name, price, and quantity are required");
                        AddProduct(args);
                        break;
                    case "update":
                        if (args.Length < 5)
                            throw new ArgumentException("ID, name, price, and quantity are required");
                        UpdateProduct(args);
                        break;
                    case "delete":
                        if (args.Length < 2)
                            throw new ArgumentException("Product ID is required");
                        DeleteProduct(int.Parse(args[1]));
                        break;
                    case "stock":
                        if (args.Length < 3)
                            throw new ArgumentException("Product ID and quantity are required");
                        UpdateStock(int.Parse(args[1]), int.Parse(args[2]));
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {command}");
                        ShowHelp();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Details: {ex.InnerException.Message}");
                }
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine("Product Management System - Command Line Interface");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Commands:");
            Console.WriteLine("  list                    - List all products");
            Console.WriteLine("  get <id>               - Get product by ID");
            Console.WriteLine("  add <name> <price> <quantity> [description]");
            Console.WriteLine("                         - Add new product");
            Console.WriteLine("  update <id> <name> <price> <quantity> [description]");
            Console.WriteLine("                         - Update existing product");
            Console.WriteLine("  delete <id>            - Delete product");
            Console.WriteLine("  stock <id> <quantity>  - Update product stock");
            Console.WriteLine("  --help, -h             - Show this help message");
        }

        private void ListProducts()
        {
            var products = _productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        private void GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            Console.WriteLine(product.ToString());
        }

        private void AddProduct(string[] args)
        {
            var product = new Product
            {
                Name = args[1],
                Price = decimal.Parse(args[2]),
                StockQuantity = int.Parse(args[3]),
                Description = args.Length > 4 ? args[4] : null
            };

            var newId = _productService.CreateProduct(product);
            Console.WriteLine($"Product created successfully with ID: {newId}");
        }

        private void UpdateProduct(string[] args)
        {
            var product = new Product
            {
                ProductId = int.Parse(args[1]),
                Name = args[2],
                Price = decimal.Parse(args[3]),
                StockQuantity = int.Parse(args[4]),
                Description = args.Length > 5 ? args[5] : null
            };

            _productService.UpdateProduct(product);
            Console.WriteLine("Product updated successfully");
        }

        private void DeleteProduct(int id)
        {
            _productService.DeleteProduct(id);
            Console.WriteLine("Product deleted successfully");
        }

        private void UpdateStock(int id, int quantity)
        {
            _productService.UpdateProductStock(id, quantity);
            Console.WriteLine("Stock updated successfully");
        }
    }
} 