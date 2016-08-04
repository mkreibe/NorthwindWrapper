using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the purchase order status.
    /// </summary>
    [AccessTable("Purchase Order Status", "Status ID")]
    public class PurchaseOrderStatus
    {
        /// <summary>
        /// Get or set the status id
        /// </summary>
        [AccessColumn("Status ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the status name
        /// </summary>
        [AccessColumn("Status", true)]
        public string Name { get; set; }
    }
}
