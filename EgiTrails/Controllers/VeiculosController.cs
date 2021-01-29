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
    public class VeiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Veiculos
        public async Task<IActionResult> Index(string sortOrder,string currentFilter,string searchString,int? pageNumber)        
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ModeloSortParm"] = String.IsNullOrEmpty(sortOrder) ? "modelo" : "";
            ViewData["NumLugSortParm"] = String.IsNullOrEmpty(sortOrder) ? "num_lug" : "";
            ViewData["DesativoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "desativo" : "";
            ViewData["CurrentFilter"] = searchString;

            var veiculos = from s in _context.Veiculos
                           select s;


            switch (sortOrder)
            {
                case "modelo":
                    veiculos = veiculos.OrderBy(s => s.Modelo);
                    break;
                case "num_lug":
                    veiculos = veiculos.OrderBy(s => s.NumLugares);
                    break;
                case "desativo":
                    veiculos = veiculos.OrderByDescending(s => s.Desativo);
                    break;
                default:
                    veiculos = veiculos.OrderBy(s => s.Modelo);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                veiculos = veiculos.Where(s => s.Modelo.Contains(searchString)
                                       || s.NumLugares.ToString().Contains(searchString)
                                       || s.Desativo.Contains(searchString));
            }

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 5;
            return View(await PaginatedList<Veiculos>.CreateAsync(veiculos.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Veiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculos = await _context.Veiculos
                .FirstOrDefaultAsync(m => m.VeiculosId == id);
            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VeiculosId,Modelo,NumLugares,Desativo")] Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(veiculos);
        }

        // GET: Veiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculos = await _context.Veiculos.FindAsync(id);
            if (veiculos == null)
            {
                return NotFound();
            }
            return View(veiculos);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VeiculosId,Modelo,NumLugares,Desativo")] Veiculos veiculos)
        {
            if (id != veiculos.VeiculosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veiculos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculosExists(veiculos.VeiculosId))
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
            return View(veiculos);
        }

        // GET: Veiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veiculos = await _context.Veiculos
                .FirstOrDefaultAsync(m => m.VeiculosId == id);
            if (veiculos == null)
            {
                return NotFound();
            }

            return View(veiculos);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veiculos = await _context.Veiculos.FindAsync(id);
            _context.Veiculos.Remove(veiculos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculosExists(int id)
        {
            return _context.Veiculos.Any(e => e.VeiculosId == id);
        }
    }
}
