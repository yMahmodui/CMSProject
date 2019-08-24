using Dtx.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMVCApp.Controllers;
using ViewModels.AdminPanel;
using ViewModels.General;

namespace MyMVCApplication.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void GetRegisteredUsersWithoutAuth()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            var result = controller.GetRegisteredUsers(new GetRegisteredUsersViewModel.Request());

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsFalse(jsonResult.is_successful);
        }

        [TestMethod]
        public void GetRegisteredUsersWithAuth()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            var result = controller.GetRegisteredUsers(new GetRegisteredUsersViewModel.Request
            {
                token = JWT.GetToken("admin@localhost.com")
            });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsTrue(jsonResult.is_successful);

            Assert.IsInstanceOfType(jsonResult.data, typeof(GetRegisteredUsersViewModel.Response));
            var data = (GetRegisteredUsersViewModel.Response) jsonResult.data;
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.users);
            Assert.AreNotEqual(0, data.users.Count);
        }
    }
}