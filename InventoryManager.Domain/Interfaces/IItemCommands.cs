using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Interfaces
{
    public interface IItemCommands
    {
        Task AddItemAsync(Item item);
        Task RemoveItemAsync(Item item);
        Task PopItemsAsync(int amount);
        Task AddItemRangeAsync(List<Item> items);
    }
}
