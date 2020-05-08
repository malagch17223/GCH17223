using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSMS.Models;
using BSMS.bsms.localhost;

namespace BSMS.Tests.Model
{
    [TestClass]
    public class AuthenticationModelTest
    {

        AuthenticationModel _iModel = new AuthenticationModel();
        private USER MockUser()
        {
            USER user = new USER();
            user.EMAIL = "test@test.com";
            user.FIRSTNAME = "Test";
            user.LASTNAME = "Test ";
            user.MIDDLENAME = "101";
            user.PASSWORDHASH = "12345678";
            user.ROLEID = 3;
            return AuthenticationModel.AddUser(user);
            //return user;
        }
        [TestMethod]
        public void AuthenticateUserTest()
        {
            USER user = MockUser();
            bool mock = AuthenticationModel.EmailExist(user.EMAIL);
            Assert.AreEqual(true, mock);
        }

    }
}
