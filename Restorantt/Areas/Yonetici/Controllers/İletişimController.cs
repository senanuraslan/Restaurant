using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restorantt.Data;
using Restorantt.Models;

namespace Restorantt.Areas.Yonetici.Controllers
{
    [Area("Yonetici")]
    public class İletişimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public İletişimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yonetici/İletişim
        public async Task<IActionResult> Index()
        {
            return View(await _context.İletişims.ToListAsync());
        }

        // GET: Yonetici/İletişim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var İletişim = await _context.İletişims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (İletişim == null)
            {
                return NotFound();
            }

            return View(İletişim);
        }

        // GET: Yonetici/İletişim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetici/İletişim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Telefon,Mesaj,Tarih")] İletişim İletişim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(İletişim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(İletişim);
        }

        // GET: Yonetici/İletişim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var İletişim = await _context.İletişims.FindAsync(id);
            if (İletişim == null)
            {
                return NotFound();
            }
            return View(İletişim);
        }

        // POST: Yonetici/İletişim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Telefon,Mesaj,Tarih")] İletişim İletişim)
        {
            if (id != İletişim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(İletişim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!İletişimExists(İletişim.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(İletişim);
        }

        // GET: Yonetici/İletişim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var İletişim = await _context.İletişims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (İletişim == null)
            {
                return NotFound();
            }

            return View(İletişim);
        }

        // POST: Yonetici/İletişim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var İletişim = await _context.İletişims.FindAsync(id);
            _context.İletişims.Remove(İletişim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool İletişimExists(int id)
        {
            return _context.İletişims.Any(e => e.Id == id);
        }
    }
}
