using NorthwindWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines a supplier
    /// </summary>
    [AccessTable("Suppliers", "ID")]
    public class Supplier : AddressItem
    {
        // No specific properties
    }
}
