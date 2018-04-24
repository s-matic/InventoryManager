using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Interfaces
{
    public interface IItemDataAccess
    {
        Task<ICollection<Item>> GetItemsAsync();
        Task SaveItemAsync(Item item);
        Task RemoveItemAsync(Item item);
        Task PopItemAsync();
    }
}
