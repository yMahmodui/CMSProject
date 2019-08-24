using Dtx.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMVCApp.Controllers;
using ViewModels.Authorization;
using ViewModels.General;

namespace MyMVCApplication.Tests.Controllers
{
    [TestClass]
    public class AuthorizationControllerTest
    {
        [TestMethod]
        public void Login()
        {
            // Arrange
            var controller = new AuthorizationController();

            // Act
            var result = controller.Login(new LoginViewModel.Request
            {
                email = "test@localhost.com",
                hash = Hashing.GetMD5("password")
            });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsTrue(jsonResult.is_successful);

            Assert.IsInstanceOfType(jsonResult.data, typeof(LoginViewModel.Response));
            var data = (LoginViewModel.Response) jsonResult.data;
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.access_token);
        }

        [TestMethod]
        public void Register()
        {
            // Arrange
            var controller = new AuthorizationController();

            // Act
            var result = controller.Register(new RegisterViewModel.Request
            {
                email = "test_register@localhost.com",
                hash = Hashing.GetMD5("password")
            });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsTrue(jsonResult.is_successful);

            Assert.IsInstanceOfType(jsonResult.data, typeof(RegisterViewModel.Response));
            var data = (RegisterViewModel.Response) jsonResult.data;
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.access_token);
        }

        [TestMethod]
        public void RegisterDuplicateEmail()
        {
            // Arrange
            var controller = new AuthorizationController();

            // Act
            var result = controller.Register(new RegisterViewModel.Request
            {
                email = "test@localhost.com",
                hash = Hashing.GetMD5("password")
            });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsFalse(jsonResult.is_successful);
        }

        [TestMethod]
        public void RegisterInvalidEmail()
        {
            // Arrange
            var controller = new AuthorizationController();

            // Act
            var result = controller.Register(new RegisterViewModel.Request
            {
                email = "test",
                hash = Hashing.GetMD5("password")
            });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsFalse(jsonResult.is_successful);
        }

        [TestMethod]
        public void RegisterWeakPassword()
        {
            // Arrange
            var controller = new AuthorizationController();

            // Act
            var result = controller.Register(new RegisterViewModel.Request
            {
                email = "test2@localhost.com",
                hash = "pass"
            });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsFalse(jsonResult.is_successful);
        }
    }
}