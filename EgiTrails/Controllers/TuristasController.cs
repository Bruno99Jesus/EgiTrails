using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgiTrails.Data;
using EgiTrails.Models;
using Microsoft.AspNetCore.Identity;

namespace EgiTrails.Controllers
{
    public class TuristasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TuristasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Turistas
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["telemovelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Telemovel" : "";
            ViewData["nifSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Nif" : "";
            ViewData["CurrentFilter"] = searchString;

            var turista = from s in _context.Turista
                           select s;


            switch (sortOrder)
            {
                case "telemovel":
                    turista = turista.OrderBy(s => s.Telemovel);
                    break;
                case "Nif":
                    turista = turista.OrderBy(s => s.NIF);
                    break;
                case "email":
                    turista = turista.OrderBy(s => s.Email);
                    break;
                default:
                    turista = turista.OrderBy(s => s.Nome);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                turista = turista.Where(s => s.Nome.Contains(searchString)
                                       || s.Telemovel.ToString().Contains(searchString)
                                       || s.Email.Contains(searchString)
                                       || s.NIF.ToString().Contains(searchString));
            }

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 4;
            return View(await PaginatedList<Turista>.CreateAsync(turista.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        // GET: Turistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .FirstOrDefaultAsync(m => m.turistaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // GET: Turistas/Create
        public IActionResult Registar()
        {
            return View();
        }

        // POST: Turistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registar(Registarturista turista)
        {
            if (ModelState.IsValid)
            {
                return View(turista);
            }
            string username = turista.Email;
            IdentityUser user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                ModelState.AddModelError("Email", "There is allready a turist with that email.");
                return View(turista);
            }

            user = new IdentityUser(username);
            await _userManager.CreateAsync(user, turista.Password);

            Turista turistaa = new Turista
            {
                Nome = turista.Nome,
                Email = turista.Email,
                NIF = turista.NIF,
                Telemovel = turista.Telemovel
            };
            _context.Add(turistaa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }
        public async Task<IActionResult> EditPersonal()
        {
            string email = User.Identity.Name;

            var turista = await _context.Turista.SingleOrDefaultAsync(c => c.Email == email);
            if (turista == null)
            {
                return NotFound();
            }

            editlogin turistainfo = new editlogin
            {
                Nome = turista.Nome,
                Email = turista.Email,
                NIF = turista.NIF,
                Telemovel = turista.Telemovel
            };

            return View(turistainfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPersonal(editlogin turista)
        {
            if (!ModelState.IsValid)
            {
                return View(turista);
            }

            string email = User.Identity.Name;

            var turistaLoggedin = await _context.Turista.SingleOrDefaultAsync(c => c.Email == email);
            if (turistaLoggedin == null)
            {
                return NotFound();
            }

            turistaLoggedin.Nome = turista.Nome;
            turistaLoggedin.Telemovel = turista.Telemovel;
            turistaLoggedin.NIF = turista.NIF;

            try
            {
                _context.Update(turistaLoggedin);
                _context.Update(turistaLoggedin);
                _context.Update(turistaLoggedin);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //todo: show error message

                throw;
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        // GET: Turistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista.FindAsync(id);
            if (turista == null)
            {
                return NotFound();
            }
            return View(turista);
        }

        // POST: Turistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("turistaId,Nome,Telemovel,Nfi,Email")] Turista turista)
        {
            if (id != turista.turistaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristaExists(turista.turistaId))
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
            return View(turista);
        }

        // GET: Turistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .FirstOrDefaultAsync(m => m.turistaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // POST: Turistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turista = await _context.Turista.FindAsync(id);
            _context.Turista.Remove(turista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuristaExists(int id)
        {
            return _context.Turista.Any(e => e.turistaId == id);
        }
    }
}