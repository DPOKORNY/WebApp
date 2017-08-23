using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
   public class Books
    {

        private static List<Book> books = null;
        private static int counter = 4;
        public static int Counter
        {
            get { return ++counter; }
        }

        public static List<Book> GetFakeList()
        {
            if (books == null)
            {
                books = new List<Book>();
                books.Add(new Book() { Author = "Dan Pokorný", Name = "Kniha XY", Id = 1, PublishedYear = 2014 });
                books.Add(new Book() { Author = "Karel Novy", Name = "Zahradkar", Id = 2, PublishedYear = 2011 });
                books.Add(new Book() { Author = "Milan Jaks", Name = "Kucharka", Id = 3, PublishedYear = 2001 });
                books.Add(new Book() { Author = "Ivana Leva", Name = "Siti", Id = 4, PublishedYear = 2016 });

            }
                return books;
            
        }

        public static List<Book> GetBooksFromDb()
        {
            List<Book> books = new List<Book>();

            string connectionString = @"Data Source=laptop-o1c21vmp\sqlexpress;Initial Catalog=Knihovna;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM book b join book_category c on b.category_id=c.id", connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    
                    Book b = new Book();
                    b.Name = reader.GetString(1);
                    b.Author = reader.GetString(2);
                    b.Category = new BookCategory();
                    b.Category.Name = reader.GetString(8);

                    books.Add(b);
                } 
            }
            return books;
        }
    }
}
