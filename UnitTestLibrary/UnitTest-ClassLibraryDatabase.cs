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
        public void TestMethodCreateUserList()
        {
            MockDb db = new MockDb();
            DataAccess dataAccess = new DataAccess();
            List<string[]> userList = db.GetUsers();

            Assert.IsNotNull(userList);
        }
        
        [TestMethod]
        public void TestMethodValidateUserRecordCount()
        {
            MockDb db = new MockDb();
            List<string[]> userList = db.GetUsers();

            Assert.AreEqual(userList.Count, 3);
        }

        [TestMethod]
        public void TestMethodValidateUserId()
        {
            MockDb db = new MockDb();
            List<string[]> userList = db.GetUsers();
            
            string[] user1 = (string[]) userList[0];
            Assert.AreEqual(int.Parse(user1[2]), 1);

            string[] user2 = (string[])userList[1];
            Assert.AreEqual(int.Parse(user2[2]), 2);

            string[] user3 = (string[])userList[2];
            Assert.AreEqual(int.Parse(user3[2]), 3);

        }

        [TestMethod]
        public void TestMethodCreateRoleList()
        {
            MockDb libraryDb = new MockDb();
            // List<RoleDTO> roleList = libraryDb.GetRoles();

            // RoleDTO Unit Tests.
            //Assert.IsNotNull(roleList);
            //Assert.AreEqual(4, roleList.Count);
        }

        [TestMethod]
        public void TestMethodValidateRoleId()
        {
            MockDb libraryDb = new MockDb();
            // List<RoleDTO> roleList = libraryDb.GetRoles();

            // RoleDTO Unit Tests.
            //Assert.AreEqual(roleList[0].RoleId, 1);
            //Assert.AreEqual(roleList[1].RoleId, 2);
            //Assert.AreEqual(roleList[2].RoleId, 3);
            //Assert.AreEqual(roleList[3].RoleId, 4);
        }

        [TestMethod]
        public void TestMethodSaveUser()
        {
            MockDb libraryDb = new MockDb();
            // List<UserDTO> userList = libraryDb.GetUsers();

            UserDTO testUser = new UserDTO("testUser4", "testPass4");

            // bool result = libraryDb.SaveUser(userList, testUser);
            // Assert.IsTrue(result);
            
            // Reinitialize the user list to baseline.
            // libraryDb.InitializeUserList();
        }
    }
}
