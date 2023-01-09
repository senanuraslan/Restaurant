using System.ComponentModel.DataAnnotations;
using System;

namespace Restorantt.Models
{
	public class İletişim
	{
        [Key]
        public int Id { get; set; }
        [Required] //ismin dolu alan olamsı gerektiğini gösterir
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Mesaj { get; set; }
     
        public DateTime Tarih { get; set; }
    }
}
