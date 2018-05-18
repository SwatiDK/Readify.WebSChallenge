using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReadifyPuzzleCode.Controllers
{
    /// <summary>
    /// Provides the token 
    /// </summary>
    [RoutePrefix("api")]
    public class ApiTokenController : ApiControllerBase
    {
        #region Token

        /// <summary>
        /// Shows the Token provided in the mail
        /// </summary>
        /// <returns>String : encrypted token code </returns>

        [HttpGet]
        [Route("token")]
        public HttpResponseMessage Token()
        {
            string Result = "9d45e462-2951-4270-ad66-4a46b2b1e873";

            infoLog.Info("Token Generated :" + Result);

            return Request.CreateResponse(HttpStatusCode.OK, Result, Configuration.Formatters.JsonFormatter);
        }

        #endregion
    }
}
