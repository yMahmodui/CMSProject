using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMVCApp.Controllers;
using ViewModels.General;
using ViewModels.Home;

namespace MyMVCApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            JsonResult result = controller.GetPost(new GetPostViewModel.Request()) as JsonResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(true, ((JsonResultViewModel) result.Data).is_successful);
        }
    }
}
