using System.Web.Http;
using log4net;

namespace ReadifyPuzzleCode.Controllers
{
    /// <summary>
    /// Base controller for Error Log and Info Log settings
    /// </summary>
    public class ApiControllerBase : ApiController
    {
        public readonly ILog errorLog = LogManager.GetLogger("ErrorLog");
        public readonly ILog infoLog = LogManager.GetLogger("InfoLog");
    }
}
