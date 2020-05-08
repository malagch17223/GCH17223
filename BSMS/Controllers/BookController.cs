using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Models;
using BSMS.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BSMS.Session;

namespace BSMS.Controllers
{
    public class BookController : Controller
    {

        private void initialiseViewBag(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Authors = new MultiSelectList(AuthorModel.GetAuthors(), "AUTHORID", "ALIASNAME");
                ViewBag.PRODUCERID = new SelectList(ProducerModel.GetProducers(), "PRODUCERID", "NAME");
                ViewBag.Categories = new MultiSelectList(CategoryModel.GetAllCategory(), "CATEGORYID", "NAME");
                ViewBag.GENREID = new SelectList(GenreModel.GetGenre(), "GENREID", "NAME");
                ViewBag.LANGUAGEID = new SelectList(LanguageModel.GetLanguages(), "LANGUAGEID", "LANGUAGE1");
                ViewBag.TRANSLATEDFROM = new SelectList(BookModel.getApprovedBooks(), "BOOKID", "NAME");
            }
            else
            {
                BOOK book = BookModel.FilterBook(id);
                ViewBag.Authors = new MultiSelectList(AuthorModel.GetAuthors(), "AUTHORID", "ALIASNAME");
                ViewBag.PRODUCERID = new SelectList(ProducerModel.GetProducers(), "PRODUCERID", "NAME", book.PRODUCER);
                ViewBag.Categories = new MultiSelectList(CategoryModel.GetAllCategory(), "CATEGORYID", "NAME");
                ViewBag.GENREID = new SelectList(GenreModel.GetGenre(), "GENREID", "NAME", book.GENREID);
                ViewBag.LANGUAGEID = new SelectList(LanguageModel.GetLanguages(), "LANGUAGEID", "LANGUAGE1", book.LANGUAGEID);
                ViewBag.TRANSLATEDFROM = new SelectList(BookModel.getApprovedBooks(), "BOOKID", "NAME", book.TRANSLATEDFROM);
            }
        }
        public ActionResult Index()
        {
            List<BOOK> books = BookModel.getApprovedBooks();
            return View(books);
        }

