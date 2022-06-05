using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class MusicController : Controller
    {
        private static List<Music> allMusics = new List<Music>();
        public IActionResult Index()
        {
            try
            {
                allMusics = WcfClient.getMusics();
                return View(allMusics);
            }
            catch (Exception ex)
            {
                return View("ServiceNotRunning");
            }
        }

        public IActionResult Details(int? id)
        {
            var music = allMusics.Where(m => m.Id == id).FirstOrDefault();
            return View(music);
        }

        public IActionResult Edit(int? id)
        {
            var music = allMusics.Where(m => m.Id == id).FirstOrDefault();
            return View(music);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Title,Genre,Author,Length")] Music music)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    WcfClient.editIdMusic(music);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("ServiceNotRunning");
                }
            }
            return View(music);
        }

        public IActionResult Delete(int? id)
        {
            var music = allMusics.Where(m => m.Id == id).FirstOrDefault();
            try
            {
                WcfClient.deleteIdMusic(music.Id);
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
        public IActionResult Create([Bind("Id,Title,Genre,Author,Length")] Music music)
        {
            if (ModelState.IsValid)
            {
                music.Id = allMusics.Last().Id + 1;
                try
                {
                    WcfClient.postNewMusic(music);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    return View("ServiceNotRunning");
                }
            }
            return View(music);
        }

        public string Next(int id)
        {
            //var indexOf = allMusics.IndexOf(allMusics.Where(x => x.Id == id).FirstOrDefault());
            //var next = allMusics[indexOf + 1 % allMusics.Count()];
            //return JSONHelper.ToJSON(next);
            return WcfClient.getNextMusic(id);
        }
    }
}
