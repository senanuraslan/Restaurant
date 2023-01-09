using System.ComponentModel.DataAnnotations;

namespace Restorantt.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required] //ıd boş geçilmesin diye tanımladık.

        public string Name { get; set; }
    }
}
