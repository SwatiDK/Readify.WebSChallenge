using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReadifyPuzzleCode.Controllers
{

    /// <summary>
    /// Provides the functionality for Fibonacci
    /// </summary>

    [RoutePrefix("api")]
    public class ApiFibonacciController : ApiControllerBase
    {
        #region Fibonacci

        /// <summary>
        /// Returns the nth element of fibonacci series
        /// </summary>
        /// <param name="n">Long Number: position of the element in the fibonacci series</param>
        /// <returns>
        /// 
        /// HttpResponse object : Status code - OK, Nth Element with JSON format
        /// HttpResponseException: Status Code - PreconditionFailed if input is incorrect
        /// HttpResponse : Status Code - Not found with exception message
        /// </returns>
        [HttpGet]
        [Route("fibonacci")]
        public HttpResponseMessage Fibonacci([FromUri]long n)
        {
            long Result = 0;
            if (n == null)
            {
                errorLog.Error("Exception in Fibonacci Null Input ");
                throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
            }
            try
            {
                Result = CalculateNthElement(n);
            }
            catch (Exception ex)
            {
                errorLog.Error("Error in Fibonacci: " + ex.Message);
                Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }

            infoLog.Info("Fibonacci Nth Element :" + Result + " N: " + n);
            return Request.CreateResponse(HttpStatusCode.OK, Result, Configuration.Formatters.JsonFormatter);
        }

        private long CalculateNthElement(long n)
        {
            try
            {
                long result = 0;
                if (n == 0 || n == 1)
                {
                    result = n;
                }
                else
                {
                    Int64 index = Math.Abs(n);

                    long[] FibSeries = new long[index + 1];

                    //set initial values
                    FibSeries[0] = 0;
                    FibSeries[1] = 1;

                    for (Int64 i = 2; i <= index; i++)
                    {
                        FibSeries[i] = FibSeries[i - 2] + FibSeries[i - 1];
                    }

                    if (n > 0)
                    {
                        result = FibSeries[index];
                    }
                    else
                    {
                        result = -FibSeries[index];
                    }

                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //#region Fibonacci

        ///// <summary>
        ///// Returns the nth element of fibonacci series
        ///// </summary>
        ///// <param name="n">Long Number: position of the element in the fibonacci series</param>
        ///// <returns>
        ///// 
        ///// HttpResponse object : Status code - OK, Nth Element with JSON format
        ///// HttpResponseException: Status Code - PreconditionFailed if input is incorrect
        ///// HttpResponse : Status Code - Not found with exception message
        ///// </returns>

        //[HttpGet]
        //[Route("fibonacci")]
        //public HttpResponseMessage Get([FromUri]long n)
        //{
        //    long Result = 0;
        //    if (n == null)
        //    {
        //        errorLog.Error("Exception in Fibonacci Null Input ");
        //        throw new HttpResponseException(HttpStatusCode.PreconditionFailed);
        //    }
        //    try
        //    {
        //        Result = Fibonacci(n);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorLog.Error("Error in Fibonacci: " + ex.Message);
        //        Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
        //    }

        //    infoLog.Info("Fibonacci Nth Element :" + Result + " N: " + n);
        //    return Request.CreateResponse(HttpStatusCode.OK, Result, Configuration.Formatters.JsonFormatter);
        //}

        //private long Fibonacci(long n)
        //{
        //    try
        //    {
        //        long result = 0;
        //        if (n == 0 || n == 1)
        //        {
        //            result = n;
        //        }
        //        else
        //        {
        //            Int64 index = Math.Abs(n);

        //            long[] FibSeries = new long[index + 1];

        //            //set initial values
        //            FibSeries[0] = 0;
        //            FibSeries[1] = 1;

        //            for (Int64 i = 2; i <= index; i++)
        //            {
        //                FibSeries[i] = FibSeries[i - 2] + FibSeries[i - 1];
        //            }

        //            if (n > 0)
        //            {
        //                result = FibSeries[index];
        //            }
        //            else
        //            {
        //                result = -FibSeries[index];
        //            }

        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#endregion

        #endregion
    }
}
