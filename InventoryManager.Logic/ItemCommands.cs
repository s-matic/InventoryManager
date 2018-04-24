using System;
using System.Collections.Generic;
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

        public async Task AddItemRangeAsync(List<Item> items)
        {
            await _itemDataAccess.AddItemRangeAsync(items);
        }

        public async Task PopItemsAsync(int amount)
        {
            for (int i = 0; i < amount; i++)
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