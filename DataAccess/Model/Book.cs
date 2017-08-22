using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Model
{
   public class Book
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Název knihy je vyžadován")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Jméno autora je vyžadováno")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Rok vydání je vyžadován")]
        [Range(1950,2100,ErrorMessage ="Rok může být od 1950-2100")]
        public int PublishedYear { get; set; }
        [AllowHtml]
        public string Description { get; set; }


        public string ImageName { get; set; }

    }
}
