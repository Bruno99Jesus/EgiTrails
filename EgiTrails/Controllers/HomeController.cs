﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EgiTrails.Models;

namespace EgiTrails.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult portofolioDetails()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult ListaTrilhos()
        {
            return View();
        }

        public IActionResult TrilhosBicicleta()
        {
            return View();
        }

        public IActionResult TrilhosOffRoad()
        {
            return View();
        }

        public IActionResult TrilhosPedestres()
        {
            return View();
        }

        public IActionResult TrilhosUrbanos()
        {
            return View();
        }


        public IActionResult ReservasVeiculos()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Efetuar_Reserva()
        {
            return View();
        }

        public IActionResult COVID19()
        {
            return View();
        }

        public IActionResult PoliticaDePrivacidade()
        {
            return View();
        }

        public IActionResult PontosInteresse()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
