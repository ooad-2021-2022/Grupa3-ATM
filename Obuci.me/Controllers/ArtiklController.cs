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
    public class ArtiklController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtiklController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artikl
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artikl.ToListAsync());
        }

        // GET: Artikl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikl
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        // GET: Artikl/Create
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artikl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("ID,ImeAritkla,Velicina,Kategorija,Cijena,Kolicina")] Artikl artikl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artikl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artikl);
        }

        // GET: Artikl/Edit/5
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikl.FindAsync(id);
            if (artikl == null)
            {
                return NotFound();
            }
            return View(artikl);
        }

        // POST: Artikl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ImeAritkla,Velicina,Kategorija,Cijena,Kolicina")] Artikl artikl)
        {
            if (id != artikl.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtiklExists(artikl.ID))
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
            return View(artikl);
        }

        // GET: Artikl/Delete/5
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artikl = await _context.Artikl
                .FirstOrDefaultAsync(m => m.ID == id);
            if (artikl == null)
            {
                return NotFound();
            }

            return View(artikl);
        }

        // POST: Artikl/Delete/5
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artikl = await _context.Artikl.FindAsync(id);
            _context.Artikl.Remove(artikl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtiklExists(int id)
        {
            return _context.Artikl.Any(e => e.ID == id);
        }
    }
}
