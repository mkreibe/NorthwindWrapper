using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindWrapper.Models;
using NorthwindWrapper.Utilities;
using Microsoft.Extensions.Options;

namespace NorthwindWrapper.Controllers
{
    /// <summary>
    /// Defines the status controller.
    /// </summary>
    [Route("status")]
    public class StatusController : Controller
    {
        /// <summary>
        /// Get the northwind settings.
        /// </summary>
        public AccessSettings Settings
        {
            get;
            private set;
        }

        /// <summary>
        /// Create the controller.
        /// </summary>
        /// <param name="settings">The northwind settings.</param>
        public StatusController(IOptions<AccessSettings> settings)
        {
            this.Settings = settings.Value;
        }

        /// <summary>
        /// Get the status of the system.
        /// </summary>
        /// <returns>Returns the status.</returns>
        [HttpGet]
        public async Task<SystemStatus> Get()
        {
            return await Task.Run(() => new SystemStatus(this.Settings));
        }
    }
}
