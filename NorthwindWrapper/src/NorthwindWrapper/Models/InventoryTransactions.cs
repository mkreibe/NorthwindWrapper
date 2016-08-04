using NorthwindWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the inventory transaction.
    /// </summary>
    [AccessTable("Inventory Transactions", "Transaction ID")]
    public class InventoryTransaction
    {
        /// <summary>
        /// Get or set the transaction id.
        /// </summary>
        [AccessColumn("Transaction ID")]
        public int TransactionID { get; set; }

        /// <summary>
        /// Get or set the transaction type.
        /// </summary>
        [AccessColumn("Transaction Type")]
        public int TransactionType { get; set; }

        /// <summary>
        /// Get or set the transaction creation date.
        /// </summary>
        [AccessColumn("Transaction Created Date")]
        public DateTime TransactionCreatedDate { get; set; }

        /// <summary>
        /// Get or set the transaction modified date.
        /// </summary>
        [AccessColumn("Transaction Modified Date")]
        public DateTime TransactionModifiedDate { get; set; }

        /// <summary>
        /// Get or set the product id
        /// </summary>
        [AccessColumn("Product ID")]
        public int ProductID { get; set; }

        /// <summary>
        /// Get or set the quantity.
        /// </summary>
        [AccessColumn("Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Get or set the purchase order ID.
        /// </summary>
        [AccessColumn("Purchase Order ID")]
        public int PurchaseOrderID { get; set; }

        /// <summary>
        /// Get or set the customer order ID.
        /// </summary>
        [AccessColumn("Customer Order ID")]
        public int CustomerOrderID { get; set; }

        /// <summary>
        /// Get or set the comments.
        /// </summary>
        [AccessColumn("Comments")]
        public string Comments { get; set; }
    }
}
