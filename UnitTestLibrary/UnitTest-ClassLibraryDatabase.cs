using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

using ClassLibraryDatabase;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTestClasslibraryDatabase
    {
        [TestMethod]
        public void TestMethodClassLibraryDatabase()
        {
            MockDb libraryDb = new MockDb();

            List<UserDTO> userList = libraryDb.GetUsers();
            Assert.IsNotNull(userList);
            //Assert.AreEqual(3, userList.Count);
            //Assert.AreEqual(userList[0].UserId, 1);
            //Assert.AreEqual(userList[1].UserId, 2);
            //Assert.AreEqual(userList[2].UserId, 3);
        }
    }
}
