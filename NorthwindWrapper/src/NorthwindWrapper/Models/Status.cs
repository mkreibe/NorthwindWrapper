using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the base status.
    /// </summary>
    public abstract class Status
    {
        /// <summary>
        /// Get or set the status id
        /// </summary>
        [AccessColumn("Status ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the status name
        /// </summary>
        [AccessColumn("Status Name", true)]
        public string Name { get; set; }
    }
}
