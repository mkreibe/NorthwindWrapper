using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Reflection;

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
        public static T QueryDatabase<T>(AccessSettings settings, string sql, Func<OleDbDataReader, T> processor)
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
        public static T QueryDatabase<T>(AccessSettings settings, string sql, Dictionary<string, object> parameters, Func<OleDbDataReader, T> processor)
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
        internal static void ExecuteDatabase(AccessSettings settings, string sql, Dictionary<string, object> parameters)
        {
            ExecuteDatabase(settings, sql, parameters, (command) => { command.ExecuteNonQuery(); });
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="parameters">The parameters to the SQL command.</param>
        /// <param name="processor">The processor to run.</param>
        internal static void ExecuteDatabase(AccessSettings settings, string sql, Dictionary<string, object> parameters, Action<OleDbCommand> processor)
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

        /// <summary>
        /// Deserialize the object.
        /// </summary>
        /// <param name="type">The type being read.</param>
        /// <param name="reader">The reader to use.</param>
        /// <returns>Returns the deserialized object.</returns>
        internal static object Deserialize(Type type, OleDbDataReader reader)
        {
            object data = Activator.CreateInstance(type);
            foreach (PropertyInfo prop in type.GetProperties())
            {
                AccessColumnAttribute attr = prop.GetCustomAttribute<AccessColumnAttribute>();
                if (attr != null)
                {
                    int ordinal = reader.GetOrdinal(attr.Name);

                    object value = null;
                    if (!reader.IsDBNull(ordinal))
                    {
                        Type fieldType = reader.GetFieldType(ordinal);
                        if (fieldType == typeof(string))
                        {
                            value = reader.GetString(ordinal);
                        }
                        else if (fieldType == typeof(short))
                        {
                            value = reader.GetInt16(ordinal);
                        }
                        else if (fieldType == typeof(int))
                        {
                            value = reader.GetInt32(ordinal);
                        }
                        else if (fieldType == typeof(byte))
                        {
                            value = reader.GetByte(ordinal);
                        }
                        else if (fieldType == typeof(DateTime))
                        {
                            value = reader.GetDateTime(ordinal);
                        }
                        else if(fieldType == typeof(double))
                        {
                            value = reader.GetDouble(ordinal);
                        }
                        else if (fieldType == typeof(decimal))
                        {
                            value = reader.GetDecimal(ordinal);
                        }
                        else if (fieldType == typeof(bool))
                        {
                            value = reader.GetBoolean(ordinal);
                        }
                        else
                        {
                            Debugger.Break();
                        }
                    }

                    prop.SetValue(data, value);
                }
            }

            return data;
        }

        /// <summary>
        /// Get a specific object type.
        /// </summary>
        /// <typeparam name="T">The resulting object type.</typeparam>
        /// <param name="settings">The settings to the access database.</param>
        /// <param name="id">The item id to return, if this has no value return the entire collection.</param>
        /// <returns>The collection of object.</returns>
        internal static List<T> Get<T>(AccessSettings settings, int? id) where T : new()
        {
            return new List<T>(Get(settings, typeof(T), id) as List<T>);
        }

        /// <summary>
        /// Get the table name from the object.
        /// </summary>
        /// <param name="type">The object type to examine.</param>
        /// <returns>Returns the table name or null if the type is not a serialized table.</returns>
        internal static string GetTableName(Type type)
        {
            AccessTableAttribute attr = type.GetCustomAttribute<AccessTableAttribute>();

            string result = null;
            if (attr != null)
            {
                result = attr.Table;
            }

            return result;
        }

        /// <summary>
        /// Get a specific object type.
        /// </summary>
        /// <param name="settings">The settings to the access database.</param>
        /// <param name="type">The resulting object type.</param>
        /// <param name="id">The item id to return, if this has no value return the entire collection.</param>
        /// <returns>The collection of object.</returns>
        internal static List<object> Get(AccessSettings settings, Type type, int? id)
        {
            AccessTableAttribute attr = type.GetCustomAttribute<AccessTableAttribute>();
            List<object> result = null;
            if(attr != null)
            {
                string sql = $"SELECT * FROM [{attr.Table}]";
                Dictionary<string, object> data = null;

                if (id.HasValue)
                {
                    sql += $" WHERE {attr.Key} = @1";
                    data = new Dictionary<string, object>() {
                        { "@1", id }
                    };
                }

                result = AccessWrapper.QueryDatabase(
                    settings,
                    sql,
                    data,
                    (reader) =>
                    {
                        List<object> output = new List<object>();

                        while (reader.Read())
                        {
                            object t = AccessWrapper.Deserialize(type, reader);
                            output.Add(t);
                        }

                        return output;
                    });
            }

            return result;
        }

        /// <summary>
        /// Delete the object from the database.
        /// </summary>
        /// <typeparam name="T">The type to be deleted.</typeparam>
        /// <param name="settings">The settings to the access database.</param>
        /// <param name="id">The item id to delete.</param>
        internal static void Delete<T>(AccessSettings settings, int id)
        {
            Delete(settings, typeof(T), id);
        }

        /// <summary>
        /// Delete the object from the database.
        /// </summary>
        /// <param name="settings">The settings to the access database.</param>
        /// <param name="type">The type to be deleted.</param>
        /// <param name="id">The item id to delete.</param>
        internal static void Delete(AccessSettings settings, Type type, int id)
        {
            AccessTableAttribute attr = type.GetCustomAttribute<AccessTableAttribute>();
            if (attr != null)
            {
                AccessWrapper.ExecuteDatabase(settings, $"DELETE FROM [{attr.Table}] WHERE [{attr.Key}] = @id", new Dictionary<string, object>() {
                    { "@id", id }
                });
            }
        }

        /// <summary>
        /// Modify a value.
        /// </summary>
        /// <typeparam name="T">The values type.</typeparam>
        /// <param name="settings">The settings to the access database.</param>
        /// <param name="id">The item id to modify.</param>
        /// <param name="item">This values to modify</param>
        internal static void Modify<T>(AccessSettings settings, int id, T item)
        {
            Modify(settings, typeof(T), id, item);
        }

        /// <summary>
        /// Modify a value.
        /// </summary>
        /// <param name="settings">The settings to the access database.</param>
        /// <param name="type">The values type.</param>
        /// <param name="id">The item id to modify.</param>
        /// <param name="item">This values to modify</param>
        internal static void Modify(AccessSettings settings, Type type, int id, object item)
        {
            AccessTableAttribute typeAttr = type.GetCustomAttribute<AccessTableAttribute>();
            if (typeAttr != null)
            {
                string setValues = string.Empty;

                Dictionary<string, object> data = new Dictionary<string, object>();
                if (item != null)
                {
                    foreach (PropertyInfo prop in type.GetProperties())
                    {
                        AccessColumnAttribute dataAttr = prop.GetCustomAttribute<AccessColumnAttribute>();
                        if (dataAttr != null)
                        {
                            if (!dataAttr.IsReadonly)
                            {
                                string cleanName = prop.Name;

                                Object value = prop.GetValue(item);
                                if (value != null)
                                {
                                    setValues += (string.IsNullOrWhiteSpace(setValues) ? "" : ",") + $"[{dataAttr.Name}] = @{prop.Name}";
                                    data.Add(prop.Name, value);
                                }
                            }
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(setValues))
                {
                    AccessWrapper.ExecuteDatabase(settings, $"UPDATE [{typeAttr.Table}] SET {setValues} WHERE [{typeAttr.Key}] = @1", data);
                }
                else
                {
                    throw new ArgumentException("No arguments.");
                }
            }
        }

        /// <summary>
        /// Add a value to the db.
        /// </summary>
        /// <typeparam name="T">The type to add.</typeparam>
        /// <param name="settings">The access settings.</param>
        /// <param name="item">The item to add.</param>
        /// <returns>Returns the item id to add, or null if it wasn't.</returns>
        internal static int? Add<T>(AccessSettings settings, T item)
        {
            return Add(settings, typeof(T), item);
        }

        /// <summary>
        /// Add a value to the db.
        /// </summary>
        /// <param name="settings">The access settings.</param>
        /// <param name="type">The type to add.</param>
        /// <param name="item">The item to add.</param>
        /// <returns>Returns the item id to add, or null if it wasn't.</returns>
        internal static int? Add(AccessSettings settings, Type type, object item) {
            AccessTableAttribute typeAttr = type.GetCustomAttribute<AccessTableAttribute>();
            int? id = null;
            if (typeAttr != null)
            {
                string columns = string.Empty;
                string values = string.Empty;
                Dictionary<string, object> data = new Dictionary<string, object>();

                foreach (PropertyInfo prop in type.GetProperties())
                {
                    AccessColumnAttribute dataAttr = prop.GetCustomAttribute<AccessColumnAttribute>();
                    if (dataAttr != null)
                    {
                        if (!dataAttr.IsReadonly)
                        {
                            string cleanName = prop.Name;

                            Object value = prop.GetValue(item);
                            if (value != null)
                            {
                                columns += (string.IsNullOrWhiteSpace(columns) ? "" : ",") + $"[{dataAttr.Name}]";
                                values += (string.IsNullOrWhiteSpace(values)? "" : ",") + $"@{prop.Name}";
                                data.Add(prop.Name, value);
                            }
                        }
                    }
                }

                AccessWrapper.ExecuteDatabase(settings, $"INSERT INTO [{typeAttr.Table}] ({columns}) VALUES ({values})", data, (command) =>
                {
                    command.ExecuteNonQuery();
                    id = AccessWrapper.QueryDatabase<int?>(settings, $"SELECT TOP 1 * FROM [{typeAttr.Table}] ORDER BY [{typeAttr.Key}] DESC", (ids) =>
                    {
                        ids.Read();
                        return ids.GetInt32(0);
                    });
                });
            }

            return id;
        }
    }
}
