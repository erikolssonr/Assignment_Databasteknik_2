using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment_Databasteknik.Entities;

internal class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }

    public int ProductTypeId { get; set; }
    public ProductTypeEntity ProductType { get; set; } = null!;

    //public int ProductCategoryId { get; set; }
    //public ProductCategoryEntity ProductCategory { get; set; } = null!;

}
