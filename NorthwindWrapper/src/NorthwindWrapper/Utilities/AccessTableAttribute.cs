using System;

namespace NorthwindWrapper.Utilities
{
    /// <summary>
    /// Addorns a type with an associated access database table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AccessTableAttribute : Attribute
    {
        /// <summary>
        /// Get the table name.
        /// </summary>
        public string Table { get; private set; }

        /// <summary>
        /// Get the key value.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Create the table attribute.
        /// </summary>
        /// <param name="table">The table name.</param>
        /// <param name="key">The tables key value.</param>
        public AccessTableAttribute(string table, string key)
        {
            this.Table = table;
            this.Key = key;
        }
    }
}
