using Microsoft.AspNetCore.Mvc;
using Restorantt.Data;
using Restorantt.Models;
using System.Linq;
namespace Restorantt.ViewComponents
   
{
    public class Comments : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public Comments(ApplicationDbContext db) //yapıcı metot
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        //Invoke bir IViewComponentResult döndüren Zaman uyumlu yöntem.
        //İnvoke=Çağırmak
        {
            //var comment = _db.Blogs.ToList();  //Yönetici onayı olmadan tüm yorumları blog sayfasında göserir
            var comment = _db.Blogs.Where(i=>i.Onay).ToList(); //Sadece onaylo yorumları listeledim
            return View(comment);
        }
    }
}
