using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6Movies.Models;
using System.Diagnostics;

namespace Mission6Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilmApplicationContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(FilmApplicationContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        public IActionResult Form()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new FormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(FormModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.MovieId == 0)
                {
                    // New record
                    _context.Movies.Add(model);
                }
                else
                {
                    // Update existing record
                    _context.Movies.Update(model);
                }
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Form submitted successfully! Movie Name: {model.Title} and the rating is: {model.Rating}";
                return RedirectToAction("CRUDview");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(model);
        }

        public IActionResult CRUDview()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View("CRUDview", movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            var record = _context.Movies
                .SingleOrDefault(x => x.MovieId == movieId);

            if (record == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            ViewBag.movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View("Form", record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FormModel app)
        {
            if (ModelState.IsValid)
            {
                _context.Update(app);
                _context.SaveChanges();

                return RedirectToAction("CRUDview");
            }

            // Re-populate view data if model state is invalid
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            ViewBag.movies = _context.Movies.Include(x => x.Category).OrderBy(x => x.Title).ToList();
            return View("Form", app);
        }

        [HttpGet]
        public IActionResult Delete(int movieId)
        {
            var record = _context.Movies.SingleOrDefault(x => x.MovieId == movieId);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(FormModel app)
        {
            var movie = _context.Movies.Find(app.MovieId);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("CRUDview");
        }
    }
}
