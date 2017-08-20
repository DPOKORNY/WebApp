using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
           


            return View(Books.GetFakeList());
        }
        //LINQ z Listu
        public ActionResult Detail(int id,bool? zobrazPopis)
        {
            Book b = (from Book book in Books.GetFakeList() where book.Id == id select book).FirstOrDefault();
            ViewBag.ZobrazPopis = zobrazPopis;
            return View(b);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {

                book.Id = Books.Counter;
                Books.GetFakeList().Add(book);
            }
            else
            {
                return View("Create", book);
            }
            return RedirectToAction("Index");
        }

    }
}