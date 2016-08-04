using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the customer object.
    /// </summary>
    [AccessTable("Customers", "ID")]
    public class Customer : AddressItem
    {
        // No specific properties
    }
}
