using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restorantt.Models
{
    public class AppUser:IdentityUser //class user tablosuna ekleme yapabilmek için IdentityUser Miras almalı
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [NotMapped]
        public string Role { get; set; } //ORM araçlarında karşılığı olmayan kolon belirttim

    }
}
