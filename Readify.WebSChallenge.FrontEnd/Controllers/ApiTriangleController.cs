using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReadifyPuzzleCode.Controllers
{
    /// <summary>
    /// Provides the Traingle type
    /// </summary>
    [RoutePrefix("api")]
    public class ApiTriangleController : ApiControllerBase
    {
        /// <summary>
        /// Displays the type of triangle based on the sides provided
        /// </summary>
        /// <param name="a">Int input variable : 1st Side of the traingle</param>
        /// <param name="b">Int input variable : 2nd Side of the traingle</param>
        /// <param name="c">Int input variable : 3rd Side of the traingle</param>
        /// <returns>String :Type of the triangle </returns>
        [HttpGet]
        [Route("TriangleType")]
        public HttpResponseMessage TriangleType([FromUri]int a, [FromUri]int b, [FromUri]int c)
        {
            string Result = string.Empty;

            try
            {
                Result = ReturnTraingleTypeBySides(a, b, c);
            }
            catch (Exception ex)
            {
                errorLog.Info("Error in Triangle Type: " + ex.Message);
                Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }

            infoLog.Info("Triangle Type :" + Result + " For Sides :" + a + "," + b + "," + c);
            return Request.CreateResponse(HttpStatusCode.OK, Result);
        }

        private string ReturnTraingleTypeBySides(int side1, int side2, int side3)
        {
            string Result = string.Empty;

            //Output can be derived in two ways
            //1. using dictionary object and distinct.count() function
            //2. basic way of comparing three sides values

            if (side1 <= 0 || side1 <= 0 || side1 <= 0)
            {
                return "Error";
            }
            else
            {
                ////1. using dictionary object 
                //commented code starts here

                //int[] sideArray = new int[3] { side1, side2, side3 };

                //Dictionary<int, string> TriangleTypeNames = new Dictionary<int, string>() {
                //                                        {1, "Equilateral" },
                //                                        {2, "Isosceles" },
                //                                        {3, "Scalene" },
                //                                        {4, "Error" } };

                //var typename = TriangleTypeNames.Where(z => z.Key == sideArray.Distinct().Count()).FirstOrDefault().Value;

                //Result = typename;

                //commented code ends here

                ////2. basic way of comparing three sides values

                if (((side1 == side2) && (side1 != side3)) || ((side1 == side3) && (side1 != side2)) || ((side2 == side3) && (side1 != side3)))
                {
                    Result = "Isosceles";
                }
                else if (((side1 == side2) && (side1 == side3)))
                {
                    Result = "Equilateral";
                }
                else if (((side1 != side2) && (side1 != side3)))
                {
                    Result = "Scalene";
                }
            }
            return Result;
        }


    }

}
