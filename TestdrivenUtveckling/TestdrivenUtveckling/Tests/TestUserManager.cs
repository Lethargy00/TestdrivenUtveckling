using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace TestdrivenUtveckling.Tests
{
    [TestFixture]
    internal class TestUserManager
    {
        private Mock<IDatabase> _mockDatabase;
        private UserManager _userManager;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new Mock<IDatabase>();
            _userManager = new UserManager(_mockDatabase.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _mockDatabase.VerifyAll();
        }

        [Test]
        public void TestAddUser()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "TestUser" };
            _mockDatabase.Setup(db => db.AddUser(user));

            // Act
            _userManager.AddUser(user);

            // Assert
            _mockDatabase.Verify(db => db.AddUser(user), Times.Once);
        }

        [Test]
        public void TestRemoveUser()
        {
            // Arrange
            var userId = 1;
            _mockDatabase.Setup(db => db.RemoveUser(userId));

            // Act
            _userManager.RemoveUser(userId);

            // Assert
            _mockDatabase.Verify(db => db.RemoveUser(userId), Times.Once);
        }

        [Test]
        public void TestGetUser()
        {
            // Arrange
            var userId = 1;
            var user = new User { UserId = userId, UserName = "TestUser" };
            _mockDatabase.Setup(db => db.GetUser(userId)).Returns(user);

            // Act
            var result = _userManager.GetUser(userId);

            // Assert
            ClassicAssert.AreEqual(user, result);
            _mockDatabase.Verify(db => db.GetUser(userId), Times.Once);
        }


    }
}
