using NorthwindWrapper.Utilities;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the common addressable items.
    /// </summary>
    public abstract class AddressItem
    {
        /// <summary>
        /// Get or set the addressable Id.
        /// </summary>
        [AccessColumn("ID", true)]
        public int Id { get; set; }

        /// <summary>
        /// Get or set the addressable Company.
        /// </summary>
        [AccessColumn("Company")]
        public string Company { get; set; }

        /// <summary>
        /// Get or set the addressable Last Name.
        /// </summary>
        [AccessColumn("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the addressable First Name.
        /// </summary>
        [AccessColumn("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set the addressable E-mail Address.
        /// </summary>
        [AccessColumn("E-mail Address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Get or set the addressable Job Title.
        /// </summary>
        [AccessColumn("Job Title")]
        public string JobTitle { get; set; }

        /// <summary>
        /// Get or set the addressable Business Phone.
        /// </summary>
        [AccessColumn("Business Phone")]
        public string BusinessPhone { get; set; }

        /// <summary>
        /// Get or set the addressable Home Phone.
        /// </summary>
        [AccessColumn("Home Phone")]
        public string HomePhone { get; set; }

        /// <summary>
        /// Get or set the addressable Mobile Phone.
        /// </summary>
        [AccessColumn("Mobile Phone")]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Get or set the addressable Fax Number.
        /// </summary>
        [AccessColumn("Fax Number")]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Get or set the addressable Address.
        /// </summary>
        [AccessColumn("Address")]
        public string Address { get; set; }

        /// <summary>
        /// Get or set the addressable City.
        /// </summary>
        [AccessColumn("City")]
        public string City { get; set; }

        /// <summary>
        /// Get or set the addressable State.
        /// </summary>
        [AccessColumn("State/Province")]
        public string State { get; set; }

        /// <summary>
        /// Get or set the addressable PostalCode.
        /// </summary>
        [AccessColumn("ZIP/Postal Code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Get or set the addressable Country.
        /// </summary>
        [AccessColumn("Country/Region")]
        public string Country { get; set; }

        /// <summary>
        /// Get or set the addressable Web Page.
        /// </summary>
        [AccessColumn("Web Page")]
        public string WebPage { get; set; }

        /// <summary>
        /// Get or set the addressable Notes.
        /// </summary>
        [AccessColumn("Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Get or set the addressable Attachments.
        /// </summary>
        [AccessColumn("Attachments")]
        public string Attachments { get; set; }
    }
}
