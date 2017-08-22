using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Class;

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
        public ActionResult Add(Book book, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
                    {
                        Image image = Image.FromStream(picture.InputStream);



                        if (image.Height > 200 || image.Width > 200)
                        {
                            Image smallImage = ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(smallImage);

                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";

                            b.Save(Server.MapPath("~/uploads/book/" + imageName), ImageFormat.Jpeg);

                            smallImage.Dispose();
                            b.Dispose();

                            book.ImageName = imageName;
                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/uploads/book/" + picture.FileName));
                        }
                    }
                }

                book.Id = Books.Counter;
                Books.GetFakeList().Add(book);

                TempData["message-success"] = "Kniha byla úspěšně přidána";
            }
            else
            {
                return View("Create", book);
            }
            return RedirectToAction("Index");
        }

    }
}