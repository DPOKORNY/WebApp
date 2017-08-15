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
            Book book = new Book() {Author="Dan Pokorný",Name="Kniha XY",Id=5,PublishedYear=2014 };

            
            return View();
        }
    }
}