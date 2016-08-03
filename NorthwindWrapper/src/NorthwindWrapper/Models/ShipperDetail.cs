using NorthwindWrapper.Utilities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the shipper details.
    /// </summary>
    public class ShipperDetail : Shipper
    {
        /// <summary>
        /// Get or set the shipper Home Phone.
        /// SQL: 'Home Phone'
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        /// Get or set the shipper Mobile Phone.
        /// SQL: 'Mobile Phone'
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Get or set the shipper Fax Number.
        /// SQL: 'Fax Number'
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Get or set the shipper Address.
        /// SQL: 'Address'
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Get or set the shipper City.
        /// SQL: 'City'
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Get or set the shipper State.
        /// SQL: 'State/Province'
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Get or set the shipper PostalCode.
        /// SQL: 'ZIP/Postal Code'
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Get or set the shipper Country.
        /// SQL: 'Country/Region'
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Get or set the shipper Web Page.
        /// SQL: 'Web Page'
        /// </summary>
        public string WebPage { get; set; }

        /// <summary>
        /// Get or set the shipper Notes.
        /// SQL: 'Notes'
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Get or set the shipper Attachments.
        /// SQL: 'Attachments'
        /// </summary>
        public string Attachments { get; set; }

        /// <summary>
        /// Decode the specific object with the provided reader.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="data">The decoding class.</param>
        /// <param name="reader">The reader to read.</param>
        /// <returns>Returns the decoded type.</returns>
        protected override T Decode<T>(T data, OleDbDataReader reader)
        {
            base.Decode<T>(data, reader);
            if (data is ShipperDetail) {
                ShipperDetail detail = data as ShipperDetail;
                detail.HomePhone = reader.IsDBNull(7) ? null : reader.GetString(7);
                detail.MobilePhone = reader.IsDBNull(8) ? null : reader.GetString(8);
                detail.FaxNumber = reader.IsDBNull(9) ? null : reader.GetString(9);
                detail.Address = reader.IsDBNull(10) ? null : reader.GetString(10);
                detail.City = reader.IsDBNull(11) ? null : reader.GetString(11);
                detail.State = reader.IsDBNull(12) ? null : reader.GetString(12);
                detail.PostalCode = reader.IsDBNull(13) ? null : reader.GetString(13);
                detail.Country = reader.IsDBNull(14) ? null : reader.GetString(14);
                detail.WebPage = reader.IsDBNull(15) ? null : reader.GetString(15);
                detail.Notes = reader.IsDBNull(16) ? null : reader.GetString(16);
                detail.Attachments = reader.IsDBNull(17) ? null : reader.GetString(17);
            }
            return data;
        }

        /// <summary>
        /// Modify the shipper details.
        /// </summary>
        /// <param name="id">The sipper to update.</param>
        /// <param name="detail">The shipper details.</param>
        internal static void Modify(NorthwindSettings settings, int id, ShipperDetail detail)
        {
            bool hasInsert = false;
            string sql = "UPDATE Shippers SET ";

            Dictionary<string, object> data = new Dictionary<string, object>();
            if(detail != null)
            {
                Action<string, string> UpdateStatement = (name, value) =>
                {
                    if (value != null)
                    {
                        string cleanName = "@" + name.Replace(" ", "").Replace("/", "");
                        sql += (hasInsert ? "," : "") + "[" + name + "] = " + cleanName;
                        data.Add(cleanName, value);
                        hasInsert = true;
                    }
                };

                UpdateStatement("Address", detail.Address);
                UpdateStatement("Attachments", detail.Attachments);
                UpdateStatement("Business Phone", detail.BusinessPhone);
                UpdateStatement("City", detail.City);
                UpdateStatement("Company", detail.Company);
                UpdateStatement("Country/Region", detail.Country);
                UpdateStatement("Email Address", detail.EmailAddress);
                UpdateStatement("Fax Number", detail.FaxNumber);
                UpdateStatement("First Name", detail.FirstName);
                UpdateStatement("Home Phone", detail.HomePhone);
                UpdateStatement("Job Title", detail.JobTitle);
                UpdateStatement("Last Name", detail.LastName);
                UpdateStatement("Mobile Phone", detail.MobilePhone);
                UpdateStatement("Notes", detail.Notes);
                UpdateStatement("ZIP/Postal Code", detail.PostalCode);
                UpdateStatement("State/Province", detail.State);
                UpdateStatement("Web Page", detail.WebPage);
            }

            if (hasInsert)
            {
                sql += " WHERE ID = @Id";
                data.Add("@Id", id);

                AccessWrapper.ExecuteDatabase(settings, sql, data);
            }
            else
            {
                throw new ArgumentException("No arguments.");
            }
        }


        internal static int Add(NorthwindSettings settings, ShipperDetail detail)
        {
            string columns = string.Empty;
            string values = string.Empty;
            Dictionary<string, object> data = new Dictionary<string, object>();

            Action<string, string> InsertStatement = (name, value) =>
            {
                if (value != null)
                {
                    string cleanName = "@" + name.Replace(" ", "").Replace("/", "");
                    columns += (string.IsNullOrWhiteSpace(columns) ? "" : ",") + "[" + name + "]";
                    values += (string.IsNullOrWhiteSpace(values) ? "" : ",") + cleanName;
                    data.Add(cleanName, value);
                }
            };

            InsertStatement("Address", detail.Address);
            InsertStatement("Attachments", detail.Attachments);
            InsertStatement("Business Phone", detail.BusinessPhone);
            InsertStatement("City", detail.City);
            InsertStatement("Company", detail.Company);
            InsertStatement("Country/Region", detail.Country);
            InsertStatement("Email Address", detail.EmailAddress);
            InsertStatement("Fax Number", detail.FaxNumber);
            InsertStatement("First Name", detail.FirstName);
            InsertStatement("Home Phone", detail.HomePhone);
            InsertStatement("Job Title", detail.JobTitle);
            InsertStatement("Last Name", detail.LastName);
            InsertStatement("Mobile Phone", detail.MobilePhone);
            InsertStatement("Notes", detail.Notes);
            InsertStatement("ZIP/Postal Code", detail.PostalCode);
            InsertStatement("State/Province", detail.State);
            InsertStatement("Web Page", detail.WebPage);

            string sql = "INSERT INTO Shippers (";
            sql += columns;
            sql += ") VALUES (";
            sql += values;
            sql += ")";

            int? id = null;
            AccessWrapper.ExecuteDatabase(settings, sql, data, (command) =>
            {
                command.ExecuteNonQuery();
                id = AccessWrapper.QueryDatabase<int?>(settings, "SELECT TOP 1 * FROM [Shippers] ORDER BY [ID] DESC", (ids) =>
                {
                    ids.Read();
                    return ids.GetInt32(0);
                });
            });

            return id.Value;
        }
    }
}