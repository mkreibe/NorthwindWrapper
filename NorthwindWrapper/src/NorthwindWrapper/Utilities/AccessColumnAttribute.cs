using System;

namespace NorthwindWrapper.Utilities
{
    /// <summary>
    /// Addorns a property with an associated access database column.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AccessColumnAttribute : Attribute
    {
        /// <summary>
        /// Create the attribute with the field name specified.
        /// </summary>
        /// <param name="name">The database field name.</param>
        public AccessColumnAttribute(string name) : this(name, false)
        {
            // No-Op
        }

        /// <summary>
        /// Create the attribute with the field name specified.
        /// </summary>
        /// <param name="name">The database field name.</param>
        /// <param name="isReadonly">The column readonly flag.</param>
        public AccessColumnAttribute(string name, bool isReadonly)
        {
            this.Name = name;
            this.IsReadonly = isReadonly;
        }

        /// <summary>
        /// Is the column flag.
        /// </summary>
        public bool IsReadonly { get; internal set; }

        /// <summary>
        /// Get the column name.
        /// </summary>
        public string Name { get; private set; }
    }
}
