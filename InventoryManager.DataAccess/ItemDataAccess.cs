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
    }
}
