using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("ProductHistory")]
    public class ProductHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        [StringLength(10)]
        public string Action { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? OldPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? NewPrice { get; set; }

        public int? OldStock { get; set; }
        public int? NewStock { get; set; }

        public DateTime ActionDate { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }
    }
} 