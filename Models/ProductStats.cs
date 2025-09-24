using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("productstats", Schema = "productmanagement_dbo")]
    public class ProductStats
    {
        [Key]
        [Column("statid")]
        public int StatId { get; set; }

        [Column("totalproducts")]
        public int TotalProducts { get; set; }

        [Column("averageprice", TypeName = "decimal(18,2)")]
        public decimal AveragePrice { get; set; }

        [Column("totalstockvalue", TypeName = "decimal(18,2)")]
        public decimal TotalStockValue { get; set; }

        [Column("lowstockcount")]
        public int LowStockCount { get; set; }

        [Column("discontinuedcount")]
        public int DiscontinuedCount { get; set; }

        public DateTime LastUpdated { get; set; }
    }
} 