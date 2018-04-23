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
    }
}
