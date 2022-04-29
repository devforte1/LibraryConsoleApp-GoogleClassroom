using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using ClassLibraryDatabase;
using ClassLibraryCommon;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTestClasslibraryDatabase
    {

        [TestMethod]
        public void LoadTestData()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            bool result = db.LoadTestData();

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestMethodSelectUsers()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            List<string[]> userList = db.SelectUsers();

            Assert.IsNotNull(userList);
        }

        [TestMethod]
        public void TestMethodSelectRoles()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            List<string[]> roleList = db.SelectRoles();

            Assert.IsNotNull(roleList);
        }

        [TestMethod]
        public void TestMethodSelectUserByName()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            string[] user = db.SelectUserByUserName("admin1");

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestMethodValidateUniqueUser()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            bool user = db.ValidateUniqueUser("admin1");
            bool user2 = db.ValidateUniqueUser("ThisIsUniqueUserName");

            Assert.IsFalse(user);
            Assert.IsTrue(user2);
        }

        [TestMethod]
        public void TestMethodSelectMedia()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            List<string[]> inventoryList = db.SelectMediaInventory();

            Assert.IsNotNull(inventoryList);
        }

        [TestMethod]
        public void TestMethodInsertRole()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            bool result = db.InsertRole("InsertTestRoleName");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodInsertUser()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            bool result = db.InsertUser("InsertUserTest", "userPassTest", true);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodInsertMedia()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            bool result = db.InsertMedia("TestMediaType", "TestMediaPass");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodDeleteUserByUserName()
        {
            SqlServerDb db = new SqlServerDb();
            DataAccess dataAccess = new DataAccess();
            bool result = db.DeleteUserByUserName("user3");

            Assert.IsTrue(result);
        }


    }
}
