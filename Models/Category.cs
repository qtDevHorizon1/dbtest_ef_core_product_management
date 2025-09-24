using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    [Table("categories", Schema = "productmanagement_dbo")]
    public class Category
    {
        [Key]
        [Column("categoryid")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }

        [StringLength(200)]
        [Column("description")]
        public string Description { get; set; }

        [Column("parentcategoryid")]
        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> Products { get; set; }

        public DateTime CreatedDate { get; set; }
    }
} 