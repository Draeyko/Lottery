using Lottery.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lottery.Shared.Services
{
    public interface IDatabaseService
    {
        Task<List<Draw>> GetDrawsAsync();
        Task<int> SaveDrawAsync(Draw draw);
        Task<int> DeleteDrawAsync(Draw draw);
    }
}
