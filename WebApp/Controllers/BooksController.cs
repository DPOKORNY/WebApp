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
            List<Book> books = new List<Book>();
            books.Add(new Book() { Author = "Dan Pokorný", Name = "Kniha XY", Id = 5, PublishedYear = 2014 });
            books.Add(new Book() { Author = "Karel Novy", Name = "Zahradkar", Id = 3, PublishedYear = 2011 });
            books.Add(new Book() { Author = "Milan Jaks", Name = "Kucharka", Id = 7, PublishedYear = 2001 });
            books.Add(new Book() { Author = "Ivana Leva", Name = "Siti", Id = 1, PublishedYear = 2016 });


            return View();
        }
    }
}