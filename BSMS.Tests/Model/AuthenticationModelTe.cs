using BSMS.SERVICE;
using BSMS.SERVICE.App_Data;
using BSMS.Models;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSMS.Tests.Mock;
using System.Linq;

namespace BSMS.Tests.Model
{
    [TestClass]
    class AuthenticationModelTe
    {
        //bsms_service _service = new bsms_service(new FakeDataAccessDataContext());


        //public CATEGORY MockCat()
        //{
        //    CATEGORY cat = new CATEGORY();
        //    cat.CATEGORYID = 1;
        //    cat.NAME = "Test";
        //    cat.REFERENCE_KEY = "TestKey";
        //    cat.DESCRIPTION = "Unit Test Category";

        //    return cat;
        //}


        //[TestMethod]
        //public void TestInsertCategory()
        //{
        //    IDataAccessDataContext dataAccess = new FakeDataAccessDataContext();
        //    dataAccess.CATEGORies.InsertOnSubmit(MockCat());
        //    Assert.AreEqual(MockCat(), dataAccess.CATEGORies.Where(c => c.CATEGORYID == MockCat().CATEGORYID));
        //}
    }
}
