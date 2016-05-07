using System.Web.Mvc;
using NUnit.Framework;
using Web.Controllers;

namespace UnitTest
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void TestMethod1()
        {
            // Assemble
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<ActionResult>(result);
        }
    }
}
