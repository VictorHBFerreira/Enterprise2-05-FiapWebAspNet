using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _05_Fiap.Web.AspNet.Models;
using _05_Fiap.Web.AspNet.Persistences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _05_Fiap.Web.AspNet.Controllers
{
    public class JogadorController : Controller
    {
        private OlimpiadasContext _context;
        private IEnumerable times;

        public JogadorController(OlimpiadasContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.times = new SelectList(times, "TimeId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogador jogador)
        {

            _context.Jogador.Add(jogador);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado com sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View(_context.Jogador.ToList());
        }
        

    }
}