using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using ClassLibraryCommon;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTestClassLibraryCommon
    {
        [TestMethod]
        public void TestMethodCreateRoleDTO()
        {
            // ClassLibraryCommon.RoleDTO role = new RoleDTO("TestRole");
            // Assert.IsNotNull(role);
        }

        [TestMethod]
        public void TestMethodValidateRoleAttributes()
        {
            //ClassLibraryCommon.RoleDTO role = new RoleDTO("TestRole");
            //Assert.AreEqual(role.Name, "TestRole");
            //Assert.AreEqual(role.RoleId, 5);
        }
        
        [TestMethod]
        public void TestMethodCreateUserDTO()
        {
            UserDTO user = new UserDTO("TestUser", "TestUserPass");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void TestMethodValidateUserAttributes()
        {
            UserDTO user = new UserDTO("TestUser", "TestUserPass");
            Assert.AreEqual(user.Name, "TestUser");
            Assert.AreEqual(user.Password, "TestUserPass");
            Assert.AreEqual(user.UserId, 4);
        }
    }
}
