namespace Assignment_Databasteknik.Models;

internal class ProductRegistrationForm
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public string ProductType { get; set; } = null!;
    //public string ProductCategory { get; set; } = null!;
}
