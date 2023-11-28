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
            // Clean up resources after each test if needed.
        }

        [Test]
        public void TestAddUser()
        {
            // Arrange
            var user = new User
            {
                UserId = 1,
                UserName = "Test"
            };

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
            var expectedUser = new User
            {
                UserId = 1,
                UserName = "Test"
            };
            _mockDatabase.Setup(db => db.GetUser(userId)).Returns(expectedUser);

            // Act 
            var result = _userManager.GetUser(userId);

            // Assert
            ClassicAssert.AreEqual(expectedUser, result);
        }
    }
}
