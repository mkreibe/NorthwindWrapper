using NorthwindWrapper.Utilities;
using System;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the orers model.
    /// </summary>
    [AccessTable("Orders", "Order ID")]
    public class Order
    {
        /// <summary>
        /// Get or set the order id.
        /// </summary>
        [AccessColumn("Order ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the employee id.
        /// </summary>
        [AccessColumn("Employee ID")]
        public int EmployeeID { get; set; }

        /// <summary>
        /// Get or set the customer id.
        /// </summary>
        [AccessColumn("Customer ID")]
        public int CustomerID { get; set; }

        /// <summary>
        /// Get or set the order date.
        /// </summary>
        [AccessColumn("Order Date")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Get or set the shipped date.
        /// </summary>
        [AccessColumn("Shipped Date")]
        public DateTime ShippedDate { get; set; }

        /// <summary>
        /// Get or set the shipper id.
        /// </summary>
        [AccessColumn("Shipper ID")]
        public int ShipperID { get; set; }

        /// <summary>
        /// Get or set the ship name.
        /// </summary>
        [AccessColumn("Ship Name")]
        public string ShipName { get; set; }

        /// <summary>
        /// Get or set the ship address.
        /// </summary>
        [AccessColumn("Ship Address")]
        public string ShipAddress { get; set; }

        /// <summary>
        /// Get or set the ship city.
        /// </summary>
        [AccessColumn("Ship City")]
        public string ShipCity { get; set; }

        /// <summary>
        /// Get or set the ship postal code.
        /// </summary>
        [AccessColumn("Ship ZIP/Postal Code")]
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// Get or set the ship country.
        /// </summary>
        [AccessColumn("Ship Country/Region")]
        public string ShipCountry { get; set; }
        
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
        /// Get or set the notes.
        /// </summary>
        [AccessColumn("Payment Type")]
        public string PaymentType { get; set; }

        /// <summary>
        /// Get or set the paid date.
        /// </summary>
        [AccessColumn("Paid Date")]
        public DateTime PaidDate { get; set; }

        /// <summary>
        /// Get or set the notes.
        /// </summary>
        [AccessColumn("Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Get or set the tax rate.
        /// </summary>
        [AccessColumn("Tax Rate")]
        public double TaxRate { get; set; }

        /// <summary>
        /// Get or set the tax status.
        /// </summary>
        [AccessColumn("Tax Status")]
        public int TaxStatus { get; set; }

        /// <summary>
        /// Get or set the status id.
        /// </summary>
        [AccessColumn("Status ID")]
        public byte StatusID { get; set; }
    }
}
