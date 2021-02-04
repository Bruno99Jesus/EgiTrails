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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turista.ToListAsync());
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
                ModelState.AddModelError("Email", "There is allready a customer with that email.");
                return View(turista);
            }

            user = new IdentityUser(username);
            await _userManager.CreateAsync(user, turista.Password);

            Turista turistaa = new Turista
            {
                Nome = turista.Nome,
                Email = turista.Email
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
                Email = turista.Email
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

            try
            {
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