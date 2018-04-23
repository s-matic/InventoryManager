using InventoryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using InventoryManager.Domain.Models;
using System.Threading.Tasks;

namespace InventoryManager.DataAccess
{
    public class ItemDataAccess : IItemDataAccess
    {
        private List<Item> _items;

        public ItemDataAccess(List<Item> items)
        {
            _items = items;
        }

        public async Task<ICollection<Item>> GetItemsAsync()
        {
            var getItemsTask = Task.Run(() => _items);
            return await getItemsTask;
        }

        public async Task RemoveItemAsync(Item item)
        {
            var removeItemTask = Task.Run(() => _items.Remove(item));
            await removeItemTask;
        }

        public async Task SaveItemAsync(Item item)
        {
            //Here we should do an upsert, but since we do not support update functionality go straight to insert
            await InsertItemAsync(item);
        }

        private async Task InsertItemAsync(Item item)
        {
            var insertItemTask = Task.Run(() => _items.Add(item));
            await insertItemTask;
        }
    }
}
