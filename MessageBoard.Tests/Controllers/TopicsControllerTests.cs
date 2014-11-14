using System;
using System.Linq;
using MessageBoard.Controllers;
using MessageBoard.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MessageBoard.Tests.Controllers
{
    [TestClass]
    public class TopicsControllerTests
    {
        private TopicsController _ctrl;

        [TestInitialize]
        public void Init()
        {
            _ctrl = new TopicsController(new FakeMessageBoardRepository());
        }
        
        [TestMethod]
        public void TopicsController_Get()
        {
            var results = _ctrl.Get(true);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
            Assert.IsNotNull(results.First());
            Assert.IsNotNull(results.First().Title);
        }
    }
}
