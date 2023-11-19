using System.ComponentModel.DataAnnotations;

namespace Assignment_Databasteknik.Entities
{
    internal class ProductTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductTypeName { get; set; } = null!;
    }
}
