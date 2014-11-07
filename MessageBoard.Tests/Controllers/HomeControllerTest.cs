using System.Web.Mvc;
using MessageBoard.Services;
using MessageBoard.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MessageBoard.Controllers;

namespace MessageBoard.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IMailService _mailService;
        
        [TestInitialize]
        public void TestInitialize()
        {
            _mailService = new MockMailService();            
        }
        
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_mailService);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(_mailService);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(_mailService);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
