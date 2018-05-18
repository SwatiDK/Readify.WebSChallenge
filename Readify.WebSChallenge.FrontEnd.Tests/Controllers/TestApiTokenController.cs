using System.Net;
using System.Web.Http;
using System.Net.Http;
using ReadifyPuzzleCode.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReadifyPuzzleCode.Tests
{
    [TestClass]
    public class TestApiTokenController
    {
        #region Initial Test Setup

        private ApiTokenController _controller;
        private HttpResponseMessage _response;

        [TestInitialize]
        public void Setup()
        {
            _controller = new ApiTokenController();
            _response = new HttpResponseMessage();
            _controller.Configuration = new HttpConfiguration();
            _controller.Request = new HttpRequestMessage();

        }

        #endregion

        #region Test cases for Token

        [TestMethod]
        public void Token_ExpectedTokenOutput()
        {
            var expected = "9d45e462-2951-4270-ad66-4a46b2b1e873";
            var actual = _controller.Token();

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());
        }

        #endregion
    }
}
