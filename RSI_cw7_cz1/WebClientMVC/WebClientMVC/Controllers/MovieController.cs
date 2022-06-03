using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> allMovies = new List<Movie>();
        public IActionResult Index()
        {
            allMovies = WcfClient.getItems();
            return View(allMovies);
        }

        public IActionResult Details(int? id)
        {
            var movie = allMovies.Where(m => m.Id == id).FirstOrDefault();
            return View(movie);
        }

        public IActionResult Edit(int? id)
        {
            var movie = allMovies.Where(m => m.Id == id).FirstOrDefault();
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Title,Length,Director")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                WcfClient.editId(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Delete(int? id)
        {
            var movie = allMovies.Where(m => m.Id == id).FirstOrDefault();
            WcfClient.deleteId(movie.Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Title,Length,Director")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = allMovies.Last().Id + 1;
                WcfClient.postNewItem(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
    }
}
