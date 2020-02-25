using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logging.Models;

namespace Logging.Services
{
    public class MessageService : Service, IService<Message>
    {
        private readonly IList<Message> messages = new List<Message>();

        public MessageService()
        {
            Populate(messages, "Message");
        }

        public Task<Message> GetItemAsync(string id) => Task.FromResult(GetMessageById(id));

        public Task<IEnumerable<Message>> GetItemsAsync() => Task.FromResult(messages.AsEnumerable());

        private Message GetMessageById(string id)
        {
            var message = messages.SingleOrDefault(i => Equals(i.EmailEntryId, id));
            if (message == null)
            {
                throw new ArgumentException($"Email Entry ID: {id} is invalid");
            }
            return message;
        }
    }
}
