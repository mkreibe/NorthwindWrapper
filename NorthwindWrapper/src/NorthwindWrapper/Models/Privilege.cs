using NorthwindWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWrapper.Models
{

    /// <summary>
    /// Defines the privileges.
    /// </summary>
    [AccessTable("Privileges", "Privilege ID")]
    public class Privilege
    {
        /// <summary>
        /// Get or set the privilege id
        /// </summary>
        [AccessColumn("Privilege ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the privilege name
        /// </summary>
        [AccessColumn("Privilege Name", true)]
        public string Name { get; set; }
    }
}
