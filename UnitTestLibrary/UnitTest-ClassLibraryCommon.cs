using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

using ClassLibraryDatabase;
using ClassLibraryCommon;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTestClassLibraryCommon
    {
        ClassLibraryCommon.DataAccess dataAccess = new ClassLibraryCommon.DataAccess();

        [TestMethod]
        public void TestMethodLoadData()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            bool result = db.LoadTestData();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodCreateUser()
        {

            bool result = dataAccess.CreateUser("testUser", "testPass");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodCreateRole()
        {

            bool result = dataAccess.CreateRole("testRole");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodGetUsers()
        {

            List<UserDTO> users = dataAccess.GetUsers();

            Assert.IsTrue(users.Count>0);
        }

        [TestMethod]
        public void TestMethodGetRoles()
        {

            List<RoleDTO> roles = dataAccess.GetRoles();

            Assert.IsTrue(roles.Count > 0);
        }

        [TestMethod]
        public void TestMethodAuthenticateUser()
        {
            bool result = dataAccess.AuthenticateUser("user1", "user1");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodValidateUniqueUserName()
        {
            bool result = dataAccess.ValidateUniqueUserName("user2");
            bool result2 = dataAccess.ValidateUniqueUserName("IamUniqueUser");
            Assert.IsFalse(result);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void TestMethodRegisterUser()
        {
            DateTime dateStamp = new DateTime();
            bool result = dataAccess.RegisterUser("userRegisterTest" , "testpass");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodGetUserByUserName()
        {

            string[] user = dataAccess.GetUserByUserName("Babalou");

            Assert.IsTrue(user.Length>0);
        }










    }
}
