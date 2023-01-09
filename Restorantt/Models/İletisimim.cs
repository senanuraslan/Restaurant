using System.ComponentModel.DataAnnotations;

namespace Restorantt.Models
{
    public class İletisimim
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
    }
}
