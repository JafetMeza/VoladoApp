using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoladoApp.Models;

namespace VoladoApp.Services
{
    public class ItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public ItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Results).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Results)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Results>> GetItemsAsync()
        {
            return Database.Table<Results>().ToListAsync();
        }

        public Task<Results> GetItemAsync(int id)
        {
            return Database.Table<Results>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Results item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Results item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
