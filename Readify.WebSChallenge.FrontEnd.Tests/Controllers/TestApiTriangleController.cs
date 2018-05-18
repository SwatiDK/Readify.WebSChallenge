using System.Net;
using System.Web.Http;
using System.Net.Http;
using ReadifyPuzzleCode.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReadifyPuzzleCode.Tests
{
    [TestClass]
    public class TestApiTriangleController
    {
        #region Initial Test Setup

        private ApiTriangleController _controller;
        private HttpResponseMessage _response;

        [TestInitialize]
        public void Setup()
        {
            _controller = new ApiTriangleController();
            _response = new HttpResponseMessage();
            _controller.Configuration = new HttpConfiguration();
            _controller.Request = new HttpRequestMessage();

        }

        #endregion

        #region Test cases for Triangle Type

        [TestMethod]
        public void TriangleType_TwoEqualOneDiffSidesIn_ExpectedIsosceles()
        {
            var inputA = 3;
            var inputB = 3;
            var inputC = 4;

            var expected = "Isosceles";

            var actual = _controller.TriangleType(inputA, inputB, inputC);

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        [TestMethod]
        public void TriangleType_ThreeDiffSidesIn_ExpectedScalene()
        {
            var inputA = 3;
            var inputB = 2;
            var inputC = 4;

            var expected = "Scalene";

            var actual = _controller.TriangleType(inputA, inputB, inputC);

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        [TestMethod]
        public void TriangleType_ThreeEqualSidesIn_ExpectedEquilateral()
        {
            var inputA = 3;
            var inputB = 3;
            var inputC = 3;

            var expected = "Equilateral";

            var actual = _controller.TriangleType(inputA, inputB, inputC);

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        [TestMethod]
        public void TriangleType_AllZeroSidesIn_ExpectedErrorOut()
        {
            var inputA = 0;
            var inputB = 0;
            var inputC = 0;

            var expected = "Error";

            var actual = _controller.TriangleType(inputA, inputB, inputC);

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        [TestMethod]
        public void TriangleType_AllNegativeSidesIn_ExpectedErrorOut()
        {
            var inputA = -1;
            var inputB = -2;
            var inputC = -3;

            var expected = "Error";

            var actual = _controller.TriangleType(inputA, inputB, inputC);

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        #endregion
    }
}
