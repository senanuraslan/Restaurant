using Microsoft.AspNetCore.Mvc;
using Restorantt.Data;
using System.Linq;

namespace Restorantt.ViewComponents
{
    public class Iletisimim: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public Iletisimim(ApplicationDbContext db) //yapıcı metot
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        //Invoke bir IViewComponentResult döndüren Zaman uyumlu yöntem.
        //İnvoke=Çağırmak
        {
            var İletisimim = _db.Iletisimims.ToList();  
            return View(İletisimim);
        }
    }
}
