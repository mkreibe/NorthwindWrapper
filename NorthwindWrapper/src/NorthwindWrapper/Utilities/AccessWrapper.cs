using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace NorthwindWrapper.Utilities
{
    /// <summary>
    /// Defines the access wrapper.
    /// </summary>
    public static class AccessWrapper
    {
        /// <summary>
        /// Query the access database.
        /// </summary>
        /// <typeparam name="T">The output type.</typeparam>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="processor">The processor to convert from the Access format to the output.</param>
        /// <returns>Returns the output format.</returns>
        public static T QueryDatabase<T>(NorthwindSettings settings, string sql, Func<OleDbDataReader, T> processor)
        {
            return QueryDatabase<T>(settings, sql, null, processor);
        }

        /// <summary>
        /// Query the access database.
        /// </summary>
        /// <typeparam name="T">The output type.</typeparam>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="parameters">The parameters to the SQL command.</param>
        /// <param name="processor">The processor to convert from the Access format to the output.</param>
        /// <returns>Returns the output format.</returns>
        public static T QueryDatabase<T>(NorthwindSettings settings, string sql, Dictionary<string, object> parameters, Func<OleDbDataReader, T> processor)
        {
            T output = default(T);
            ExecuteDatabase(settings, sql, parameters, (command) =>
            {
                // Execute the command.
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    output = processor(reader);
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
            });

            return output;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="parameters">The parameters to the SQL command.</param>
        /// <param name="processor">The processor to convert from the Access format to the output.</param>
        internal static void ExecuteDatabase(NorthwindSettings settings, string sql, Dictionary<string, object> parameters)
        {
            ExecuteDatabase(settings, sql, parameters, (command) => { command.ExecuteNonQuery(); });
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="parameters">The parameters to the SQL command.</param>
        /// <param name="processor">The processor to run.</param>
        internal static void ExecuteDatabase(NorthwindSettings settings, string sql, Dictionary<string, object> parameters, Action<OleDbCommand> processor)
        {
            using (OleDbConnection connection = new OleDbConnection(settings.ConnectionString))
            {
                connection.Open();

                // Create the command.
                OleDbCommand command = new OleDbCommand(sql, connection);

                // Add the parameters.
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> item in parameters)
                    {
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }

                processor?.Invoke(command);

                // Finally close the application.
                connection.Close();
            }
        }
    }
}
