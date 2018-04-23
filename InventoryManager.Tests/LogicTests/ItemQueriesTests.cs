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
    public class ItemQueriesTests
    {
        [TestMethod]
        public async Task Should_return_empty_list_of_items()
        {
            //Arrange
            var items = new List<Item>(); //This breaks the definition of Unit test, refactor to use Moq library 
            var itemDataAccess = new ItemDataAccess(items); 
            var itemQueries = new ItemQueries(itemDataAccess);

            //Act
            var actual = (List<Item>) await itemQueries.GetItemsAsync();
            
            //Assert
            Assert.IsInstanceOfType(actual, typeof(List<Item>));
        }

        [TestMethod]
        public async Task Should_return_list_of_items()
        {
            //Arrange
            var items = new List<Item>(); //This breaks the definition of Unit test, refactor to use Moq library 
            var itemDataAccess = new ItemDataAccess(items);
            var itemQueries = new ItemQueries(itemDataAccess);

            //Act
            items.AddRange(new List<Item>
            {
                new Item() {Id = Guid.NewGuid()},
                new Item() {Id = Guid.NewGuid()}
            });
            var expected = items;
            var actual = (List<Item>) await itemQueries.GetItemsAsync();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
