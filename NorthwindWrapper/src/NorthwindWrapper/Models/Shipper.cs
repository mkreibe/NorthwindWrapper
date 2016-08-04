﻿using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the shipper object.
    /// </summary>
    [AccessTable("Shippers", "ID")]
    public class Shipper : AddressItem
    {
        // No specific properties
    }
}