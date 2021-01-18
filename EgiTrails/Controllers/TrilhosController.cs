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
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewData["TipoTrilhoSortParm"] = sortOrder == "TipoTrilho" ? "tipotrilho_desc" : "TipoTrilho";
            ViewData["TrajetoSortParm"] = sortOrder == "Trajeto" ? "trajeto_desc" : "Trajeto";
            ViewData["DistanciaSortParm"] = sortOrder == "Distancia" ? "distancia_desc" : "Distancia";
            ViewData["LocIniSortParm"] = sortOrder == "LocIni" ? "locini_desc" : "LocIni";
            ViewData["LocInterSortParm"] = sortOrder == "LocInter" ? "locinter_desc" : "LocInter";
            ViewData["LocFimSortParm"] = sortOrder == "LocFim" ? "locfim_desc" : "LocFim";
            ViewData["LimMaxPesSortParm"] = sortOrder == "LimMaxPes" ? "limmaxpes_desc" : "LimMaxPes";
            ViewData["CurrentFilter"] = searchString;

            var trilhos = from s in _context.Trilhos
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                trilhos = trilhos.Where(s => s.Nome.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nome_desc":
                    trilhos = trilhos.OrderByDescending(s => s.Nome);
                    break;
                case "TipoTrilho":
                    trilhos = trilhos.OrderBy(s => s.TipoTrilho);
                    break;
                case "tipotrilho_desc":
                    trilhos = trilhos.OrderByDescending(s => s.TipoTrilho);
                    break;
                case "Trajeto":
                    trilhos = trilhos.OrderBy(s => s.Trajeto);
                    break;
                case "trajeto_desc":
                    trilhos = trilhos.OrderByDescending(s => s.Trajeto);
                    break;
                case "Distancia":
                    trilhos = trilhos.OrderBy(s => s.Distancia);
                    break;
                case "distancia_desc":
                    trilhos = trilhos.OrderByDescending(s => s.Distancia);
                    break;
                case "LocIni":
                    trilhos = trilhos.OrderBy(s => s.LocIni);
                    break;
                case "locini_desc":
                    trilhos = trilhos.OrderByDescending(s => s.LocIni);
                    break;
                case "LocInter":
                    trilhos = trilhos.OrderBy(s => s.LocInter);
                    break;
                case "locinter_desc":
                    trilhos = trilhos.OrderByDescending(s => s.LocInter);
                    break;
                case "LocFim":
                    trilhos = trilhos.OrderBy(s => s.LocFim);
                    break;
                case "locfim_desc":
                    trilhos = trilhos.OrderByDescending(s => s.LocFim);
                    break;
                case "LimMaxPes":
                    trilhos = trilhos.OrderBy(s => s.LimMaxPes);
                    break;
                case "limmaxpes_desc":
                    trilhos = trilhos.OrderByDescending(s => s.LimMaxPes);
                    break;

                default:
                    trilhos = trilhos.OrderBy(s => s.Nome);
                    break;
            }
            return View(await trilhos.AsNoTracking().ToListAsync());
            //return View(await _context.Trilhos.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("TrilhosId,Nome,TipoTrilho,Description,Trajeto,Distancia,LocIni,LocInter,LocFim,LimMaxPes")] Trilhos trilhos)
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
        public async Task<IActionResult> Edit(int id, [Bind("TrilhosId,Nome,TipoTrilho,Description,Trajeto,Distancia,LocIni,LocInter,LocFim,LimMaxPes")] Trilhos trilhos)
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
