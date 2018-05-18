using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReadifyPuzzleCode.Controllers
{
    /// <summary>
    /// Provides Reverse Words functionality
    /// </summary>
    [RoutePrefix("api")]
    public class ApiReverseWordsController : ApiControllerBase
    {
        #region ReverseWords

        /// <summary>
        /// Reverse the words in the input sentence
        /// </summary>
        /// <param name="sentence">String Input: a sequence of words seperated by space</param>
        /// <returns>String Output: a sequence of reversed words seperated by space</returns>
        [HttpGet]
        [Route("reversewords")]
        public HttpResponseMessage ReverseWords([FromUri]string sentence)
        {
            string Result = string.Empty;
            if (string.IsNullOrEmpty(sentence))
            {
                errorLog.Error("Exception in Reverse Words Null input: ");
                throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
            }
            try
            {
                //output can be acheived in three ways, to illustrate the possible ways created three different functions
                //1. UsingReverseStringFunction - uses the available functions in String Class
                //2. ReverseCompleteLoopingEachWord - Applies the logic of Complete looping through each word to reverse it
                //3. ReverseLoopingTillCenterOfEachWord - Applies the logic of Half looping till the center of each word to swap the letter

                //1. First Option
                //Result = ReverseUsingStringFunction(sentence);

                //2. Second option
                //Result = ReverseByCompleteLoopingEachWord(sentence);

                //3. Third option
                Result = ReverseByLoopingTillCenterOfEachWord(sentence);
            }
            catch (Exception ex)
            {
                errorLog.Error("Error in Reverse Words: " + ex.Message);
                Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }

            infoLog.Info("Reversed Words :" + Result + " Input: " + sentence);
            return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        private string ReverseUsingStringFunction(string inputString)
        {
            string _reversedString = string.Empty;


            //1. using Reverse function of String Class
            //Commented code starts here

            foreach (string str in inputString.Split(' '))
            {
                if (string.IsNullOrEmpty(_reversedString))
                {
                    _reversedString = new string(str.ToCharArray().Reverse().ToArray());
                }
                else
                {
                    _reversedString = _reversedString + ' ' + new string(str.ToCharArray().Reverse().ToArray());
                }
            }

            //Commented code ends here


            //2. using the basic logic of lopping through chracter array

            //string[] InputWords = inputString.Split(' ');

            //for (int i = 0; i < InputWords.Length; i++)
            //{
            //    for (int j = InputWords[i].ToCharArray().Length - 1; j >= 0; j--)
            //    {
            //        _reversedString = _reversedString + InputWords[i].ToCharArray()[j];
            //    }


            //    if (i < InputWords.Length - 1)
            //    {
            //        _reversedString = _reversedString + ' ';
            //    }
            //}

            //3. Looping through center of word and swapping the letters from both ends
            //string[] InputWords = inputString.Split(' ');

            //for (int i = 0; i < InputWords.Length; i++)
            //{
            //    Char[] wordstring = InputWords[i].ToArray();

            //    for (int index = 0, rindex = wordstring.Count() - 1; index < wordstring.Count() / 2; index++, rindex--)
            //    {
            //        char temp = wordstring[index];
            //        wordstring[index] = wordstring[rindex];
            //        wordstring[rindex] = temp;
            //    }
            //    _reversedString = _reversedString + new string(wordstring);


            //    if (i < InputWords.Length - 1)
            //    {
            //        _reversedString = _reversedString + ' ';
            //    }
            //}

            return _reversedString;
        }

        private string ReverseByCompleteLoopingEachWord(string inputString)
        {
            string _reversedString = string.Empty;

            //Output can be derived in three ways
            //1. using Reverse function of String Class
            //2. basic way of Looping through characters of the each word in string
            //3. Looping through center of word and swapping the letters from both ends

            //1. using Reverse function of String Class
            //Commented code starts here

            //foreach (string str in inputString.Split(' '))
            //{
            //    if (string.IsNullOrEmpty(_reversedString))
            //    {
            //        _reversedString = new string(str.ToCharArray().Reverse().ToArray());
            //    }
            //    else
            //    {
            //        _reversedString = _reversedString + ' ' + new string(str.ToCharArray().Reverse().ToArray());
            //    }
            //}

            //Commented code ends here


            //2. using the basic logic of lopping through chracter array

            string[] InputWords = inputString.Split(' ');

            for (int i = 0; i < InputWords.Length; i++)
            {
                for (int j = InputWords[i].ToCharArray().Length - 1; j >= 0; j--)
                {
                    _reversedString = _reversedString + InputWords[i].ToCharArray()[j];
                }


                if (i < InputWords.Length - 1)
                {
                    _reversedString = _reversedString + ' ';
                }
            }

            //3. Looping through center of word and swapping the letters from both ends
            //string[] InputWords = inputString.Split(' ');

            //for (int i = 0; i < InputWords.Length; i++)
            //{
            //    Char[] wordstring = InputWords[i].ToArray();

            //    for (int index = 0, rindex = wordstring.Count() - 1; index < wordstring.Count() / 2; index++, rindex--)
            //    {
            //        char temp = wordstring[index];
            //        wordstring[index] = wordstring[rindex];
            //        wordstring[rindex] = temp;
            //    }
            //    _reversedString = _reversedString + new string(wordstring);


            //    if (i < InputWords.Length - 1)
            //    {
            //        _reversedString = _reversedString + ' ';
            //    }
            //}

            return _reversedString;
        }

        private string ReverseByLoopingTillCenterOfEachWord(string inputString)
        {
            string _reversedString = string.Empty;

            //Output can be derived in two ways
            //1. using Reverse function of String Class
            //2. basic way of Looping throught characters of the each word in string

            //1. using Reverse function of String Class
            //Commented code starts here

            //foreach (string str in inputString.Split(' '))
            //{
            //    if (string.IsNullOrEmpty(_reversedString))
            //    {
            //        _reversedString = new string(str.ToCharArray().Reverse().ToArray());
            //    }
            //    else
            //    {
            //        _reversedString = _reversedString + ' ' + new string(str.ToCharArray().Reverse().ToArray());
            //    }
            //}

            //Commented code ends here


            //2. using the basic logic of lopping through chracter array

            string[] InputWords = inputString.Split(' ');

            for (int i = 0; i < InputWords.Length; i++)
            {
                Char[] wordstring = InputWords[i].ToArray();

                for (int index = 0, rindex = wordstring.Count() - 1; index < wordstring.Count() / 2; index++, rindex--)
                {
                    char temp = wordstring[index];
                    wordstring[index] = wordstring[rindex];
                    wordstring[rindex] = temp;
                }
                _reversedString = _reversedString + new string(wordstring);


                if (i < InputWords.Length - 1)
                {
                    _reversedString = _reversedString + ' ';
                }
            }

            return _reversedString;
        }

        #endregion
    }
}
