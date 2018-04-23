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

        public Task RemoveItemAsync(Guid itemId)
        {
            throw new NotImplementedException();
        }
    }
}