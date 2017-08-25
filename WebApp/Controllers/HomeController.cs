using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            BookCategoryDao bcDao = new BookCategoryDao();
            IList<BookCategory> categories = bcDao.GetAll();

            BookCategory bookCategory = new BookCategory();
            bookCategory.Name = "Učebnice";
            bookCategory.Description = "Naučná literatůra pro žáky";

            bcDao.Create(bookCategory);

            return View();
        }

       
    }
}