using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BSMS.SERVICE.App_Data;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using BSMS.Tests.Mock;

namespace BSMS.SERVICE
{
    //d
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class bsms_service : System.Web.Services.WebService
    {
        //v

        private IDataAccessDataContext dataAccess = new DataAccessDataContext();

        [WebMethod]
        public void UpdateUser(USER user)
        {
            foreach (USER u in dataAccess.USERs.ToList())
            {
                if (u.USERID == user.USERID)
                {
                    u.FIRSTNAME = user.FIRSTNAME;
                    u.LASTNAME = user.LASTNAME;
                    u.MIDDLENAME = user.MIDDLENAME;
                    u.EMAIL = user.EMAIL;
                    u.THUMBNAIL_PATH = user.THUMBNAIL_PATH;
                    u.PASSWORDHASH = user.PASSWORDHASH == null ? u.PASSWORDHASH : user.PASSWORDHASH;
                }
            }
            dataAccess.SaveChanges();
        }


        [WebMethod]
        public USER AddUser(USER user)
        {
            try
            {
                dataAccess.USERs.InsertOnSubmit(user);
                dataAccess.SaveChanges();
                return user;
            }
            catch
            {
                return null;
            }
        }

        [WebMethod]
        public List<ROLE> GetRoles()
        {
            return dataAccess.ROLEs.ToList();
        }
        [WebMethod]
        public List<USER> GetUsers()
        {
            return dataAccess.USERs.ToList();
        }

        [WebMethod]

        public List<CATEGORY> GetCategories()
        {
            return dataAccess.CATEGORies.ToList();
        }

        [WebMethod]

        public void UpdateCategory(CATEGORY category)
        {
            foreach (CATEGORY cat in dataAccess.CATEGORies.ToList())
            {
                if (cat.CATEGORYID == category.CATEGORYID)
                {
                    cat.NAME = category.NAME;
                    cat.DESCRIPTION = category.DESCRIPTION;
                    cat.CATEGORY_THUMBNAIL = category.CATEGORY_THUMBNAIL;
                    cat.REFERENCE_KEY = category.REFERENCE_KEY;
                }
            }

            dataAccess.SaveChanges();
        }

        [WebMethod]

        public void InserCategory(CATEGORY cat)
        {
            dataAccess.CATEGORies.InsertOnSubmit(cat);
            dataAccess.SaveChanges();
        }

        [WebMethod]
        public void DeleteCategory(int catID)
        {
            CATEGORY cat = dataAccess.CATEGORies.ToList().Single(c => c.CATEGORYID == catID);
            dataAccess.CATEGORies.DeleteOnSubmit(cat);
            dataAccess.SaveChanges();
        }


        [WebMethod]

        public List<GENRE> GetGenres()
        {
            return dataAccess.GENREs.ToList();
        }

        [WebMethod]

        public void UpdateGenre(GENRE genre)
        {
            foreach (GENRE gen in dataAccess.GENREs.ToList())
            {
                if (gen.GENREID == genre.GENREID)
                {
                    gen.NAME = genre.NAME;
                    gen.DESCRIPTION = genre.DESCRIPTION;
                    gen.REFERENCE_KEY = genre.REFERENCE_KEY;
                }
            }

            dataAccess.SaveChanges();
        }

        [WebMethod]

        public void InserGenre(GENRE genre)
        {
            dataAccess.GENREs.InsertOnSubmit(genre);
            dataAccess.SaveChanges();
        }

        [WebMethod]
        public void DeleteGenre(int genID)
        {
            GENRE gen = dataAccess.GENREs.ToList().Single(genre => genre.GENREID == genID);
            dataAccess.GENREs.DeleteOnSubmit(gen);
            dataAccess.SaveChanges();
        }


        [WebMethod]
        public void DeleteUser(int uID)
        {
            USER gen = dataAccess.USERs.ToList().Single(user => user.USERID == uID);
            dataAccess.USERs.DeleteOnSubmit(gen);
            dataAccess.SaveChanges();
        }


        [WebMethod]
        public List<AUTHOR> GetAuthors()
        {
            return dataAccess.AUTHORs.ToList();
        }


        [WebMethod]
        public void DeleteAuthor(int id)
        {
            AUTHOR author = dataAccess.AUTHORs.Single(aut => aut.AUTHORID == id);
            dataAccess.AUTHORs.DeleteOnSubmit(author);
            dataAccess.SaveChanges();
        }

        [WebMethod]
        public void AddAuthor(AUTHOR author)
        {
            dataAccess.AUTHORs.InsertOnSubmit(author);
            dataAccess.SaveChanges();
        }

        [WebMethod]
        public void UpdateAuthor(AUTHOR author)
        {
            AUTHOR prv = dataAccess.AUTHORs.Single(authors => authors.AUTHORID == author.AUTHORID);
            prv.ALIASNAME = author.ALIASNAME;
            prv.BIOGRAPHY = author.BIOGRAPHY;
            prv.FIRSTNAME = author.FIRSTNAME;
            prv.LASTNAME = author.LASTNAME;
            prv.MIDDLENAME = author.MIDDLENAME;
            prv.THUMBNAIL_PATH = author.THUMBNAIL_PATH;

            dataAccess.SaveChanges();
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public List<PRODUCER> GetProducers()
        {
            return dataAccess.PRODUCERs.ToList();
        }

        [WebMethod]
        public void DeleteProducer(int id)
        {
            PRODUCER producer = dataAccess.PRODUCERs.Single(p => p.PRODUCERID == id);
            dataAccess.PRODUCERs.DeleteOnSubmit(producer);
            dataAccess.SaveChanges();
        }


        [WebMethod]
        public void InsertProducer(PRODUCER producer)
        {
            dataAccess.PRODUCERs.InsertOnSubmit(producer);
            dataAccess.SaveChanges();
        }

        [WebMethod]
        public void UpdateProducer(PRODUCER producer)
        {
            PRODUCER p = dataAccess.PRODUCERs.Single(pp => pp.PRODUCERID == producer.PRODUCERID);
            p.NAME = producer.NAME;
            p.EMAIL = producer.EMAIL;
            p.ADDRESS = producer.ADDRESS;
            p.CONTACT = producer.CONTACT;
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public BOOK InsertBook(BOOK book)
        {
            dataAccess.BOOKs.InsertOnSubmit(book);
            dataAccess.SaveChanges();
            return book;
        }
        [WebMethod]
        public void DeleteBook(int? bookid)
        {
            BOOK book = dataAccess.BOOKs.Single(b => b.BOOKID == bookid);
            dataAccess.BOOKs.DeleteOnSubmit(book);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void UpdateBook(BOOK book)
        {
            BOOK existingBook = dataAccess.BOOKs.Single(b => b.BOOKID == book.BOOKID);

            existingBook.NAME = book.NAME;
            existingBook.ISBN_NUMBER = book.ISBN_NUMBER;
            existingBook.STATUS = book.STATUS;
            existingBook.SYNOPOSIS = book.SYNOPOSIS;
            existingBook.ISPUBLISHED = book.ISPUBLISHED;
            existingBook.REFERENCE = book.REFERENCE;
            existingBook.DATE_PUBLISHED = book.DATE_PUBLISHED;
            existingBook.CREATED_DATE = book.CREATED_DATE;
            existingBook.PRICE = book.PRICE;
            existingBook.PERCENTAGE_OFF = book.PERCENTAGE_OFF;
            existingBook.GENREID = book.GENREID;
            existingBook.PRODUCERID = book.PRODUCERID;
            existingBook.TRANSLATEDFROM = book.TRANSLATEDFROM;
            existingBook.LANGUAGEID = book.LANGUAGEID;
            //existingBook = book;
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public List<BOOK> GetBooks()
        {
            return dataAccess.BOOKs.ToList();
        }

        //book images
        [WebMethod]
        public void InsertBookImage(BOOK_IMAGE image)
        {
            dataAccess.BOOK_IMAGEs.InsertOnSubmit(image);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void UpdateBookImage(BOOK_IMAGE image)
        {
            BOOK_IMAGE bookImage = dataAccess.BOOK_IMAGEs.Single(bi => bi.BOOKID == image.BOOKID);
            bookImage = image;
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void DeleteBookImage(int id)
        {
            BOOK_IMAGE bookImage = dataAccess.BOOK_IMAGEs.Single(bi => bi.BOOK_IMAGEID == id);
            dataAccess.BOOK_IMAGEs.DeleteOnSubmit(bookImage);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public List<BOOK_IMAGE> GetBookImages()
        {
            return dataAccess.BOOK_IMAGEs.ToList();
        }


        //book category
        [WebMethod]
        public void InsertBookCategory(BOOK_CATEGORY bCategory)
        {
            dataAccess.BOOK_CATEGORies.InsertOnSubmit(bCategory);
            dataAccess.SaveChanges();
        }
        [WebMethod]

        public void UpdateBookCategory(BOOK_CATEGORY bCategory)
        {
            BOOK_CATEGORY bookCategory = dataAccess.BOOK_CATEGORies.Single(bc => bc.BOOK_CATEGORYID == bCategory.BOOK_CATEGORYID);
            bookCategory = bCategory;
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void DeleteBookCategory(int? bCategoryID)
        {
            BOOK_CATEGORY bookCategory = dataAccess.BOOK_CATEGORies.Single(bc => bc.BOOK_CATEGORYID == bCategoryID);
            dataAccess.BOOK_CATEGORies.DeleteOnSubmit(bookCategory);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public List<BOOK_CATEGORY> GetBookCategories()
        {
            return dataAccess.BOOK_CATEGORies.ToList();
        }


        //book author
        [WebMethod]
        public void InsertBookAuthor(BOOK_AUTHOR author)
        {
            dataAccess.BOOK_AUTHORs.InsertOnSubmit(author);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void UpdateBookAuthor(BOOK_AUTHOR bAuthor)
        {
            BOOK_AUTHOR bookAuthor = dataAccess.BOOK_AUTHORs.Single(ba => ba.AUTHORID == bAuthor.AUTHORID);
            bookAuthor = bAuthor;
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void DeleteBookAuthor(int bAuthorID)
        {
            BOOK_AUTHOR bookAuthor = dataAccess.BOOK_AUTHORs.First(bAuthor => bAuthor.BOOK_AUTHORID == bAuthorID);
            dataAccess.BOOK_AUTHORs.DeleteOnSubmit(bookAuthor);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public List<BOOK_AUTHOR> GetBookAuthors()
        {
            return dataAccess.BOOK_AUTHORs.ToList();
        }

        //book SoftCopy
        [WebMethod]
        public void InsertBookSoftCopy(BOOK_SOFTCOPY copy)
        {
            dataAccess.BOOK_SOFTCOPies.InsertOnSubmit(copy);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void UpdateBookSoftCopy(BOOK_SOFTCOPY bSoftCopy)
        {
            BOOK_SOFTCOPY bookSoftCopy = dataAccess.BOOK_SOFTCOPies.Single(bSC => bSC.BSCID == bSoftCopy.BSCID);
            bookSoftCopy = bSoftCopy;
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public void DeleteBookSoftCopy(int? bSCID)
        {
            BOOK_SOFTCOPY bookSoftCopy = dataAccess.BOOK_SOFTCOPies.Single(bSoftCopy => bSoftCopy.BSCID == bSCID);
            dataAccess.BOOK_SOFTCOPies.DeleteOnSubmit(bookSoftCopy);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public List<BOOK_SOFTCOPY> GetBookSoftCopy()
        {
            return dataAccess.BOOK_SOFTCOPies.ToList();
        }
        [WebMethod]

        public List<LANGUAGE> GetLanguages()
        {
            return dataAccess.LANGUAGEs.ToList();
        }


        [WebMethod]
        public void AddWishList(int userid, int bookid)
        {
            WATCHLIST watchlist = new WATCHLIST();
            watchlist.BOOKID = bookid;
            watchlist.USERID = userid;
            dataAccess.WATCHLISTs.InsertOnSubmit(watchlist);
            dataAccess.SaveChanges();
        }
        [WebMethod]
        public List<WATCHLIST> GetWishList(int userid)
        {
            return dataAccess.WATCHLISTs.ToList().Where(wt => wt.USERID.Value == userid).ToList();
        }

        [WebMethod]
        public List<WATCHLIST> GetAllWishList()
        {
            return dataAccess.WATCHLISTs.ToList();
        }


        [WebMethod]
        public void DeleteWishList(int id)
        {
            WATCHLIST watchList = dataAccess.WATCHLISTs.Single(wl => wl.WATCHLISTID == id);
            if (watchList != null)
            {
                dataAccess.WATCHLISTs.DeleteOnSubmit(watchList);
            }
            dataAccess.SaveChanges();
        }

        [WebMethod]
        public bool AddLike(LIKE like)
        {
            try
            {
                dataAccess.LIKEs.InsertOnSubmit(like);
                dataAccess.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [WebMethod]
        public bool RemoveLike(int userid, int bookid)
        {
            try
            {
                LIKE like = dataAccess.LIKEs.FirstOrDefault(lk => lk.USERID == userid && lk.BOOKID == bookid);

                if (like == null)
                {
                    return false;
                }

                dataAccess.LIKEs.DeleteOnSubmit(like);
                dataAccess.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        [WebMethod]
        public LIKE[] GetAllLikes()
        {
            return dataAccess.LIKEs.ToList().ToArray();
        }

        [WebMethod]
        public bool AddAnonymousView(int bookid, int userid = -1)
        {
            try
            {
                VIEW view = new VIEW();

                view.BOOKID = bookid;
                if (userid != -1)
                {
                    view.USERID = userid;
                }

                dataAccess.VIEWs.InsertOnSubmit(view);
                dataAccess.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public VIEW[] GetViews(int bookid)
        {
            return dataAccess.VIEWs.ToArray();
        }

        [WebMethod]
        public bool AddRating(int bookid, int userid, int rating)
        {
            try
            {
                RATING Mockrating = new RATING()
                {
                    BOOKID = bookid,
                    RATING1 = rating,
                    USERID = userid
                };

                dataAccess.RATINGs.InsertOnSubmit(Mockrating);
                dataAccess.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        [WebMethod]
        public bool UpdateRating(int userid, int bookid, int rating)
        {
            try
            {
                RATING Mockrating = dataAccess.RATINGs.FirstOrDefault(r => r.BOOKID == bookid && r.USERID == userid);
                Mockrating.RATING1 = rating;
                dataAccess.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod]
        public RATING GetRating(int userid, int bookid)
        {
            return dataAccess.RATINGs.FirstOrDefault(rating => rating.USERID == userid && rating.BOOKID == bookid);
        }

        [WebMethod]
        public RATING[] GetRatingByBookId(int bookid)
        {
            return dataAccess.RATINGs.Where(rating => rating.BOOKID == bookid).ToArray();
        }

        [WebMethod]
        public bool AddReview(String review, int bookid, int userid)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(review))
                    return false;

                REVIEW reviewData = new REVIEW()
                {
                    REVIEW1 = review,
                    BOOKID = bookid,
                    USERID = userid
                };

                dataAccess.REVIEWs.InsertOnSubmit(reviewData);
                dataAccess.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        [WebMethod]
        public REVIEW[] GetBookRevieww(int bookid)
        {
            return dataAccess.REVIEWs.Where(review => review.BOOKID == bookid).ToArray();
        }

        [WebMethod]
        public bool DeleteReview(int reviewid)
        {
            try
            {
                REVIEW review = dataAccess.REVIEWs.Single(rview => rview.REVIEWID == reviewid);
                if (review == null)
                {
                    throw new KeyNotFoundException();
                }

                dataAccess.REVIEWs.DeleteOnSubmit(review);
                dataAccess.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        [WebMethod]
        public REVIEW[] GetAllReviews()
        {
            return dataAccess.REVIEWs.ToArray();
        }

    }
}

