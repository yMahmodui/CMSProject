﻿using Dtx.Security;
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
        public void GetPostWithoutAuth()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.GetPost(new GetPostViewModel.Request());

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsTrue(jsonResult.is_successful);

            Assert.IsInstanceOfType(jsonResult.data, typeof(GetPostViewModel.Response));
            var data = (GetPostViewModel.Response) jsonResult.data;
            Assert.IsNotNull(data);
            Assert.IsFalse(data.is_complete_passage);
        }

        [TestMethod]
        public void GetPostWithAuth()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.GetPost(new GetPostViewModel.Request
            {
                token = JWT.GetToken("test@localhost.com")
            });

            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result.Data, typeof(JsonResultViewModel));
            var jsonResult = (JsonResultViewModel) result.Data;
            Assert.IsNotNull(jsonResult);
            Assert.IsTrue(jsonResult.is_successful);

            Assert.IsInstanceOfType(jsonResult.data, typeof(GetPostViewModel.Response));
            var data = (GetPostViewModel.Response) jsonResult.data;
            Assert.IsNotNull(data);
            Assert.IsTrue(data.is_complete_passage);
        }
    }
}