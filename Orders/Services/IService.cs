using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logging.Services
{
    public interface IService<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync();
    }
}
