using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class GenreModel
    {
        private static bsms_service Services = new bsms_service();
        public static List<GENRE> GetGenre()
        {
            return Services.GetGenres().ToList();
        }

        internal static GENRE Fliter(int id)
        {
            foreach(GENRE genre in GetGenre())
            {
                if (genre.GENREID == id)
                {
                    return genre;
                }
            }
            return null;
        }

        internal static void AddGenre(GENRE genre)
        {
            Services.InserGenre(genre);
        }

        internal static void Update(GENRE genre)
        {
            Services.UpdateGenre(genre);
        }

        internal static void Delete(int id)
        {
            Services.DeleteGenre(id);
        }
    }
}