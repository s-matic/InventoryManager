﻿using InventoryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using InventoryManager.Domain.Models;
using System.Threading.Tasks;

namespace InventoryManager.Logic
{
    public class ItemQueries : IItemQueries
    {
        private IItemDataAccess _itemDataAccess;

        public ItemQueries(IItemDataAccess itemDataAccess)
        {
            _itemDataAccess = itemDataAccess;
        }
        public async Task<ICollection<Item>> GetItemsAsync()
        {
            return await _itemDataAccess.GetItemsAsync();
        }
    }
}
