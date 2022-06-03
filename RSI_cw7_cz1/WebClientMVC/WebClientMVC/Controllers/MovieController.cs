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
            try
            {
                allMovies = WcfClient.getItems();
                return View(allMovies);
            }
            catch (Exception ex)
            {
                return View("ServiceNotRunning");
            }
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
                try
                {
                    WcfClient.editId(movie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("ServiceNotRunning");
                }
            }
            return View(movie);
        }

        public IActionResult Delete(int? id)
        {
            var movie = allMovies.Where(m => m.Id == id).FirstOrDefault();
            try
            {
                WcfClient.deleteId(movie.Id);
            }
            catch (Exception ex)
            {
                return View("ServiceNotRunning");
            }
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
                try
                {
                    WcfClient.postNewItem(movie);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    return View("ServiceNotRunning");
                }
            }
            return View(movie);
        }

        public string Next(int id)
        {
            //var indexOf = allMovies.IndexOf(allMovies.Where(x => x.Id == id).FirstOrDefault());
            //var next = allMovies[indexOf + 1 % allMovies.Count()];
            //return JSONHelper.ToJSON(next);
            return WcfClient.getNext(id);
        }
    }
}
