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
    public class ReservasVeiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasVeiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservasVeiculos
        public async Task<IActionResult> Index()
        {

            //var dadoVeiculo = _context.Veiculos.Select(o => o.Modelo).ToList();  ////BUSCAR DADOS PARA A VARIAVEL

            
           


            //ViewBag.dadosVeiculo = dadoVeiculo;

            var dadosVeiculos = (from b in _context.Veiculos
                          select new Veiculos
                          {
                              
                              Modelo = b.Modelo,
                              NumLugares = b.NumLugares,
                              Photo = b.Photo

                          }).ToList();

            ViewBag.dadosVeiculo = dadosVeiculos;


            return View();
        }

        
    }
}
