using InventoryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Interfaces
{
    public interface IItemQueries
    {
        Task<ICollection<Item>> GetItemsAsync();
    }
}
