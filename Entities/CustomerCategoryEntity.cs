using System.ComponentModel.DataAnnotations;

namespace Assignment_Databasteknik.Entities;

internal class CustomerCategoryEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryType { get; set; } = null!;

}
