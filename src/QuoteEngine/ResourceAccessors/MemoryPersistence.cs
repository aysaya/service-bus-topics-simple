using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteEngine.ResourceAccessors
{
    public interface ICommandRA
    {
        Task SaveAsync(object payload);
    }
    public interface IQueryRA
    {
        Task<object[]> GetAllAsync();
    }

    public class MemoryPersistence : ICommandRA, IQueryRA
    {
        private static HashSet<string> cache = new HashSet<string>();
        public async Task<object[]> GetAllAsync()
        {
            return await Task.FromResult<object[]>
                (
                    cache.Select(i => JsonConvert.DeserializeObject<object>(i)).ToArray()
                );
        }

        public async Task SaveAsync(object payload)
        {
            cache.Add(payload.ToString());
            await Task.CompletedTask;
        }
    }
}
