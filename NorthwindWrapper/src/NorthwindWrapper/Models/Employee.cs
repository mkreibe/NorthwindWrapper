using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the customer object.
    /// </summary>
    [AccessTable("Employees", "ID")]
    public class Employee : AddressItem
    {
        // No specific properties
    }
}
