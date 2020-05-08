using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class AuthorModel
    {
        private static bsms_service localhost = new bsms_service();

        public static String ReducedText(int length, string input)
        {
            if (input.Length <= length)
                return input;
            else
            {
                int lengthCount = 0;
                string output = "";
                foreach(char c in input)
                {
                    output += c;
                    if (lengthCount >= length)
                    {
                        output += ".... Read More >>";
                        return output;
                    }
                    lengthCount++;
                }
            }
            return input;
        }

        public static List<AUTHOR> GetAuthors()
        {
            return localhost.GetAuthors().ToList();
        }

        internal static AUTHOR Filter(int id)
        {
            foreach(AUTHOR auth in GetAuthors())
            {
                if (auth.AUTHORID == id)
                {
                    return auth;
                }
            }
            return null;
        }

        internal static void Create(AUTHOR author)
        {
            localhost.AddAuthor(author);
        }

        internal static void Update(AUTHOR author)
        {
            localhost.UpdateAuthor(author);
        }

        internal static void Delete(int id)
        {
            foreach(BOOK_AUTHOR bAuthor in localhost.GetBookAuthors().Where(bAu=> bAu.AUTHORID == id))
            {
               localhost.DeleteBookAuthor(bAuthor.BOOK_AUTHORID);
            }
            localhost.DeleteAuthor(id);
        }

        internal static void AddBookAuthor(BOOK_AUTHOR bookAuthor)
        {
            localhost.InsertBookAuthor(bookAuthor);
        }

        public static List<BOOK> BookByAuthor(int id)
        {
            List<BOOK> bookByAuthor = new List<BOOK>();
            foreach(BOOK_AUTHOR bookAuthor in localhost.GetBookAuthors())
            {
                if (bookAuthor.AUTHORID == id)
                {
                    bookByAuthor.Add(bookAuthor.BOOK);
                }
            }
            return bookByAuthor;
        }

        public static List<AUTHOR> BookAuthor(int id)
        {
            List<AUTHOR> bookAuthors = new List<AUTHOR>();
            foreach (BOOK_AUTHOR bookAuthor in localhost.GetBookAuthors())
            {
                if (bookAuthor.BOOKID == id)
                {
                    bookAuthors.Add(bookAuthor.AUTHOR);
                }
            }
            return bookAuthors;
        }


        public static bool BookAuthorExist(int bookid, int Authorid)
        {
            foreach (BOOK_AUTHOR bookAuthor in localhost.GetBookAuthors())
            {
                if (bookAuthor.BOOKID == bookid && bookAuthor.AUTHORID == Authorid)
                {
                    return true;
                }
            }
            return false;
        }

        internal static void DeleteBookAuthor(int aUTHORID, int bOOKID)
        {
            BOOK_AUTHOR bAuthor = localhost.GetBookAuthors().Single(bA => bA.AUTHORID == aUTHORID && bA.BOOKID == bOOKID);
            localhost.DeleteBookAuthor(bAuthor.BOOK_AUTHORID);
        }
    }
}