using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the employee privileges.
    /// </summary>
    [AccessTable("Employee Privileges", "Employee ID")]
    public class EmployeePrivilege
    {
        /// <summary>
        /// Get or set the employee id.
        /// </summary>
        [AccessColumn("Employee ID")]
        public int EmployeeID { get; set; }

        /// <summary>
        /// Get or set the privilege id.
        /// </summary>
        [AccessColumn("Privilege ID")]
        public int PrivilegeID { get; set; }
    }
}
