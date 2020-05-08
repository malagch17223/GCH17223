using BSMS.SERVICE.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace BSMS.Tests.Mock
{
    //y
    public class FakeDataAccessDataContext : IDataAccessDataContext
    {

        public FakeDataAccessDataContext()
        {
            AUTHORs = new FakeDataContext<AUTHOR>();
            BOOKs = new FakeDataContext<BOOK>();
            BOOK_AUTHORs = new FakeDataContext<BOOK_AUTHOR>();
            BOOK_CATEGORies = new FakeDataContext<BOOK_CATEGORY>();
            BOOK_IMAGEs = new FakeDataContext<BOOK_IMAGE>();
            BOOK_SOFTCOPies = new FakeDataContext<BOOK_SOFTCOPY>();
            CATEGORies = new FakeDataContext<CATEGORY>();
            GENREs = new FakeDataContext<GENRE>();
            LANGUAGEs = new FakeDataContext<LANGUAGE>();
            LIKEs = new FakeDataContext<LIKE>();
            PRODUCERs = new FakeDataContext<PRODUCER>();
            RATINGs = new FakeDataContext<RATING>();
            REVIEWs = new FakeDataContext<REVIEW>();
            ROLEs = new FakeDataContext<ROLE>();
            USERs = new FakeDataContext<USER>();
            VIEWs = new FakeDataContext<VIEW>();
            WATCHLISTs = new FakeDataContext<WATCHLIST>();
        }

        public ITable<AUTHOR> AUTHORs
        {
            get; set;
        }

        public ITable<BOOK> BOOKs
        {
            get; set;
        }

        public ITable<BOOK_AUTHOR> BOOK_AUTHORs
        {
            get; set;
        }

        public ITable<BOOK_CATEGORY> BOOK_CATEGORies
        {
            get; set;
        }

        public ITable<BOOK_IMAGE> BOOK_IMAGEs
        {
            get; set;
        }

        public ITable<BOOK_SOFTCOPY> BOOK_SOFTCOPies
        {
            get; set;
        }

        public ITable<CATEGORY> CATEGORies
        {
            get; set;
        }

        public ITable<GENRE> GENREs
        {
            get; set;
        }

        public ITable<LANGUAGE> LANGUAGEs
        {
            get; set;
        }

        public ITable<LIKE> LIKEs
        {
            get; set;
        }

        public ITable<PRODUCER> PRODUCERs
        {
            get; set;
        }

        public ITable<RATING> RATINGs
        {
            get; set;
        }

        public ITable<REVIEW> REVIEWs
        {
            get; set;
        }

        public ITable<ROLE> ROLEs
        {
            get; set;
        }

        public ITable<USER> USERs
        {
            get; set;
        }

        public ITable<VIEW> VIEWs
        {
            get; set;
        }

        public ITable<WATCHLIST> WATCHLISTs
        {
            get; set;
        }

        public void Dispose()
        {
        }

        public void SaveChanges()
        {
            
        }
    }
}
