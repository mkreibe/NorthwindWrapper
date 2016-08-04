using NorthwindWrapper.Utilities;
using System;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the invoice model.
    /// </summary>
    [AccessTable("Invoices", "Invoice ID")]
    public class Invoice
    {
        /// <summary>
        /// Get or set the invoice id.
        /// </summary>
        [AccessColumn("Invoice ID")]
        public int InvoiceID { get; set; }

        /// <summary>
        /// Get or set the Order id.
        /// </summary>
        [AccessColumn("Order ID")]
        public int OrderID { get; set; }

        /// <summary>
        /// Get or set the invoice date.
        /// </summary>
        [AccessColumn("Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Get or set the due date.
        /// </summary>
        [AccessColumn("Due Date")]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Get or set the tax.
        /// </summary>
        [AccessColumn("Tax")]
        public decimal Tax { get; set; }

        /// <summary>
        /// Get or set the shipping.
        /// </summary>
        [AccessColumn("Shipping")]
        public decimal Shipping { get; set; }

        /// <summary>
        /// Get or set the amount due.
        /// </summary>
        [AccessColumn("Amount Due")]
        public decimal AmmountDue { get; set; }
    }
}
