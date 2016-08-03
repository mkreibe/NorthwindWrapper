using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindWrapper.Models;
using System.Net;
using Microsoft.Extensions.Options;
using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Controllers
{
    [Route("api/[controller]")]
    public class ShippersController : Controller
    {
        public NorthwindSettings Settings
        {
            get;
            private set;
        }

        public ShippersController(IOptions<NorthwindSettings> settings)
        {
            this.Settings = settings.Value;
        }

        /// <summary>
        /// Set the status code.
        /// </summary>
        /// <param name="code">The code to set.</param>
        private void StatusCode(HttpStatusCode code)
        {
            this.StatusCode((int)code);
        }

        /// <summary>
        /// Get the shipper.
        /// </summary>
        /// <param name="id">The shipper to return.</param>
        /// <returns>Returns the simplified collection of </returns>
        [HttpGet]
        public async Task<Shipper[]> Get()
        {
            return await Task.Run(() => Shipper.GetShippers<Shipper>(this.Settings, null).ToArray());
        }

        /// <summary>
        /// Get the real shipper.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ShipperDetail> Get(string id)
        {
            int realId;

            ShipperDetail result = null;
            if (int.TryParse(id, out realId))
            {
                result = Shipper.GetShippers<ShipperDetail>(this.Settings, realId).FirstOrDefault();
            }

            if (string.Compare("Template", id, true) == 0)
            {
                result = new ShipperDetail();
            }

            if (result == null)
            {
                throw new ArgumentException("Invalid argument.");
            }

            return await Task.Run(() => result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ShipperDetail> Put(int id, [FromBody] ShipperDetail detail)
        {
            ShipperDetail.Modify(this.Settings, id, detail);
            StatusCode(HttpStatusCode.Accepted);
            return await Get(id.ToString());
        }

        [HttpPost]
        public async Task<ShipperDetail> Post([FromBody] ShipperDetail detail)
        {
            int id = ShipperDetail.Add(this.Settings, detail);
            StatusCode(HttpStatusCode.Created);
            return await Get(id.ToString());
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            StatusCode(HttpStatusCode.Accepted);
            await Task.Run(() => Shipper.Delete(this.Settings, id));
        }
    }
}
