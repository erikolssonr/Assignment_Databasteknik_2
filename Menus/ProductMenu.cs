using Assignment_Databasteknik.Models;
using Assignment_Databasteknik.Services;

namespace Assignment_Databasteknik.Menus;

internal class ProductMenu
{
    private readonly ProductService _productService;

    public ProductMenu(ProductService productService)
    {
        _productService = productService;
    }

    public async Task ManageProducts()
    {
        Console.Clear();
        Console.WriteLine("Manage Products");
        Console.WriteLine("1. Add a Product");
        Console.WriteLine("2. View All Products");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await CreateAsync();
                break;

            case "2":
                await ListAllAsync();
                break;

        }
    }


    public async Task CreateAsync()
    {
        var form = new ProductRegistrationForm();

        Console.Clear();
        Console.WriteLine("Product name:");
        form.ProductName = Console.ReadLine()!;

        Console.WriteLine("Product description:");
        form.ProductDescription = Console.ReadLine()!;

        Console.WriteLine("Product price:");
        form.ProductPrice = decimal.Parse(Console.ReadLine()!);

        Console.WriteLine($"What type of product is it? (Headset, Mouse, Graphics card, etc.)");
        form.ProductType = Console.ReadLine()!;

        var result = await _productService.CreateProductAsync(form);
        if (result)
        {
            Console.WriteLine("Product was registered successfully.");
            Console.ReadKey();
        }

        else
        {
            Console.WriteLine("Product couldn't be registered.");
            Console.ReadKey();
        }
            
    }

    public async Task ListAllAsync()
    {
        Console.Clear();

        var products = await _productService.GetAllAsync();
        if (products.Count() == 0)
        {
            Console.WriteLine("There are no products registered at the moment.");
            Console.ReadKey();
            return;
        }

        foreach (var product in products)
        {
            Console.WriteLine($"{product.ProductName} {product.ProductType.ProductTypeName}");
            Console.WriteLine($"{product.ProductPrice} SEK");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }
}
