﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgiTrails.Data;
using EgiTrails.Models;

using Microsoft.AspNetCore.Http;

namespace EgiTrails.Controllers
{
    public class ListaTrilhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaTrilhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListaTrilhos
        public async Task<IActionResult> Index(IFormFile photoFile)
        {
            var dadosTrilhos = (from b in _context.Trilhos
                                 select new Trilhos
                                 {

                                     Nome = b.Nome,
                                     Distancia = b.Distancia,
                                     Photo = b.Photo,
                                     TipoTrilho = b.TipoTrilho


                                 }).ToList();

            ViewBag.dadosTrilhos = dadosTrilhos;

           // var teste = _context.Trilhos.Select(o => o.Photo).ToList();



            return View();
        }



        // GET: ListaTrilhos/Details/5
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

        // GET: ListaTrilhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaTrilhos/Create
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

        // GET: ListaTrilhos/Edit/5
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

        // POST: ListaTrilhos/Edit/5
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

        // GET: ListaTrilhos/Delete/5
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

        // POST: ListaTrilhos/Delete/5
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
