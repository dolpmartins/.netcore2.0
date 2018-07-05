using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using C6Consulting.Models;

namespace C6Consulting.Controllers
{
    public class HomeController : Controller
    {


        private readonly ApplicationDbContext _context;
        private Livro model = new Livro();

        public HomeController()
        {
                _context = new ApplicationDbContext();
        }


        public IActionResult Index()
        {
            var livros = _context.Livro.OrderBy(l => l.Titulo);
            return View(livros.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Livro _model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Livro.Add(_model);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(_model);
                }
            }
            catch (Exception)
            {
                return View(_model);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                model = _context.Livro.First(c => c.Id == id);
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Edit(Livro _model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Livro.Update(_model);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(_model);
                }
            }
            catch (Exception)
            {
                return View(_model);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                model = _context.Livro.First(c => c.Id == id);
                _context.Remove(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
