using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("products", Schema = "database-1_dbo")]
    public class Product
    {
        [Key]
        [Column("productid")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(500)]
        [Column("description")]
        public string Description { get; set; }

        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column("stockquantity")]
        public int StockQuantity { get; set; }

        [Column("categoryid")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Column("supplierid")]
        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

        [StringLength(50)]
        [Column("sku")]
        public string SKU { get; set; }

        [Column("weight", TypeName = "decimal(18,2)")]
        public decimal? Weight { get; set; }

        [StringLength(50)]
        [Column("dimensions")]
        public string Dimensions { get; set; }

        [Column("isdiscontinued")]
        public bool IsDiscontinued { get; set; }

        [Column("reorderlevel")]
        public int ReorderLevel { get; set; }

        [Column("createddate")]
        public DateTime CreatedDate { get; set; }

        [Column("modifieddate")]
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