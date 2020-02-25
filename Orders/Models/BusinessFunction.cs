using System.Data.SqlClient;

namespace Logging.Models
{
    public class BusinessFunction
    {
        public BusinessFunction(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public BusinessFunction(SqlDataReader reader)
        {
            Code = reader["Code"].ToString();
            Name = reader["Name"].ToString();
            Description = reader["Description"].ToString();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
