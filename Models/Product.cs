using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Weight { get; set; }

        [StringLength(50)]
        public string Dimensions { get; set; }

        public bool IsDiscontinued { get; set; }

        public int ReorderLevel { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public ICollection<ProductHistory> History { get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId}\n" +
                   $"Name: {Name}\n" +
                   $"Description: {Description}\n" +
                   $"Price: ${Price:N2}\n" +
                   $"Stock: {StockQuantity}\n" +
                   $"Created: {CreatedDate:g}\n" +
                   $"Modified: {(ModifiedDate.HasValue ? ModifiedDate.Value.ToString("g") : "Not modified")}";
        }
    }
} 