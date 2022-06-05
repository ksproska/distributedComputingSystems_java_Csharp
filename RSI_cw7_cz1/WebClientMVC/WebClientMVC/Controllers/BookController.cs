using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClientMVC.Models;

namespace WebClientMVC.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> allBooks = new List<Book>();
        public IActionResult Index()
        {
            try
            {
                allBooks = WcfClient.getBooks();
                return View(allBooks);
            }
            catch (Exception ex)
            {
                return View("ServiceNotRunning");
            }
        }

        public IActionResult Details(int? id)
        {
            var book = allBooks.Where(m => m.Id == id).FirstOrDefault();
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            var book = allBooks.Where(m => m.Id == id).FirstOrDefault();
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Title,Genre,Author")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    WcfClient.editIdBook(book);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View("ServiceNotRunning");
                }
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            var book = allBooks.Where(m => m.Id == id).FirstOrDefault();
            try
            {
                WcfClient.deleteIdBook(book.Id);
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
        public IActionResult Create([Bind("Id,Title,Genre,Author")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = allBooks.Last().Id + 1;
                try
                {
                    WcfClient.postNewBook(book);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    return View("ServiceNotRunning");
                }
            }
            return View(book);
        }

        public string Next(int id)
        {
            //var indexOf = allBooks.IndexOf(allBooks.Where(x => x.Id == id).FirstOrDefault());
            //var next = allBooks[indexOf + 1 % allBooks.Count()];
            //return JSONHelper.ToJSON(next);
            return WcfClient.getNextBook(id);
        }
    }
}
