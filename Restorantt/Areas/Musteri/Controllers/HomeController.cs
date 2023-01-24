using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NToastNotify;
using Restorantt.Data;
using Restorantt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restorantt.Areas.Musteri.Controllers
{
    [Area("Musteri")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; //dependency injection
        private readonly ApplicationDbContext _db;
        private readonly IToastNotification _toast;
        private readonly IWebHostEnvironment _whe; //Blog sayfasının bağlantısını yaptım

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IToastNotification toast, IWebHostEnvironment whe) //veritabanı bağlantı sağladım böylece ekleme silme işlemi yapabileceğim
        {
            _logger = logger;
            _db = db; //bunu kendim ekledim
            _toast = toast;
            _whe=whe;
        }

        public IActionResult Index()  //görünüm ekledik razor boş değil normal ekledik index.cshtml
        {
            var menu = _db.Menus.Where(i => i.OzelMenu).ToList();  //Özel Menüyü ana sayfaya getrime işlemii
            return View(menu);
        }
        public IActionResult CategoryDetails(int? id)
        {
            var menu=_db.Menus.Where(i => i.CategoryId==id).ToList();
            ViewBag.KategoriId = id;
            return View(menu);
        }
        public IActionResult Menu()  //görünüm ekledik razor boş değil normal ekledik index.cshtml
        {
            var menu = _db.Menus.ToList();
            return View(menu);
        }
        // GET: Yonetici/Rezervasyons/Create
        public IActionResult Rezervasyon()  //görünüm ekledik razor boş değil normal ekledik index.cshtml
        {
            return View();
        }

        // POST: Yonetici/Rezervasyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezervasyon([Bind("Id,Name,Email,TelefonNo,Sayi,Saat,Tarih")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _db.Add(rezervasyon);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Rezervaszervasyon işleminiz başarıyla gerçekleşti. Teşekkür ederiz...");
                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyon);
        }

        public IActionResult Galeri()  //görünüm ekledik razor boş değil normal ekledik index.cshtml
        {
            var galeri = _db.Galeris.ToList();
            return View(galeri);
        }
        public IActionResult About()  //görünüm ekledik razor boş değil normal ekledik index.cshtml
        {
            var hakkında = _db.Hakkımızdas.ToList();
            return View(hakkında);
        }
        public IActionResult Blog()
        {
            return View();
        }

        // POST: Yonetici/Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Tarih = DateTime.Now;
                //yorum tarıhını musterı gırmeyecek sistemden biz çekeceğiz
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_whe.WebRootPath, @"WebSite\menu");
                    var extn = Path.GetExtension(files[0].FileName);

                    if (blog.Image != null)
                    {
                        var ImagePath = Path.Combine(_whe.WebRootPath, blog.Image.TrimStart('\\'));

                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);
                        }
                    }
                    using (var filesStream = new FileStream(Path.Combine(uploads, fileName + extn), FileMode.Create))
                    {
                        files[0].CopyTo(filesStream);
                    }
                    blog.Image = @"\WebSite\menu\" + fileName + extn;
                }


                _db.Add(blog);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Yorumunuz iletildi.Onaylandığında yorumlar sayfamızdan görebilirsiniz.Teşekkür Ederiz");
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }
        public IActionResult İletişim()  //görünüm ekledik razor boş değil normal ekledik index.cshtml
        {
            return View();
        }
        // POST: Yonetici/İletişim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> İletişim([Bind("Id,Name,Email,Telefon,Mesaj,Tarih")] İletişim İletişim)
        {
            if (ModelState.IsValid)
            {
                İletişim.Tarih=DateTime.Now;
                _db.Add(İletişim);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Mesajınız başarıyla iletildi.");
                return RedirectToAction(nameof(Index));
            }
            return View(İletişim);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    
}
