using NorthwindWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the orders tax status.
    /// </summary>
    [AccessTable("Orders Tax Status", "ID")]
    public class OrdersTaxStatus
    {
        /// <summary>
        /// Get or set the status id
        /// </summary>
        [AccessColumn("ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the status name
        /// </summary>
        [AccessColumn("Tax Status Name", true)]
        public string Name { get; set; }
    }
}
