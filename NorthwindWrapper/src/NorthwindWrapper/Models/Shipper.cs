using NorthwindWrapper.Utilities;
using System.Collections.Generic;
using System.Data.OleDb;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the shipper object.
    /// </summary>
    public class Shipper
    {
        /// <summary>
        /// Get or set the shipper Id.
        /// SQL: 'ID'
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get or set the shipper Company.
        /// SQL: 'Company'
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Get or set the shipper Last Name.
        /// SQL: 'Last Name'
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the shipper First Name.
        /// SQL: 'First Name'
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set the shipper E-mail Address.
        /// SQL: 'E-mail Address'
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Get or set the shipper Job Title.
        /// SQL: 'Job Title'
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Get or set the shipper Business Phone.
        /// SQL: 'Business Phone'
        /// </summary>
        public string BusinessPhone { get; set; }

        /// <summary>
        /// Decode the specific object with the provided reader.
        /// </summary>
        /// <typeparam name="T">The data type.</typeparam>
        /// <param name="reader">The reader to read.</param>
        /// <returns>Returns the decoded type.</returns>
        protected virtual T Decode<T>(T data, OleDbDataReader reader) where T : Shipper, new()
        {
            data.Id = reader.GetInt32(0);
            data.Company = reader.IsDBNull(1) ? null : reader.GetString(1);
            data.LastName = reader.IsDBNull(2) ? null : reader.GetString(2);
            data.FirstName = reader.IsDBNull(3) ? null : reader.GetString(3);
            data.EmailAddress = reader.IsDBNull(4) ? null : reader.GetString(4);
            data.JobTitle = reader.IsDBNull(5) ? null : reader.GetString(5);
            data.BusinessPhone = reader.IsDBNull(6) ? null : reader.GetString(6);

            return data;
        }

        /// <summary>
        /// Get the collection of shippers.
        /// </summary>
        /// <param name="id">The shipper id.</param>
        /// <returns></returns>
        internal static List<T> GetShippers<T>(NorthwindSettings settings, int? id) where T : Shipper, new()
        {
            string sql = "SELECT * FROM Shippers";
            Dictionary<string, object> data = null;

            if (id.HasValue)
            {
                sql += " WHERE ID = @1";
                data = new Dictionary<string, object>() {
                    { "@1", id }
                };
            }

            return AccessWrapper.QueryDatabase(
                settings,
                sql,
                data,
                (reader) =>
                {
                    List<T> output = new List<T>();

                    while(reader.Read())
                    {
                        T t = new T();
                        t.Decode(t, reader);
                        output.Add(t);
                    }

                    return output;
                });
        }


        internal static void Delete(NorthwindSettings settings, int id)
        {
            AccessWrapper.ExecuteDatabase(settings, "DELETE FROM Shippers WHERE ID = @id", new Dictionary<string, object>() {
                { "@id", id }
            });
        }
    }
}