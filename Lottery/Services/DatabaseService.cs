
using Lottery.Shared.Models;
using Lottery.Shared.Services;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Lottery.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "lottery.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Draw>().Wait();
        }

        public Task<List<Draw>> GetDrawsAsync()
        {
            return _database.Table<Draw>().ToListAsync();
        }

        public Task<int> SaveDrawAsync(Draw draw)
        {
            return _database.InsertOrReplaceAsync(draw);
        }

        public Task<int> DeleteDrawAsync(Draw draw)
        {
            return _database.DeleteAsync(draw);
        }
    }
}