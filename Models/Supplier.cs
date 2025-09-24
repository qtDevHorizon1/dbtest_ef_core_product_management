using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("suppliers", Schema = "productmanagement_dbo")]
    public class Supplier
    {
        [Key]
        [Column("supplierid")]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(200)]
        [Column("address")]
        public string Address { get; set; }

        [StringLength(50)]
        [Column("contactperson")]
        public string ContactPerson { get; set; }

        [StringLength(20)]
        [Column("phone")]
        public string Phone { get; set; }

        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Column("isactive")]
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
} 