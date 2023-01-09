using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restorantt.Models
{
    public class Menu
    {
        [Key] //id benzersiz olacak
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string image { get; set; }
        public bool OzelMenu { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } //Menu classını Kategori Class ile ilişkilendirdik

    }
}
