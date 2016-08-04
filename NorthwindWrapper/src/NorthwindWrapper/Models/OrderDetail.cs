using NorthwindWrapper.Utilities;
using System;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the order detail model.
    /// </summary>
    [AccessTable("Order Details", "ID")]
    public class OrderDetail
    {
        /// <summary>
        /// Get or set the detail id.
        /// </summary>
        [AccessColumn("ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the order id.
        /// </summary>
        [AccessColumn("Order ID")]
        public int OrderID { get; set; }

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
        /// Get or set the unit price.
        /// </summary>
        [AccessColumn("Unit Price")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Get or set the discount.
        /// </summary>
        [AccessColumn("Discount")]
        public double Discount { get; set; }

        /// <summary>
        /// Get or set the status ID.
        /// </summary>
        [AccessColumn("Status ID")]
        public int StatusID { get; set; }

        /// <summary>
        /// Get or set the date allocated.
        /// </summary>
        [AccessColumn("Date Allocated")]
        public DateTime DateAllocated { get; set; }

        /// <summary>
        /// Get or set the purchase order id.
        /// </summary>
        [AccessColumn("Purchase Order ID")]
        public int PurchaseOrderID { get; set; }

        /// <summary>
        /// Get or set the purchase order id.
        /// </summary>
        [AccessColumn("Inventory ID")]
        public int InventoryID { get; set; }
    }
}
