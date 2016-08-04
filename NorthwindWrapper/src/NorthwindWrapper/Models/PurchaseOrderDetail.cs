using NorthwindWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the purchase order details.
    /// </summary>
    [AccessTable("Purchase Order Details", "ID")]
    public class PurchaseOrderDetail
    {
        /// <summary>
        /// Get or set the details id.
        /// </summary>
        [AccessColumn("ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the purchase order id.
        /// </summary>
        [AccessColumn("Purchase Order ID")]
        public int PurchaseOrderID { get; set; }

        /// <summary>
        /// Get or set the product id.
        /// </summary>
        [AccessColumn("Product ID")]
        public int ProductID { get; set; }

        /// <summary>
        /// Get or set the quantity.
        /// </summary>
        [AccessColumn("Quantity")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Get or set the unit cost.
        /// </summary>
        [AccessColumn("Unit Cost")]
        public decimal UnitCost { get; set; }

        /// <summary>
        /// Get or set the date received.
        /// </summary>
        [AccessColumn("Date Received")]
        public DateTime DateReceived { get; set; }

        /// <summary>
        /// Get or set the posted to inventory flag.
        /// </summary>
        [AccessColumn("Posted To Inventory")]
        public bool PostedToInventory { get; set; }

        /// <summary>
        /// Get or set the inventory id.
        /// </summary>
        [AccessColumn("Inventory ID")]
        public int InventoryID { get; set; }
    }
}
