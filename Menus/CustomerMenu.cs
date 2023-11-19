using Assignment_Databasteknik.Models;
using Assignment_Databasteknik.Services;

namespace Assignment_Databasteknik.Menus;

internal class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();
        Console.WriteLine("Manage Customers");
        Console.WriteLine("1. View All Customers");
        Console.WriteLine("2. Add Customer");
        Console.WriteLine("3. Update a Customer");
        Console.WriteLine("4. Remove a Customer");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;

            case "2":
                await CreateAsync();
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("Provide the Id for the customer you wish to update.");
                var response = int.Parse(Console.ReadLine()!);
                
                await UpdateAsync(response);
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Provide the Id for the customer you wish to remove.");
                var response2 = int.Parse(Console.ReadLine()!);

                await DeleteAsync(response2);
                break;
        }
    }

    public async Task CreateAsync()
    {
        var form = new CustomerRegistrationForm();

        Console.Clear();
        Console.WriteLine("First Name: ");
        form.FirstName = Console.ReadLine()!;

        Console.WriteLine("Last Name: ");
        form.LastName = Console.ReadLine()!;

        Console.WriteLine("Email: ");
        form.Email = Console.ReadLine()!;

        Console.WriteLine("Street Name: ");
        form.StreetName = Console.ReadLine()!;

        Console.Write("City: ");
        form.City = Console.ReadLine()!;

        Console.WriteLine("Postal Code: ");
        form.PostalCode = Console.ReadLine()!;

        Console.WriteLine("Type of Customer: (Private/Business)");
        form.CustomerCategory = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(form);
        if (result)
        {
            Console.WriteLine("Customer has been created.");
            Console.ReadKey();

        }
        else
        {
            Console.WriteLine("Couldn't create customer.");
            Console.ReadKey();
        }
    }

    public async Task ListAllAsync()
    {
        var customers = await _customerService.GetAllAsync();
        if (customers.Count() == 0)
        {
            Console.WriteLine("There are no customers registered at the moment.");
            Console.ReadKey();
            return;
        }

        foreach (var customer in customers)
        {
            Console.WriteLine($"[{customer.Id}, {customer.CustomerCategory.CategoryType} customer]. {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"{customer.Address.StreetName} {customer.Address.PostalCode} {customer.Address.City}");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }

    public async Task UpdateAsync(int id)
    {
        var customer = await _customerService.GetAsync(id);

        Console.Clear();
        Console.WriteLine("What do you want to update?");
        Console.WriteLine("1. User information: (First name/Last name/Email)");
        Console.WriteLine("2. Address information: (Street name/Postal code/City)");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.Clear();

                Console.WriteLine("First name: ");
                customer.FirstName = Console.ReadLine()!;

                Console.WriteLine("Last name: ");
                customer.LastName = Console.ReadLine()!;

                Console.WriteLine("Email: ");
                customer.Email = Console.ReadLine()!;

                customer.CustomerCategory = customer.CustomerCategory;

                await _customerService.UpdateAsync(id);
                break;

            case "2":
                Console.Clear();

                Console.WriteLine("Street name: ");
                customer.Address.StreetName = Console.ReadLine()!;

                Console.WriteLine("Postal code: ");
                customer.Address.PostalCode = Console.ReadLine()!;

                Console.WriteLine("City: ");
                customer.Address.City = Console.ReadLine()!;

                await _customerService.UpdateAsync(id);
                break;
        }

    }

    public async Task DeleteAsync(int id)
    {
        var result = await _customerService.DeleteAsync(id);
        if (result)
            Console.WriteLine($"Customer with Id: {id} was deleted successfully.");
        else
            Console.WriteLine($"Couldn't find a customer with the following id: {id}.");
    }

}





