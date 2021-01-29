using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgiTrails.Data;
using EgiTrails.Models;
using Microsoft.AspNetCore.Authorization;

namespace EgiTrails.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index(string sortOrder, string searchString, int? pageNumber, string currentFilter)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Data_ascending" : "";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var reservas = from s in _context.Reservas
                           select s;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                reservas = reservas.Where(s => s.Nome.Contains(searchString)
                                       || s.Telemovel.ToString().Contains(searchString) 
                                       || s.Data.ToString().Contains(searchString)
                                       || s.Email.Contains(searchString)
                                       || s.NPessoas.ToString().Contains(searchString)
                                       || s.TipoVeiculo.Contains(searchString)
                                       || s.Estado.Contains(searchString)
                                       || s.DataEstado.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Data_ascending":
                    reservas = reservas.OrderBy(s => s.Data);
                    break;
                case "telemovel":
                    reservas = reservas.OrderBy(s => s.Telemovel);
                    break;
                case "email":
                    reservas = reservas.OrderBy(s => s.Email);
                    break;
                case "npessoas":
                    reservas = reservas.OrderBy(s => s.NPessoas);
                    break;
                case "Tveiculo":
                    reservas = reservas.OrderBy(s => s.TipoVeiculo);
                    break;
                case "estado":
                    reservas = reservas.OrderBy(s => s.Estado);
                    break;
                case "dataestado":
                    reservas = reservas.OrderBy(s => s.DataEstado);
                    break;
                default:
                    reservas = reservas.OrderBy(s => s.Nome);
                    break;
            }
            int pageSize = 4;
            return View(await PaginatedList<Reservas>.CreateAsync(reservas.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reservas
                .FirstOrDefaultAsync(m => m.ReservasId == id);
            if (reservas == null)
            {
                return NotFound();
            }

            return View(reservas);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservasId,Nome,Data,Email,Telemovel,NPessoas,TipoVeiculo")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                reservas.DataEstado = null;
                _context.Add(reservas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservas);
        }
        [Authorize(Roles = "Admin")]
        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reservas.FindAsync(id);
            if (reservas == null)
            {
                return NotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservasId,Nome,Data,NPessoas,Telemovel,Email,TipoVeiculo,Estado,DataEstado")] Reservas reservas)
        {
            if (id != reservas.ReservasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservasExists(reservas.ReservasId))
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
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservas = await _context.Reservas
                .FirstOrDefaultAsync(m => m.ReservasId == id);
            if (reservas == null)
            {
                return NotFound();
            }

            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservas = await _context.Reservas.FindAsync(id);
            _context.Reservas.Remove(reservas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservasExists(int id)
        {
            return _context.Reservas.Any(e => e.ReservasId == id);
        }
    }
}
