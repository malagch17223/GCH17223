using System;
using NUnit.Framework;
using BSMS.Tests.Mock;
using BSMS.bsms.localhost;
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace BSMS.Tests.Model
{
    [TestFixture]
    public class CategoryModel
    {
        bsms_service _service = new bsms_service();
        [SetUp]
        public void init()
        {
            _service.SetAsTestContext();
        }

        public CATEGORY MockCat()
        {
            CATEGORY cat = new CATEGORY();
            cat.CATEGORYID = 1;
            cat.NAME = "Test";
            cat.REFERENCE_KEY = "TestKey";
            cat.DESCRIPTION = "Unit Test Category";

            return cat;
        }

        [Test, Order(1)]
        public void TestGetAllMethod()
        {
            //MockCat();
            //_service.InserCategory(MockCat());
            //Assert.AreEqual(MockCat().NAME, dataAccess.FirstOrDefault(c => c.CATEGORYID == MockCat().CATEGORYID).NAME);
            Assert.AreEqual(_service.GetCategories().Count(), 0);
        }

    }
}
