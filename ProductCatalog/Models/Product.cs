using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Range(0.01, 1_000_000)]
        public decimal Price { get; set; }
        
        [MaxLength(40)]
        public string? Category { get; set; }
    }
}
