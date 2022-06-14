using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Obuci.me.Data;

namespace Obuci.me.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class KorpaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KorpaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Korpa
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Korpa.Include(k => k.Artikl);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Korpa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korpa = await _context.Korpa
                .Include(k => k.Artikl)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korpa == null)
            {
                return NotFound();
            }

            return View(korpa);
        }

        // GET: Korpa/Create
        public IActionResult Create()
        {
            ViewData["ArtiklId"] = new SelectList(_context.Artikl, "ID", "ID");
            return View();
        }

        // POST: Korpa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ArtiklId")] Korpa korpa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korpa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtiklId"] = new SelectList(_context.Artikl, "ID", "ID", korpa.ArtiklId);
            return View(korpa);
        }

        // GET: Korpa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korpa = await _context.Korpa.FindAsync(id);
            if (korpa == null)
            {
                return NotFound();
            }
            ViewData["ArtiklId"] = new SelectList(_context.Artikl, "ID", "ID", korpa.ArtiklId);
            return View(korpa);
        }

        // POST: Korpa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ArtiklId")] Korpa korpa)
        {
            if (id != korpa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korpa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorpaExists(korpa.Id))
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
            ViewData["ArtiklId"] = new SelectList(_context.Artikl, "ID", "ID", korpa.ArtiklId);
            return View(korpa);
        }

        // GET: Korpa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korpa = await _context.Korpa
                .Include(k => k.Artikl)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korpa == null)
            {
                return NotFound();
            }

            return View(korpa);
        }

        // POST: Korpa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korpa = await _context.Korpa.FindAsync(id);
            _context.Korpa.Remove(korpa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorpaExists(int id)
        {
            return _context.Korpa.Any(e => e.Id == id);
        }
    }
}
