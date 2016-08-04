using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the transaction types.
    /// </summary>
    [AccessTable("Inventory Transaction Types", "ID")]
    public class InventoryTransactionType
    {
        /// <summary>
        /// Get or set the type id
        /// </summary>
        [AccessColumn("ID", true)]
        public int ID { get; set; }

        /// <summary>
        /// Get or set the type name
        /// </summary>
        [AccessColumn("Type Name", true)]
        public string Name { get; set; }
    }
}
