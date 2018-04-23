using InventoryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using InventoryManager.Domain.Models;
using System.Threading.Tasks;

namespace InventoryManager.Logic
{
    public class ItemQueries : IItemQueries
    {
        public Task<ICollection<Item>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
