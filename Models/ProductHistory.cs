using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("producthistory", Schema = "productmanagement_dbo")]
    public class ProductHistory
    {
        [Key]
        [Column("historyid")]
        public int HistoryId { get; set; }

        [Column("productid")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        [StringLength(10)]
        [Column("action")]
        public string Action { get; set; }

        [Column("oldprice", TypeName = "decimal(18,2)")]
        public decimal? OldPrice { get; set; }

        [Column("newprice", TypeName = "decimal(18,2)")]
        public decimal? NewPrice { get; set; }

        [Column("oldstock")]
        public int? OldStock { get; set; }

        [Column("newstock")]
        public int? NewStock { get; set; }

        public DateTime ActionDate { get; set; }

        [StringLength(100)]
        [Column("modifiedby")]
        public string ModifiedBy { get; set; }
    }
} 