using System.Net;
using System.Web.Http;
using System.Net.Http;
using ReadifyPuzzleCode.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReadifyPuzzleCode.Tests
{
    [TestClass]
    public class TestApiReverseWordsController
    {
        #region Initial Test Setup

        private ApiReverseWordsController _controller;
        private HttpResponseMessage _response;

        [TestInitialize]
        public void Setup()
        {
            _controller = new ApiReverseWordsController();
            _response = new HttpResponseMessage();
            _controller.Configuration = new HttpConfiguration();
            _controller.Request = new HttpRequestMessage();

        }

        #endregion

        #region Test cases for Reverse Words

        [TestMethod]
        public void ReverseWords_WordsWithSpcaeIn_ExpectedReverseWordsOut()
        {
            var input = "hi how are you";

            var expected = "ih woh era uoy";

            var actual = _controller.ReverseWords(input);


            Assert.AreEqual(HttpStatusCode.OK, actual.StatusCode);
            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        [TestMethod]
        public void ReverseWords_WordsWithNumbersIn_ExpectedReverseWordsWithNumbersOut()
        {
            var input = "765 hi how are you";
            var expected = "567 ih woh era uoy";

            var actual = _controller.ReverseWords(input);

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        [TestMethod]
        public void ReverseWords_WordsWithSpecialCharIn_ExpectedReverseWordsWithSpecialCharOut()
        {
            var input = "hi how are you?";
            var expected = "ih woh era ?uoy";

            var actual = _controller.ReverseWords(input);

            Assert.AreEqual(expected, (actual.Content).ReadAsAsync<string>().Result.Trim());

        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void ReverseWords_NullInput_ExceptionExpected()
        {
            try
            {
                string input = null;
                var actual = _controller.ReverseWords(input);
            }
            catch (HttpResponseException ex)
            {
                Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.PreconditionFailed);
                throw;
            }
        }

        #endregion
    }
}
