using System;
using System.Threading.Tasks;
using InventoryManager.Domain.Interfaces;
using InventoryManager.Domain.Models;

namespace InventoryManager.Logic
{
    public class ItemCommands : IItemCommands
    {
        private IItemDataAccess _itemDataAccess;

        public ItemCommands(IItemDataAccess itemDataAccess)
        {
            _itemDataAccess = itemDataAccess;
        }

        public async Task AddItemAsync(Item item)
        {
            await _itemDataAccess.SaveItemAsync(item);
        }

        public async Task PopItemsAsync(int amount)
        {
            for (int i = 1; i < amount; i++)
            {
                await _itemDataAccess.PopItemAsync();
            }
        }

        public async Task RemoveItemAsync(Item item)
        {
            await _itemDataAccess.RemoveItemAsync(item);
        }
    }
}