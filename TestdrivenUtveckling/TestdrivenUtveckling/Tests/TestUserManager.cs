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

        /// <summary>
        /// Creates a mock database and user manager for each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockDatabase = new Mock<IDatabase>();
            _userManager = new UserManager(_mockDatabase.Object);
        }

        /// <summary>
        /// Verify that all expectations were met.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            _mockDatabase.VerifyAll();
        }

        /// <summary>
        /// Test that AddUser calls AddUser on the database exactly once.
        /// </summary>
        [Test]
        public void TestAddUser()
        {
            // Arrange: create a test user.
            var user = new User { UserId = 1, UserName = "TestUser" };
            _mockDatabase.Setup(db => db.AddUser(user));

            // Act: call AddUser on the user manager.
            _userManager.AddUser(user);

            // Assert: Verify that AddUser was called on the database.
            _mockDatabase.Verify(db => db.AddUser(user), Times.Once);
        }

        /// <summary>
        /// Test that RemoveUser calls RemoveUser on the database exactly once.
        /// </summary>
        [Test]
        public void TestRemoveUser()
        {
            // Arrange: created a test user ID.
            var userId = 1;
            _mockDatabase.Setup(db => db.RemoveUser(userId));

            // Act: call RemoveUser on the user manager.
            _userManager.RemoveUser(userId);

            // Assert: verify that RemoveUser was called on the database.
            _mockDatabase.Verify(db => db.RemoveUser(userId), Times.Once);
        }

        /// <summary>
        /// Test that GetUser calls GetUser on the database exactly once and returns the correct user.
        /// </summary>
        [Test]
        public void TestGetUser()
        {
            // Arrange: create a test user ID and user.
            var userId = 1;
            var user = new User { UserId = userId, UserName = "TestUser" };
            _mockDatabase.Setup(db => db.GetUser(userId)).Returns(user);

            // Act: call GetUser on the user manager.
            var result = _userManager.GetUser(userId);

            // Assert: verify that GetUser was called on the database and the returned user is correct.
            ClassicAssert.AreEqual(user, result);
            _mockDatabase.Verify(db => db.GetUser(userId), Times.Once);
        }

    }
}