        public ActionResult AddBook()
        {
            initialiseViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(BOOK book, List<int> Authors, List<int> Categories,
            List<HttpPostedFileBase> bookImages, List<HttpPostedFileBase> bookSoftCopy)
        {
            try
            {
                book.CREATED_DATE = DateTime.Now;
                book = BookModel.AddBook(book);

                foreach (int aID in Authors)
                {
                    BOOK_AUTHOR bookAuthor = new BOOK_AUTHOR();
                    bookAuthor.BOOKID = book.BOOKID;
                    bookAuthor.AUTHORID = aID;
                    AuthorModel.AddBookAuthor(bookAuthor);
                }

                foreach (int bCID in Categories)
                {
                    BOOK_CATEGORY bookCat = new BOOK_CATEGORY();
                    bookCat.BOOKID = book.BOOKID;
                    bookCat.CATEGORYID = bCID;
                    CategoryModel.AddBookCategory(bookCat);
                }

                foreach (HttpPostedFileBase image in bookImages)
                {

                    String fname = Generator.RandomString(10) + "." + image.FileName.Split('.')[image.FileName.Split('.').Length - 1];
                    string path = Server.MapPath("~/UserImages/") + fname;
                    BOOK_IMAGE bookImage = new BOOK_IMAGE();
                    bookImage.BOOKID = book.BOOKID;
                    bookImage.IMAGEPATH = "/UserImages/" + fname;
                    image.SaveAs(path);
                    BookModel.AddBookImage(bookImage);

                }
                if (bookSoftCopy != null)
                {

                    foreach (HttpPostedFileBase bookSC in bookSoftCopy)
                    {
                        String fname = Generator.RandomString(10) + "." + bookSC.FileName.Split('.')[bookSC.FileName.Split('.').Length - 1];
                        string path = Server.MapPath("~/UserImages/") + fname;
                        BOOK_SOFTCOPY bSC = new BOOK_SOFTCOPY();
                        bSC.BOOKID = book.BOOKID;
                        bSC.FILEPATH = "/UserImages/" + fname;
                        bSC.FILESIZE = bookSC.ContentLength;
                        bookSC.SaveAs(path);
                        BookModel.AddBookSoftCopy(bSC);

                    }

                }
                ViewBag.Message = SuccessMessage.BOOK_ADDED;

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            initialiseViewBag();
            return View(book);
        }


        public ActionResult BookList(int page = 1, int pageSize = 6)
        {
            IPagedList<BOOK> books = new PagedList<BOOK>(BookModel.GetBooks(), page, pageSize);
            return View(books);
        }

        public ActionResult BookDetail(int id)
        {
            BOOK book = BookModel.FilterBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(book);
            }
        }


        public ActionResult Delete(int id)
        {
            BookModel.DeleteBook(id);
            return null;
        }

        public ActionResult Detail(int id)
        {
            BOOK book = BookModel.FilterBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }


        public ActionResult Edit(int id)
        {
            initialiseViewBag(id);
            BOOK book = BookModel.FilterBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(BOOK book, List<int> Authors, List<int> Categories,
            List<HttpPostedFileBase> bookImages, List<HttpPostedFileBase> bookSoftCopy, int id)
        {
            try
            {
                book = BookModel.UpdateBook(book);
                foreach (AUTHOR author in AuthorModel.BookAuthor(book.BOOKID))
                {
                    AuthorModel.DeleteBookAuthor(author.AUTHORID, book.BOOKID);
                }
                foreach (int aID in Authors)
                {
                    BOOK_AUTHOR bookAuthor = new BOOK_AUTHOR();
                    bookAuthor.BOOKID = book.BOOKID;
                    bookAuthor.AUTHORID = aID;
                    AuthorModel.AddBookAuthor(bookAuthor);
                }


                if (Categories.Count != 0)
                {
                    foreach (int bCID in Categories)
                    {
                        BOOK_CATEGORY bookCat = new BOOK_CATEGORY();
                        bookCat.BOOKID = book.BOOKID;
                        bookCat.CATEGORYID = bCID;
                        CategoryModel.AddBookCategory(bookCat);
                    }
                }


                foreach (HttpPostedFileBase image in bookImages)
                {

                    String fname = Generator.RandomString(10) + "." + image.FileName.Split('.')[image.FileName.Split('.').Length - 1];
                    string path = Server.MapPath("~/UserImages/") + fname;
                    BOOK_IMAGE bookImage = new BOOK_IMAGE();
                    bookImage.BOOKID = book.BOOKID;
                    bookImage.IMAGEPATH = "/UserImages/" + fname;
                    image.SaveAs(path);
                    BookModel.AddBookImage(bookImage);

                }

                foreach (HttpPostedFileBase bookSC in bookSoftCopy)
                {
                    String fname = Generator.RandomString(10) + "." + bookSC.FileName.Split('.')[bookSC.FileName.Split('.').Length - 1];
                    string path = Server.MapPath("~/UserImages/") + fname;
                    BOOK_SOFTCOPY bSC = new BOOK_SOFTCOPY();
                    bSC.BOOKID = book.BOOKID;
                    bSC.FILEPATH = "/UserImages/" + fname;
                    bSC.FILESIZE = bookSC.ContentLength;
                    bookSC.SaveAs(path);
                    BookModel.AddBookSoftCopy(bSC);

                }


                ViewBag.Message = SuccessMessage.BOOK_ADDED;

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            initialiseViewBag();
            return View(book);
        }


        [HttpPost]
        public ActionResult ApproveBook(int bookid)
        {
            BOOK book = BookModel.FilterBook(bookid);
            if (book == null)
                return HttpNotFound();

            book.STATUS = Constant.APPROVED_TEXT;
            BookModel.UpdateBook(book);

            int pendingApprovalCount = BookModel.GetBooks().Where(query => String.IsNullOrEmpty(query.STATUS)).Count();
            return Json(pendingApprovalCount, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DisApproveBook(int bookid)
        {
            BOOK book = BookModel.FilterBook(bookid);
            if (book == null)
                return HttpNotFound();

            book.STATUS = Constant.DISAPPROVE_TEXT;
            BookModel.UpdateBook(book);

            int pendingApprovalCount = BookModel.GetBooks().Where(query => String.IsNullOrEmpty(query.STATUS)).Count();
            return Json(pendingApprovalCount, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult PendingBooks()
        {
            return View(BookModel.GetBooks().Where(query => String.IsNullOrEmpty(query.STATUS)));
        }


        [HttpPost]
        public JsonResult AddLike(int bookid)
        {
            return Json(BookModel.AddLikes(bookid), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddView(int bookid)
        {
            return Json(BookModel.AddView(bookid), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DisLike(int bookid)
        {
            return Json(BookModel.RemoveLike(bookid), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult AddRating(int bookid, int rating)
        {
            return Json(BookModel.AddRating(bookid, rating), JsonRequestBehavior.AllowGet);
        }
    }
}