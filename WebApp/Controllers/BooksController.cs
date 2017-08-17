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
           


            return View(Book.GetFakeList());
        }
        //LINQ z Listu
        public ActionResult Detail(int id)
        {
            Book b = (from Book book in Book.GetFakeList() where book.Id == id select book).FirstOrDefault();
            return View(b);
        }
    }
}