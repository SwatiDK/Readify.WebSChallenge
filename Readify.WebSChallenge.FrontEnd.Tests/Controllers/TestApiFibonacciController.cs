using System.Net;
using System.Web.Http;
using System.Net.Http;
using ReadifyPuzzleCode.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ReadifyPuzzleCode.Tests
{
    [TestClass]
    public class TestApiFibonacciController
    {
        #region Initial Test Setup

        private ApiFibonacciController _controller;
        private HttpResponseMessage _response;

        [TestInitialize]
        public void Setup()
        {
            _controller = new ApiFibonacciController();
            _response = new HttpResponseMessage();
            _controller.Configuration = new HttpConfiguration();
            _controller.Request = new HttpRequestMessage();

        }

        #endregion

        #region Test cases for Fibonacci 

        [TestMethod]
        public void Fibonacci_PositiveInput_ExpectedPositiveOutput()
        {

            int input = 8;

            var expected = 21;

            var actual = _controller.Fibonacci(input);

            Assert.AreEqual(expected.ToString(), actual.Content.ReadAsStringAsync().Result);
        }

        [TestMethod]
        public void Fibonacci_ZeroValueInput_ExpectedZeroValueOutput()
        {

            int input = 0;
            var expected = 0;

            var actual = _controller.Fibonacci(input);

            Assert.AreEqual(expected.ToString(), actual.Content.ReadAsStringAsync().Result);
        }

        [TestMethod]
        public void Fibonacci_NegativeEvenInput_ExpectedNegativeEvenOutput()
        {

            var input = -6;
            var expected = -8;

            //Act
            var actual = _controller.Fibonacci(input);

            //Assert
            Assert.AreEqual(expected.ToString(), actual.Content.ReadAsStringAsync().Result);

        }

        [TestMethod]
        public void Fibonacci_NegativeOddInput_ExpectedNegativeOddOuput()
        {

            var input = -7;
            var expected = -13;

            //Act
            var actual = _controller.Fibonacci(input);

            //Assert
            Assert.AreEqual(expected.ToString(), actual.Content.ReadAsStringAsync().Result);

        }

        #endregion
    }
}
