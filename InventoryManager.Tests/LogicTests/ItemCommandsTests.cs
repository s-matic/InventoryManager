using InventoryManager.DataAccess;
using InventoryManager.Domain.Models;
using InventoryManager.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Tests.LogicTests
{
    [TestClass]
    public class ItemCommandsTests
    {
        [TestMethod]
        public async Task Should_add_item_to_store()
        {
            //Arrange
            var items = new List<Item>(); //This breaks the definition of Unit test, refactor to use Moq library 
            var itemDataAccess = new ItemDataAccess(items);
            var itemCommands = new ItemCommands(itemDataAccess);

            int expected = 1;
            var itemToAdd = new Item() { Id = Guid.NewGuid() };
            
            //Act
            await itemCommands.AddItemAsync(itemToAdd);
            var actual = items.Count;
            
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Should_remove_item_from_store()
        {
            //Arrange
            var items = new List<Item>(); //This breaks the definition of Unit test, refactor to use Moq library 
            var itemDataAccess = new ItemDataAccess(items);
            var itemCommands = new ItemCommands(itemDataAccess);

            int expected = 0;
            var itemToRemove = new Item()
            {
                Id = Guid.NewGuid()
            };
            items.Add(itemToRemove);
            
            //Act
            await itemCommands.RemoveItemAsync(itemToRemove);
            int actual = items.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Should_pop_items_from_store()
        {
            //Arrange
            var items = new List<Item>(); //This breaks the definition of Unit test, refactor to use Moq library 
            var itemDataAccess = new ItemDataAccess(items);
            var itemCommands = new ItemCommands(itemDataAccess);

            items.AddRange(new List<Item>()
            {
                new Item()
                {
                    Id = Guid.NewGuid()
                },
                new Item()
                {
                    Id = Guid.NewGuid()
                },
                new Item()
                {
                    Id = Guid.NewGuid()
                }
            });

            //Act
            await itemCommands.PopItemsAsync(2);
            int expected = 1;
            int actual = items.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task Should_add_range_of_items_to_store()
        {
            //Arrange
            var items = new List<Item>(); //This breaks the definition of Unit test, refactor to use Moq library 
            var itemDataAccess = new ItemDataAccess(items);
            var itemCommands = new ItemCommands(itemDataAccess);

            var itemsToAdd = new List<Item>()
            {
                new Item()
                {
                    Id = Guid.NewGuid()
                },
                new Item()
                {
                    Id = Guid.NewGuid()
                },
                new Item()
                {
                    Id = Guid.NewGuid()
                }
            };

            //Act
            await itemCommands.AddItemRangeAsync(itemsToAdd);
            int expected = 3;
            int actual = items.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
