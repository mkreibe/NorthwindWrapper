using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Options;
using NorthwindWrapper.Utilities;
using System.Collections.Generic;
using System.Reflection;

namespace NorthwindWrapper.Controllers
{
    /// <summary>
    /// Defines the shippers controller.
    /// </summary>
    [Route("data/{table}")]
    public class AccessController : Controller
    {
        /// <summary>
        /// Get the northwind settings.
        /// </summary>
        public AccessSettings Settings
        {
            get;
            private set;
        }

        private readonly Dictionary<string, Type> tables;

        /// <summary>
        /// Create the controller.
        /// </summary>
        /// <param name="settings">The northwind settings.</param>
        public AccessController(IOptions<AccessSettings> settings)
        {
            this.Settings = settings.Value;

            this.tables = new Dictionary<string, Type>();

            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach(Type type in assembly.GetTypes())
            {
                if(type.GetCustomAttribute<AccessTableAttribute>() != null) {
                    AddTable(type);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="type"></param>
        private void AddTable(Type type)
        {
            String name = AccessWrapper.GetTableName(type);
            if (name != null)
            {
                this.tables.Add(name.ToUpper().Replace(" ", ""), type);
            }
        }

        private Type GetTable(string name)
        {
            return this.tables[name.ToUpper()];
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
        /// Get the shipper collection.
        /// </summary>
        /// <returns>Returns the simplified collection of shippers</returns>
        [HttpGet]
        public async Task<object> Get(string table)
        {
            return await Task.Run(() => AccessWrapper.Get(this.Settings, GetTable(table), null).ToArray());
        }

        /// <summary>
        /// Get the specified shipper.
        /// </summary>
        /// <param name="id">The shipper to return. Setting this to "template" will return a structure to use.</param>
        /// <returns>Return a detailed set of shippers.</returns>
        [HttpGet("{id}")]
        public async Task<object> Get(string table, string id)
        {
            int realId;

            object result = null;
            if (int.TryParse(id, out realId))
            {
                result = AccessWrapper.Get(this.Settings, GetTable(table), realId).FirstOrDefault();
            }

            if (string.Compare("Template", id, true) == 0)
            {
                result = Activator.CreateInstance(GetTable(table));
            }

            if (result == null)
            {
                throw new ArgumentException("Invalid argument.");
            }

            return await Task.Run(() => result);
        }

        /// <summary>
        /// Update the shipper.
        /// </summary>
        /// <param name="id">The shipper to update.</param>
        /// <param name="detail">The shipper info to update.</param>
        /// <returns>Returns the updated shipper.</returns>
        [HttpPut("{id}")]
        public async Task<object> Put(string table, int id, [FromBody] object detail)
        {
            AccessWrapper.Modify(this.Settings, GetTable(table), id, detail);
            StatusCode(HttpStatusCode.Accepted);
            return await Get(table, id.ToString());
        }

        /// <summary>
        /// Create a new shipper.
        /// </summary>
        /// <param name="detail">The shipper details to create.</param>
        /// <returns>Returns the created shipper.</returns>
        [HttpPost]
        public async Task<object> Post(string table, [FromBody] object detail)
        {
            int? id = AccessWrapper.Add(this.Settings, GetTable(table), detail);
            StatusCode(id.HasValue ? HttpStatusCode.Created : HttpStatusCode.BadRequest);
            return await Get(table, id.ToString());
        }

        /// <summary>
        /// Delete a shipper from the collection.
        /// </summary>
        /// <param name="id">The shipper to delete.</param>
        /// <returns>Returns the shipper.</returns>
        [HttpDelete("{id}")]
        public async Task Delete(string table, int id)
        {
            StatusCode(HttpStatusCode.Accepted);
            await Task.Run(() => AccessWrapper.Delete(this.Settings, GetTable(table), id));
        }
    }
}
