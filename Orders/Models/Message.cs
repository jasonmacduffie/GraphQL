using System;
using System.Data.SqlClient;

namespace Logging.Models
{
    public class Message
    {
        public Message(string emailEntryId, string businessFunctionCode)
        {
            EmailEntryId = emailEntryId;
            BusinessFunctionCode = businessFunctionCode;
        }

        public Message(SqlDataReader reader)
        {
            EmailEntryId = reader["MessageId"].ToString();
            BusinessFunctionCode = reader["BusinessFunctionCode"].ToString();
            BrokerCode = reader["BrokerCode"].ToString();
            Created = DateTime.Parse(reader["CreatedDateTime"].ToString());
            Modified = DateTime.Parse(reader["ModifiedDateTime"].ToString());
        }

        public string EmailEntryId { get; set; }
        public string BusinessFunctionCode { get; set; }
        public string BrokerCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
