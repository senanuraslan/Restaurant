using Microsoft.AspNetCore.Mvc;
using Restorantt.Data;
using Restorantt.Models;
using System.Linq;

namespace Restorantt.ViewComponets
{
    public class CategoryList : ViewComponent
    {
        //Veri tabanı bağlama işlemleri
        private readonly ApplicationDbContext _db;
        public CategoryList(ApplicationDbContext db) //yapıcı metot
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        //Invoke bir IViewComponentResult döndüren Zaman uyumlu yöntem.
        //İnvoke=Çağırmak
        {
            var category = _db.categories.ToList();
            return View(category);
        }


    }
}
