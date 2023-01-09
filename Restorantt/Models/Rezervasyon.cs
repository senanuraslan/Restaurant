using System;
using System.ComponentModel.DataAnnotations;

namespace Restorantt.Models
{
    public class Rezervasyon
    {

        [Key]
        public int Id { get; set; }
        [Required] //ismin dolu alan olamsı gerektiğini gösterir
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string TelefonNo { get; set; }
        [Required]
        public int Sayi { get; set; }
        [Required]
        public string Saat { get; set; }
        public DateTime Tarih { get; set; }






    }
}
