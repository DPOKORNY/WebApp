﻿using System;
using System.Collections.Generic;
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

    }
}
