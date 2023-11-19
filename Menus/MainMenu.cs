namespace Assignment_Databasteknik.Menus;

internal class MainMenu
{
    private readonly ProductMenu _productMenu;
    private readonly CustomerMenu _customerMenu;

    public MainMenu(ProductMenu productMenu, CustomerMenu customerMenu)
    {
        _productMenu = productMenu;
        _customerMenu = customerMenu;
    }

    public async Task RunAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome!");

            Console.WriteLine("1. Manage Customers.");

            Console.WriteLine("2. Manage Products.");

            Console.Write("Choose one of the options: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _customerMenu.ManageCustomers();
                    break;

                case "2":
                    await _productMenu.ManageProducts();
                    break;
            }
        }
        while (true);
    }

}
