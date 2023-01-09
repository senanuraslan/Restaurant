using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restorantt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restorantt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> categories { get; set; } //tabloları eklememizi sağlıyor. Modelsdeki oluşturduğumuz propları. 
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Rezervasyon> Rezervasyons { get; set; }
        public DbSet<Galeri> Galeris { get; set; }
        public DbSet<Hakkımızda> Hakkımızdas { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<İletişim> İletişims { get; set; }
        public DbSet<İletisimim> Iletisimims { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
       
        

    }
}
