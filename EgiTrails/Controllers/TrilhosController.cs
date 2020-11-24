using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgiTrails.Data;
using EgiTrails.Models;

namespace EgiTrails.Controllers
{
    public class TrilhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrilhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trilhos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trilhos.ToListAsync());
        }

        // GET: Trilhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilhos = await _context.Trilhos
                .FirstOrDefaultAsync(m => m.TrilhosId == id);
            if (trilhos == null)
            {
                return NotFound();
            }

            return View(trilhos);
        }

        // GET: Trilhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trilhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrilhosId,Nome,TipoTrilho,Description,Trajeto")] Trilhos trilhos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trilhos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trilhos);
        }

        // GET: Trilhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilhos = await _context.Trilhos.FindAsync(id);
            if (trilhos == null)
            {
                return NotFound();
            }
            return View(trilhos);
        }

        // POST: Trilhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrilhosId,Nome,TipoTrilho,Description,Trajeto")] Trilhos trilhos)
        {
            if (id != trilhos.TrilhosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trilhos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrilhosExists(trilhos.TrilhosId))
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
            return View(trilhos);
        }

        // GET: Trilhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trilhos = await _context.Trilhos
                .FirstOrDefaultAsync(m => m.TrilhosId == id);
            if (trilhos == null)
            {
                return NotFound();
            }

            return View(trilhos);
        }

        // POST: Trilhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trilhos = await _context.Trilhos.FindAsync(id);
            _context.Trilhos.Remove(trilhos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrilhosExists(int id)
        {
            return _context.Trilhos.Any(e => e.TrilhosId == id);
        }
    }
}
