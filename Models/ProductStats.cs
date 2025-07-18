using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("ProductStats")]
    public class ProductStats
    {
        [Key]
        public int StatId { get; set; }

        public int TotalProducts { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AveragePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalStockValue { get; set; }
        public int LowStockCount { get; set; }
        public int DiscontinuedCount { get; set; }
        public DateTime LastUpdated { get; set; }
    }
} 