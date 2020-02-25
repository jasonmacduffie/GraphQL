using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Logging.Services
{
    public abstract class Service
    {
        public readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = @"(localdb)\GraphQL",
            InitialCatalog = "Automation"
        };

        public void Populate<T> (IList<T> collection, string tableName)
        {
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"Select * From {tableName}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            collection.Add((T)Activator.CreateInstance(typeof(T), new object[] { reader }));
                        }
                    }
                }
            }
        }
    }
}
    