using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{

    /// <summary>
    /// Defines a product
    /// </summary>
    [AccessTable("Products", "ID")]
    public class Product
    {
        /// <summary>
        /// Get or set the supplier id.
        /// </summary>
        [AccessColumn("Supplier IDs")]
        public string SupplierID { get; set; }

        /// <summary>
        /// Get or set the product id.
        /// </summary>
        [AccessColumn("ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the product code.
        /// </summary>
        [AccessColumn("Product Code")]
        public string ProductCode { get; set; }

        /// <summary>
        /// Get or set the product name.
        /// </summary>
        [AccessColumn("Product Name")]
        public string ProductName { get; set; }

        /// <summary>
        /// Get or set the product description.
        /// </summary>
        [AccessColumn("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Get or set the product cost.
        /// </summary>
        [AccessColumn("Standard Cost")]
        public decimal StandardCost { get; set; }

        /// <summary>
        /// Get or set the list price.
        /// </summary>
        [AccessColumn("List Price")]
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Get or set the reorder level.
        /// </summary>
        [AccessColumn("Reorder Level")]
        public int ReorderLevel { get; set; }

        /// <summary>
        /// Get or set the target level.
        /// </summary>
        [AccessColumn("Target Level")]
        public int TargetLevel { get; set; }

        /// <summary>
        /// Get or set the quantity / unit.
        /// </summary>
        [AccessColumn("Quantity Per Unit")]
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Get or set the discontinued flag.
        /// </summary>
        [AccessColumn("Discontinued")]
        public bool Discontinued { get; set; }

        /// <summary>
        /// Get or set the minimum reorder quantity.
        /// </summary>
        [AccessColumn("Minimum Reorder Quantity")]
        public int MinimumReorderQuantity { get; set; }

        /// <summary>
        /// Get or set the category.
        /// </summary>
        [AccessColumn("Category")]
        public string Category { get; set; }

        /// <summary>
        /// Get or set the attachments.
        /// </summary>
        [AccessColumn("Attachments")]
        public string Attachments { get; set; }
    }
}
