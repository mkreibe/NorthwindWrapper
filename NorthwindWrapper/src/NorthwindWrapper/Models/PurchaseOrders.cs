using NorthwindWrapper.Utilities;
using System;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines a purchase order.
    /// </summary>
    [AccessTable("Purchase Orders", "Purchase Order ID")]
    public class PurchaseOrders
    {
        /// <summary>
        /// Get or set the purchase order Id.
        /// </summary>
        [AccessColumn("Purchase Order ID", true)]
        public int Id { get; set; }

        /// <summary>
        /// Get or set the supplier Id.
        /// </summary>
        [AccessColumn("Supplier ID")]
        public int SupplierId { get; set; }

        /// <summary>
        /// Get or set the creating user.
        /// </summary>
        [AccessColumn("Created By")]
        public int CreatedBy { get; set; }

        /// <summary>
        /// Get or set the submitted date.
        /// </summary>
        [AccessColumn("Submitted Date")]
        public DateTime SubmittedDate { get; set; }

        /// <summary>
        /// Get or set the creation date.
        /// </summary>
        [AccessColumn("Creation Date")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Get or set the status id.
        /// </summary>
        [AccessColumn("Status ID")]
        public int StatusID { get; set; }

        /// <summary>
        /// Get or set the expected date.
        /// </summary>
        [AccessColumn("Expected Date")]
        public DateTime ExpectedDate { get; set; }

        /// <summary>
        /// Get or set the shipping fee.
        /// </summary>
        [AccessColumn("Shipping Fee")]
        public decimal ShippingFee { get; set; }

        /// <summary>
        /// Get or set the taxes.
        /// </summary>
        [AccessColumn("Taxes")]
        public decimal Taxes { get; set; }

        /// <summary>
        /// Get or set the payment date.
        /// </summary>
        [AccessColumn("Payment Date")]
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Get or set the payment amount.
        /// </summary>
        [AccessColumn("Payment Amount")]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Get or set the payment date.
        /// </summary>
        [AccessColumn("Payment Method")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Get or set the notes.
        /// </summary>
        [AccessColumn("Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Get or set the approved by.
        /// </summary>
        [AccessColumn("Approved By")]
        public int ApprovedBy { get; set; }

        /// <summary>
        /// Get or set the approved date.
        /// </summary>
        [AccessColumn("Approved Date")]
        public DateTime ApprovedDate { get; set; }

        /// <summary>
        /// Get or set the submitted by.
        /// </summary>
        [AccessColumn("Submitted By")]
        public int SubmittedBy { get; set; }
    }
}
