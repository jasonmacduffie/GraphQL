using System.Data.SqlClient;

namespace Logging.Models
{
    public class Broker
    {
        public Broker(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public Broker(SqlDataReader reader)
        {
            Code = reader["Code"].ToString();
            Name = reader["Name"].ToString();
            Description = reader["Description"].ToString();
        }

        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
