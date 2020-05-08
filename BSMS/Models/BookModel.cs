using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;
using BSMS.Session;

namespace BSMS.Models
{
    public class BookModel
    {
        private static bsms_service Service = new bsms_service();

        public BookModel(bool testInstance = false)
        {
            if (testInstance)
            {
                Service.SetAsTestContext();
            }
        }

        public static List<BOOK> getApprovedBooks()
        {
            List<BOOK> approvedBooks = GetBooks().Where(book => book.STATUS == Constant.APPROVED_TEXT).ToList();
            return approvedBooks;
        }

        public static int CountBookByAuthor(int? authorid)
        {
            return Service.GetBookAuthors().Where(bookA => bookA.AUTHORID == authorid.Value).Count();
        }

        public static List<BOOK> GetBooks()
        {
            List<BOOK> allBooks = Service.GetBooks().ToList();
            allBooks.Reverse();
            return allBooks;
        }

        public static List<BOOK_IMAGE> GetBooksImages()
        {
            return Service.GetBookImages().ToList();
        }

        internal static BOOK AddBook(BOOK book)
        {
            return Service.InsertBook(book);
        }

        internal static IEnumerable<BOOK_CATEGORY> GetBookCategories()
        {
            return Service.GetBookCategories();
        }


        public static List<BOOK_SOFTCOPY> getBookSoftCopy(int bookid)
        {
            return Service.GetBookSoftCopy().Where(bCopy => bCopy.BOOKID == bookid).ToList();
        }

        internal static void AddBookImage(BOOK_IMAGE bookImage)
        {
            Service.InsertBookImage(bookImage);
        }

        internal static void AddBookSoftCopy(BOOK_SOFTCOPY bSC)
        {
            Service.InsertBookSoftCopy(bSC);   
        }

        internal static BOOK FilterBook(int id)
        {
            foreach(BOOK book in GetBooks())
            {
                if (book.BOOKID == id)
                {
                    return book;
                }
            }
            return null;
        }

        internal static void DeleteBook(int id)
        {
            foreach(BOOK_AUTHOR bAuthors in Service.GetBookAuthors().Where(bA=>bA.BOOKID == id))
            {
                Service.DeleteBookAuthor(bAuthors.BOOK_AUTHORID);
            }
            foreach (BOOK_CATEGORY bCategory in Service.GetBookCategories().Where(bC => bC.BOOKID == id))
            {
                Service.DeleteBookCategory(bCategory.BOOK_CATEGORYID);
            }
            foreach (BOOK_IMAGE bImage in Service.GetBookImages().Where(bI => bI.BOOKID == id))
            {
                Service.DeleteBookImage(bImage.BOOK_IMAGEID);
            }
            foreach (BOOK_SOFTCOPY bCopy in Service.GetBookSoftCopy().Where(bS => bS.BOOKID == id))
            {
                Service.DeleteBookSoftCopy(bCopy.BSCID);
            }
            foreach (WATCHLIST watchlist in Service.GetAllWishList().Where(bS => bS.BOOKID == id))
            {
                Service.DeleteWishList(watchlist.WATCHLISTID);
            }
            Service.DeleteBook(id);
        }

        internal static BOOK UpdateBook(BOOK book)
        {
            Service.UpdateBook(book);
            return book;
        }


        public static bool AddLikes(int bookid)
        {
            LIKE like = new LIKE()
            {
                USERID = (new SessionHandler().AuthenticatedUser().USERID),
                BOOKID = bookid
            };
            return Service.AddLike(like);
        }


        public static bool RemoveLike(int bookid)
        {
            return Service.RemoveLike((new SessionHandler()).AuthenticatedUser().USERID, bookid);
        }
        public static int LikeCount(int bookid)
        {
            return Service.GetAllLikes().Where(like => like.BOOKID.Value == bookid).Count();
        }

        public static int ViewsCount(int bookid)
        {
            return Service.GetViews(bookid).Count();
        }

        public static bool AddView(int bookid)
        {
            SessionHandler loginSession = new SessionHandler();
            if (loginSession.AuthenticatedUser() == null)
            {
                return Service.AddAnonymousView(bookid, -1);
            }
            else
            {
                return Service.AddAnonymousView(bookid, (new SessionHandler()).AuthenticatedUser().USERID);
            }
        }
        
        public static List<BOOK> MostViewedBooks(int count)
        {
            List<BOOK> mostViewedBooks = new List<BOOK>();
            Dictionary<int, int> books = new Dictionary<int, int>();
            
            foreach(BOOK book in getApprovedBooks())
            {
                books.Add(book.BOOKID, ViewsCount(book.BOOKID));    
            }

            //for(int a = 0; a < count; a++)
            //{
            //    int maxValue = books.Values.Max();
            //    KeyValuePair<int, int> max = books.FirstOrDefault(b => b.Value == maxValue);
            //    mostViewedBooks.Add(BookModel.FilterBook(max.Key));
            //    books.Remove(max.Key);
            //}

            return mostViewedBooks;
        }


        public static bool Liked(int bookid)
        {
            return Service.GetAllLikes().Where(lk => lk.BOOKID == bookid &&
            lk.USERID == (new SessionHandler()).AuthenticatedUser().USERID).Count() != 0;
        }

        public static List<BOOK> MostLikedBooks(int count)
        {
            List<BOOK> mostLikedBooks = new List<BOOK>();
            Dictionary<int, int> books = new Dictionary<int, int>();
            
            foreach (BOOK book in getApprovedBooks())
            {
                books.Add(book.BOOKID, LikeCount(book.BOOKID));
            }
            
            //for (int a = 0; a < count; a++)
            //{
            //    int maxValue = books.Values.Max();
            //    KeyValuePair<int,int> max = books.FirstOrDefault(b => b.Value == maxValue);
            //    mostLikedBooks.Add(BookModel.FilterBook(max.Key));
            //    books.Remove(max.Key);
            //}

            return mostLikedBooks;
        }
        
        internal static bool AddRating(int bookid, int rating)
        {
            USER user = (new SessionHandler()).AuthenticatedUser();
            
            if (Service.GetRating(user.USERID, bookid) != null)
            {
                return Service.UpdateRating(user.USERID, bookid, rating);    
            }
            return Service.AddRating(bookid, user.USERID, rating);
            
        }

        public static int GetRating(int bookid)
        {
            int sumRating = 0;
            RATING[] ratings = Service.GetRatingByBookId(bookid);
            foreach (RATING rating in ratings)
            {
                sumRating = rating.RATING1.Value;
            }

            return ratings.Count() == 0 ? 1 : (sumRating / ratings.Count());
        }
    }
}